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
    public partial class Form4 : Form
    {
        public static SqlConnection con = new SqlConnection(DataManager.constr);
        public Form4()
        {
            InitializeComponent();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Backup Files (*.bak) | *.bak";
            if(sf.ShowDialog()==DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("Backup Database clothes_shop To Disk = '" + sf.FileName + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("لقد تم إنشاء النسخه الإحتياطيه بنجاح");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        //    Form4 f4 = new Form4();
        //    f4.Hide();
        //    f4.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
