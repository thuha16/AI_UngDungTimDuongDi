using System;
using System.Windows.Forms;
using Python.Runtime;

namespace GTX_TimDuongDi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Runtime.PythonDLL = @"C:\Users\Desk\AppData\Local\Programs\Python\Python310\python310.dll";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        private void StartApp_Click(object sender, EventArgs e)
        {
            Form2 mainForm = new Form2();
            this.Hide();
            mainForm.ShowDialog();
        }
    }
}