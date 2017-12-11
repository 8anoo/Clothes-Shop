using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class restore : Form
    {

        public static SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=master;Integrated Security=True");

        public restore()
        {
            InitializeComponent();
        }

        private void restore_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Backup files (*.bak) | *.bak";
            if (op.ShowDialog() == DialogResult.OK)
            {
                con.Close();
                //SqlCommand ccmmdd = new SqlCommand("ALTER Database clothes_shop SET OFFLINE WITH ROLLBACK IMMEDIATE;", con);
                //con.Open();
                //ccmmdd.ExecuteNonQuery();
                //con.Close();
                //alter database clothes_shop set offline with rollback immediate; 
                //;alter database clothes_shop set online with rollback immediate
                //  alter database clothes_shop set offline with rollback immediate;Restore Database clothes_shop From Disk ='" + op.FileName + "';alter database clothes_shop set online with rollback immediate
                SqlCommand cmd = new SqlCommand("alter database clothes_shop set single_user with rollback immediate ; Restore Database clothes_shop From Disk ='" + op.FileName + "' with replace;", con);

                //SqlCommand ccmmdd = new SqlCommand("alter database clothes_shop set online", con);
                //con.Open();
                //ccmmdd.ExecuteNonQuery();
                //con.Close();

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();

                //alter database clothes_shop set offline with rollback immediate; 

                //ALTER Database clothes_shop SET OFFLINE WITH ROLLBACK IMMEDIATE ; 

                

                MessageBox.Show("لقد تم إسترجاع النسخه الإحتياطيه بنجاح \n سوف يغلق البرنامج تلقائياً");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        //    restore re = new restore();
        //    re.Hide();
        //    re.Close();
        }
    }
}
