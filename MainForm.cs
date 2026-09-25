using System;
using System.Data;
//using System.Drawing.Drawing2D; //Eski button için lazım

namespace OsuruktanDertButton
{
    public partial class MainForm : Form
    {
        private Language _currentLanguage = Language.Turkish;

        private ComboBox _languageComboBox = null!;
        private ComboBox _themeComboBox = null!;
        private Label _languageLabel = null!;
        private Label _promptLabel = null!;
        private TextBox _complaintTextBox = null!;
        //private Button _solveButton = null!;  // Eski button
        private BigRedButton _solveButton = null!; // Yeni button
        private Button _historyButton = null!;
        private Label _resultLabel = null!;

        public MainForm()
        {
            InitializeUi();
            ApplyLanguage();
            Themes.ThemeChanged += OnThemeChangedGlobally;
            ApplyTheme();
        }

        private void InitializeUi()
        {
            Text = Localization.Get(Localization.WindowTitle, _currentLanguage);  //Percerenin başlık çubuğunda gözüke yazı
            Icon = new Icon(Path.Combine(AppContext.BaseDirectory, "AppIcon.ico"));
            Width = 480;
            Height = 480;
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

            _themeComboBox = new ComboBox
            {
                Left = 250,
                Top = 12,
                Width = 150,
                DropDownStyle= ComboBoxStyle.DropDownList,
            };
            PopulateThemeComboBoxItems();
            _themeComboBox.SelectedIndexChanged += OnThemeChanged;

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
            _complaintTextBox.KeyDown += OnComplaintTextBoxKeyDown;
            _complaintTextBox.TextChanged += OnComplaintTextBoxTextChanged;

            // Eski tuş:
            //_solveButton = new Button
            //{
            //    Left = 185,
            //    Top = 215,
            //    Width = 110,
            //    Height = 110,
            //};
            //_solveButton.Click += OnSolveClicked; //SolveButton'a basılınca OnSolveClicked metodu başlayacak

            ////Solve button'u daire yapıyoruz.
            //_solveButton.FlatStyle = FlatStyle.Flat;
            //_solveButton.FlatAppearance.BorderSize = 0;
            //_solveButton.BackColor = Color.Firebrick;
            //_solveButton.ForeColor = Color.White;
            //_solveButton.Font = new Font(Font.FontFamily, 11, FontStyle.Bold);

            //var solveButtonPath = new GraphicsPath();
            //solveButtonPath.AddEllipse(0, 0, _solveButton.Width, _solveButton.Height);
            //_solveButton.Region = new Region(solveButtonPath);

            _solveButton = new BigRedButton
            {
                Left = 185,
                Top = 215,
                Width = 110,
                Height = 110,
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, 11, FontStyle.Bold),
            };
            _solveButton.Click += OnSolveClicked; //SolveButton'a basılınca OnSolveClicked metodu başlayacak

            _historyButton = new Button
            {
                Left = 140,
                Top = 345,
                Width= 200,
                Height = 40,
            };
            _historyButton.Click += OnHistoryClicked; //HistoryButton basıldığında OnHistoryClicked metodu başlayacak
            _historyButton.FlatStyle = FlatStyle.Flat;

            _resultLabel = new Label
            {
                Left = 20,
                Top = 400,
                Width = 430,
                Height = 60,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold),  //Varsayılan sistem fontu
                ForeColor = Color.DarkRed,
            };

            //Yaratılan nesneleri (RAM' yarattığımız new'leri) ekrana basıyoruz.
            Controls.Add(_languageLabel);
            Controls.Add(_languageComboBox);
            Controls.Add(_themeComboBox);
            Controls.Add(_promptLabel);
            Controls.Add(_complaintTextBox);
            Controls.Add(_solveButton);
            Controls.Add(_historyButton);
            Controls.Add(_resultLabel);
        }

        private void PopulateThemeComboBoxItems()
        {
            var previousIndex = _themeComboBox.SelectedIndex;

            _themeComboBox.Items.Clear();
            _themeComboBox.Items.Add(Localization.Get(Localization.ThemeRetroClassicName, _currentLanguage));
            _themeComboBox.Items.Add(Localization.Get(Localization.ThemeDarkName, _currentLanguage));
            _themeComboBox.Items.Add(Localization.Get(Localization.ThemeLightName, _currentLanguage));

            _themeComboBox.SelectedIndex = previousIndex >= 0 ? previousIndex : 0;
        }

        //object? sender, EventArgs e — bu imza WinForms'taki standart event handler kalıbı. sender olayı tetikleyen kontrolü işaret eder (burada ComboBox), e olayla ilgili ek bilgi taşır. Biz ikisini de kullanmıyoruz ama imzayı böyle yazmak zorundayız çünkü SelectedIndexChanged event'i bu şekli bekliyor — parametre isimlerini değiştirebiliriz ama tipleri/sayısı sabit.
        private void OnLanguageChanged(object? sender, EventArgs e)
        {
            _currentLanguage = _languageComboBox.SelectedIndex switch //burada eski switch statement'ından farklı, yeni nesil switch expression kullanıyoruz (C# 8+)
            {
                0 => Language.Turkish,
                1 => Language.English,
                2 => Language.German,
                _ => Language.Turkish,
            };
            ApplyLanguage(); //çağırıyoruz — bütün kontrollerin metnini yeni seçilen dile göre günceller.
            PopulateThemeComboBoxItems(); // dil değiştiğinde thema combobox'u güncellenir
        }
        private void OnThemeChanged(object? sender, EventArgs e)
        {
            var selectedTheme = _themeComboBox.SelectedIndex switch
            {
                0 => AppTheme.RetroClassic,
                1 => AppTheme.Dark,
                2 => AppTheme.Light,
                _ => AppTheme.RetroClassic,
            };
            Themes.SetTheme(selectedTheme);
        }
        private void OnThemeChangedGlobally(object? sender, EventArgs e)
        {
            ApplyTheme();
        }
        private void ApplyTheme()
        {
            var colors = Themes.Current;

            BackColor = colors.FormBackColor;
            _languageLabel.ForeColor = colors.LabelForeColor;
            _promptLabel.ForeColor = colors.LabelForeColor;
            _complaintTextBox.BackColor = colors.TextBoxBackColor;
            _complaintTextBox.ForeColor = colors.TextBoxForeColor;

            _historyButton.BackColor = colors.SecondaryButtonBackColor;
            _historyButton.ForeColor = colors.SecondaryButtonTextColor;

            _solveButton.LightFaceColor = colors.ButtonFaceLight;
            _solveButton.DarkFaceColor = colors.ButtonFaceDark;
            _solveButton.ForeColor = colors.ButtonTextColor;
            _solveButton.Invalidate();
        }
        private void ApplyLanguage()
        {
            Text = $"{Localization.Get(Localization.WindowTitle, _currentLanguage)} v{AppInfo.Version}";
            _languageLabel.Text = Localization.Get(Localization.LanguageLabel, _currentLanguage);
            _promptLabel.Text = Localization.Get(Localization.PromptLabel, _currentLanguage);
            _solveButton.Text = Localization.Get(Localization.SolveButton, _currentLanguage);
            _historyButton.Text = Localization.Get(Localization.HistoryButton, _currentLanguage);
        }
        private void OnSolveClicked(object? sender, EventArgs e)
        {
            var complaint = _complaintTextBox.Text.Trim();
            complaint = complaint.Replace("\r\n", " ").Replace("\n", " ");

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
        private void OnComplaintTextBoxKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift && !e.Control) // Shiftli ve Ctrlli Enter değilse çalış
            {
                e.SuppressKeyPress = true;
                _solveButton.PerformClick();
            }
        }
        private void OnComplaintTextBoxTextChanged(object? sender, EventArgs e)
        {
            if (_resultLabel.Text != string.Empty)
            {
                _resultLabel.Text = string.Empty;
            }
        }
    }
}
