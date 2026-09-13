using System;
using System.ComponentModel.Design.Serialization;
namespace OsuruktanDertButton
{
    public partial class MainForm : Form
    {
        private Language _currentLanguage = Language.Turkish;

        private ComboBox _languageComboBox = null!;
        private Label _languageLabel = null!;
        private Label _promptLabel = null!;
        private TextBox _complaintTextBox = null!;
        private Button _solveButton = null!;
        private Button _historyButton = null!;
        private Label _resultLabel = null!;

        public MainForm()
        {
            InitializeUi();
            ApplyLanguage();
        }

        private void InitializeUi()
        {
            Text = Localization.Get(Localization.WindowTitle, _currentLanguage);  //Percerenin başlık çubuğunda gözüke yazı
            Width = 480;
            Height = 380;
            StartPosition = FormStartPosition.CenterScreen; //Percere açılınca ekranın ortasında çıksın
            FormBorderStyle = FormBorderStyle.FixedDialog; //Percere sabit boyutlu.
            MaximizeBox = false; //Sabit boyut - Sağ üsteki pencere büyütücü inaktif

            _languageLabel = new Label
            {
                Left = 20,
                Top = 15,
                Width = 50,
                AutoSize = true, //Label'ın genişliği/yüksekliği, içindeki yazıya göre kendini otomatik ayarlasın
            };

            _languageComboBox = new ComboBox
            {
                Left = 80,
                Top = 12,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            _languageComboBox.Items.Add("Türkçe"); //0
            _languageComboBox.Items.Add("English"); //1
            _languageComboBox.Items.Add("Deutsch"); //2
            _languageComboBox.SelectedIndex = 0;
            _languageComboBox.SelectedIndexChanged += OnLanguageChanged; // kullanıcı listeden birşey seçtiğinde OnLanguageChanged metodu çalışacak

            _promptLabel = new Label
            {
                Left = 20,
                Top = 55,
                Width = 430,
                AutoSize = true,
            };

            _complaintTextBox = new TextBox
            {
                Left = 20,
                Top = 80,
                Width = 430,
                Height = 120,
                Multiline = true,  //TextBox'ı multiline yaptık
                ScrollBars = ScrollBars.Vertical, //Kullanıcı çok uzun bir yazı yazarsa kaydırma çubuğu çıksın
            };
            _complaintTextBox.Enter += OnComplaintTextBoxEnter;

            _solveButton = new Button
            {
                Left = 20,
                Top = 215,
                Width = 200,
                Height = 40,
            };
            _solveButton.Click += OnSolveClicked; //SolveButton'a basılınca OnSolveClicked metodu başlayacak

            _historyButton = new Button
            {
                Left = 250,
                Top = 215,
                Width= 200,
                Height = 40,
            };
            _historyButton.Click += OnHistoryClicked; //HistoryButton basıldığında OnHistoryClicked metodu başlayacak

            _resultLabel = new Label
            {
                Left = 20,
                Top = 270,
                Width = 430,
                Height = 60,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold),  //Varsayılan sistem fontu
                ForeColor = Color.DarkRed,
            };

            //Yaratılan nesneleri (RAM' yarattığımız new'leri) ekrana basıyoruz.
            Controls.Add(_languageLabel);
            Controls.Add(_languageComboBox);
            Controls.Add(_promptLabel);
            Controls.Add(_complaintTextBox);
            Controls.Add(_solveButton);
            Controls.Add(_historyButton);
            Controls.Add(_resultLabel);
        }

        //object? sender, EventArgs e — bu imza WinForms'taki standart event handler kalıbı. sender olayı tetikleyen kontrolü işaret eder (burada ComboBox), e olayla ilgili ek bilgi taşır. Biz ikisini de kullanmıyoruz ama imzayı böyle yazmak zorundayız çünkü SelectedIndexChanged event'i bu şekli bekliyor — parametre isimlerini değiştirebiliriz ama tipleri/sayısı sabit.
        private void OnLanguageChanged(object sender, EventArgs e)
        {
            _currentLanguage = _languageComboBox.SelectedIndex switch //burada eski switch statement'ından farklı, yeni nesil switch expression kullanıyoruz (C# 8+)
            {
                0 => Language.Turkish,
                1 => Language.English,
                2 => Language.German,
                _ => Language.Turkish,
            };
            ApplyLanguage(); //çağırıyoruz — bütün kontrollerin metnini yeni seçilen dile göre günceller.
        }
        private void ApplyLanguage()
        {
            Text = Localization.Get(Localization.WindowTitle, _currentLanguage);
            _languageLabel.Text = Localization.Get(Localization.LanguageLabel, _currentLanguage);
            _promptLabel.Text = Localization.Get(Localization.PromptLabel, _currentLanguage);
            _solveButton.Text = Localization.Get(Localization.SolveButton, _currentLanguage);
            _historyButton.Text = Localization.Get(Localization.HistoryButton, _currentLanguage);
        }
        private void OnSolveClicked(object? sender, EventArgs e)
        {
            var complaint = _complaintTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(complaint))
            {
                _resultLabel.ForeColor = Color.DarkOrange;
                _resultLabel.Text = Localization.Get(Localization.EmptyInputWarning, _currentLanguage);
                return;
            }
            ComplaintStore.AddComplaint(complaint);

            _complaintTextBox.Clear();
            _resultLabel.ForeColor = Color.DarkRed;
            _resultLabel.Text = Localization.Get(Localization.ResultMessage, _currentLanguage);
        }
        private void OnHistoryClicked(object? sender, EventArgs e)
        {
            using var historyForm = new HistoryForm(_currentLanguage);
            historyForm.ShowDialog(this);
        }
        private void OnComplaintTextBoxEnter(object? sender, EventArgs e)
        {
            _resultLabel.Text = string.Empty;
        }
    }
}
