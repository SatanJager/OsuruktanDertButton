using System;
namespace OsuruktanDertButton
{
    public partial class MainForm : Form
    {
        private Language _currentLanguage = Language.Turkish;

        private ComboBox _languageCombobox = null!;
        private Label _languageLabel = null!;
        private Label _promptLabel = null!;
        private TextBox _complantTextBox = null!;
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
            throw new NotImplementedException();
        }





        private void ApplyLanguage()
        {
            throw new NotImplementedException();
        }

    }
}
