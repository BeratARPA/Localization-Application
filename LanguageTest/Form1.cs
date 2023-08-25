using System;
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
            comboBox1.Text = "en";
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            button1.Text = GlobalVariables.CultureHelper.GetText("button1");
            button2.Text = GlobalVariables.CultureHelper.GetText("button2");
            button3.Text = GlobalVariables.CultureHelper.GetText("button3");
            radioButton1.Text = GlobalVariables.CultureHelper.GetText("radioButton1");
            checkBox1.Text = GlobalVariables.CultureHelper.GetText("checkBox1");
            label1.Text = GlobalVariables.CultureHelper.GetText("label1");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVariables.CultureHelper.ChangeCulture(comboBox1.Text);
            UpdateUILanguage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(GlobalVariables.CultureHelper.GetText("message"), "Berat ARPA", "21"));
        }
    }
}
