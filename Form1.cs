namespace MLTranslatorWinForms
{
    public partial class Form1 : Form
    {
        TranslatorService translator = new TranslatorService();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Lütfen bir metin girin.");
                return;
            }

            string selectedLanguage = cmbLanguage.SelectedItem.ToString();

            string translatedText = await translator.TranslateAsync(inputText, selectedLanguage);

            txtOutput.Text = translatedText;

            lblCategory.Text = "Category: " + ClassifyText(inputText);



        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbLanguage.Items.Add("en");
            cmbLanguage.Items.Add("tr");
            cmbLanguage.SelectedIndex = 0;

       
        
        }

        private string ClassifyText(string text)
        {
            text = text.ToLower();

            if (text.Contains("hello") || text.Contains("merhaba"))
                return "Greeting";

            if (text.Contains("good night") || text.Contains("iyi geceler"))
                return "Farewell";

            return "General";
        }



    }
}
