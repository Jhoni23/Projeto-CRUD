using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Frmlogin : Form
    {

        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public Frmlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conexao);
                    
                string email, senha;

                email = textBox1.Text;
                senha = textBox2.Text;

                string sql = @"select * from tb_usuarios where email = @email and senha = @senha";

                MySqlCommand executacmd = new MySqlCommand(sql, con);

                executacmd.Parameters.AddWithValue("@email", email);
                executacmd.Parameters.AddWithValue("@senha", senha);

                con.Open();

                MySqlDataReader dr = executacmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Bem vindo ao Sistema!");
                }

                else
                {
                    MessageBox.Show("Dados incorretos, tente novamente");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
    }
}
