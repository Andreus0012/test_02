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
    public partial class RegistrationForms : Form
    {
        DataBase database = new DataBase();
        public RegistrationForms()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

          
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForms_Load(object sender, EventArgs e)
        {

        }

        private void sing_upBtn_Click(object sender, EventArgs e)
        {
            DataBase database = new DataBase();
            var login_user = login.Text;
            var password_user = password.Text;
            string querystring = $"insert into users(login_user, password_user) values('{login}', '{password}')";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            database.openConnection();
            if(command.ExecuteNonQuery() ==1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                AuthorizationForms ath = new AuthorizationForms();
                this.Hide();
                ath.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            database.CloseConnection();

        }

        private Boolean checkuser()
        {
            var loginuser = login.Text;
            var passuser = password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id, login_user, password_user from users where login_user = '{loginuser}' and password_user = '{passuser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
