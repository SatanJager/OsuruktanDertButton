using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuruktanDertButton
{
    public class HistoryForm : Form
    {
        private readonly Language _language;
        private ListBox _historyListBox = null!;
        private Button _clearButton = null!;
        private Button _deleteButton = null!;
        private Button _closeButton = null!;

        public HistoryForm(Language language)
        {
            _language = language;
            InitializeUi();
            LoadHistory();
            Themes.ThemeChanged += OnThemeChangedGlobally;
            ApplyTheme();
        }

        private void InitializeUi()
        {
            Text = Localization.Get(Localization.HistoryWindowTitle, _language);
            Icon = new Icon(Path.Combine(AppContext.BaseDirectory, "AppIcon.ico"));
            Width = 480;
            Height = 420;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            _historyListBox = new ListBox
            {
                Left = 20,
                Top = 20,
                Width = 430,
                Height = 300,
            };

            _deleteButton = new Button
            {
                Left = 20,
                Top = 335,
                Width = 140,
                Height = 35,
                Text = Localization.Get(Localization.DeleteSelectedButton, _language),
            };
            _deleteButton.FlatStyle = FlatStyle.Flat;
            _deleteButton.Click += OnDeleteClicked;

            _clearButton = new Button
            {
                Left = 165,
                Top = 335,
                Width = 140,
                Height = 35,
                Text = Localization.Get(Localization.ClearHistoryButton, _language),
            };
            _clearButton.FlatStyle = FlatStyle.Flat;
            _clearButton.Click += OnCLearClicked;
            
            _closeButton = new Button
            {
                Left = 310,
                Top = 335,
                Width = 140,
                Height = 35,
                Text = Localization.Get(Localization.CloseHistoryButton, _language),
            };
            _closeButton.FlatStyle = FlatStyle.Flat;
            _closeButton.Click += OnCloseClicked;
            
            // Kontrolleri Ram'den çağırdık
            Controls.Add(_historyListBox);
            Controls.Add(_deleteButton);
            Controls.Add(_clearButton);
            Controls.Add(_closeButton);
        }
        private void LoadHistory()
        {
            _historyListBox.Items.Clear();
            //listeyi her yüklemeden önce temizliyoruz. Şu an için tek bir kez çağrılıyor (constructor'da) ama ileride mesela "Yenile" butonu eklersen, bu metodu tekrar çağırdığında eski kayıtların üstüne eklenmesin, sıfırdan dolsun diye önemli bir alışkanlık.

            var complaints = ComplaintStore.GetAllComplaints();

            if (complaints.Count == 0)
            {
                _historyListBox.Items.Add(Localization.Get(Localization.HistoryEmpty, _language));
                return;
            }

            complaints.Reverse();  // Dert listesinde hep sona ekleme oluyor ama bu metotla gösterimi en sonuncuyu en başa alıyoruz.
            foreach (var complaint in complaints)
            {
                _historyListBox.Items.Add(complaint);
            }
        }
        private void OnCLearClicked(object? sender, EventArgs e)
        {
            ComplaintStore.ClearAll();  // dosyanın içeriğini sıfırlıyoruz
            LoadHistory(); // Listeyi geri yükleme
        }
        private void OnDeleteClicked(object? sender, EventArgs e)
        {
            if (_historyListBox.SelectedItem is not string selectedComplaint)
                return;

            ComplaintStore.DeleteComplaint(selectedComplaint);
            LoadHistory();
        }
        private void OnCloseClicked(object? sender, EventArgs e)
        {
            Close();
        }
        private void OnThemeChangedGlobally(object? sender, EventArgs e)
        {
            ApplyTheme();
        }
        private void ApplyTheme()
        {
            var colors = Themes.Current;

            BackColor = colors.FormBackColor;
            _historyListBox.BackColor = colors.TextBoxBackColor;
            _historyListBox.ForeColor = colors.TextBoxForeColor;

            _deleteButton.BackColor = colors.DangerButtonBackColor;
            _deleteButton.ForeColor = colors.DangerButtonTextColor;

            _clearButton.BackColor = colors.DangerButtonBackColor;
            _clearButton.ForeColor = colors.DangerButtonTextColor;

            _closeButton.BackColor = colors.SecondaryButtonBackColor;
            _closeButton.ForeColor = colors.SecondaryButtonTextColor;
        }
    }
}
