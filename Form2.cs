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
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var type = TextBox1.text;
            var type = TextBox1.text;
            var type = TextBox1.text;
            var price = TextBox1.text;

            if(int.TryParse(textbox_price.Text, out price))
            {
                var addquery = $"isert into test (водим поля в дб) values ('{}', и тд)";
                var command = newsqlcommand(addquery, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!");
            }
            else
            {
                MessageBox.Show("Запись не удалось создать!");
            }
            dataBase.CloseConnection();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
