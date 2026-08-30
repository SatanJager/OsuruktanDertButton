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





        private void ApplyLanguage()
        {
            throw new NotImplementedException();
        }

    }
}
