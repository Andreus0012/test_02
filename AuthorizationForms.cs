using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Exam
{
    public partial class AuthorizationForms : Form
    {

        DataBase database = new DataBase();
        public AuthorizationForms()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Log_inButton_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String passwordUser = passwordField.Text;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataBase db = new DataBase();
   
            string querystring = $"SELECT login_user, password_user FROM users WHERE login_user = '{loginField}' AND password_user = '{passwordField}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли");
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Такого пользователя нет!");
            }


       
            }





        }

        private void AuthorizationForms_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForms frm_sign = new RegistrationForms();
            frm_sign.Show();
            this.Hide();
        }
    }
}
