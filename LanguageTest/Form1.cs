using System;
using System.Deployment.Application;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace LanguageTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetLanguage("tr");
            comboBox1.Text = "tr";
        }

        public void SetLanguage(string language)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            button1.Text = Localization.Properties.Resources.button1;
            button2.Text = Localization.Properties.Resources.button2;
            radioButton1.Text = Localization.Properties.Resources.radioButton1;
            checkBox1.Text = Localization.Properties.Resources.checkBox1;
            label1.Text = Localization.Properties.Resources.label1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLanguage(comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationDeployment applicationDeployment = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo updateCheckInfo = applicationDeployment.CheckForDetailedUpdate();
                if (updateCheckInfo.UpdateAvailable)
                {
                    if (MessageBox.Show("Yeni bir sürüm (" + updateCheckInfo.AvailableVersion.ToString() + ") var. Şimdi indirmek ve yeniden başlatmak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (applicationDeployment.Update())
                        {
                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme sırasında hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Son IsPOS sürümünü kullanıyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Sunucuyla bağlantı kurulamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
