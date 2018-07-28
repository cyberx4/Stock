using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TO-DO: CheckLogin username & Password
            SqlConnection con = new SqlConnection(@"Data Source=PRENOSNIK\SQLEXPRESS;Initial Catalog=NiceLabel;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM[dbo].[Login] WHERE Username = '"+textBox1.Text+"' and Password ='"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    StockMain main = new StockMain();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username & Password..|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
               
        }
    }
}
