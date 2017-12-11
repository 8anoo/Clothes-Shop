using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Management;




namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
        }



        #region For Button Login
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1" && textBox2.Text == "1")
            {
                this.Hide();



                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("خطأ فى اسم المستخدم أو الرقم السرى");
                textBox1.Text = textBox2.Text = "";
            }
        } 
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

            skinEngine1.SkinFile = "DiamondBlue.ssk";

            //#region الصلاحيه
            //string serial = "";
            //ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");

            //foreach (ManagementObject mob in mo.Get())
            //{

            //    try
            //    {

            //        serial = mob["ProcessorId"].ToString();

            //    }

            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.ToString());

            //    }
            //}
            //if (serial != Properties.Settings.Default.serial)
            //{
            //    MessageBox.Show(" عفوآ لا تملك الصلاحية لفتح البرنامج \n يمكنك الاتصال بهذا الرقم للإسفسار 01094025755 ");
            //    Environment.Exit(0);
            //}
            //#endregion



            if(!CheckDatabase_Exists())
            {
                Generate_DataBase();
            }



        }


        private bool CheckDatabase_Exists()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=clothes_shop;Integrated Security=True");
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Generate_DataBase()
        {
            List<string> cmds = new List<string>();
            if (File.Exists(Application.StartupPath + "\\script.sql"))
            {
                TextReader tr = new StreamReader(Application.StartupPath + "\\script.sql");
                string line = "";
                string cmd = "";
                while ((line = tr.ReadLine()) != null)
                {
                    if (line.Trim().ToUpper() == "GO")
                    {
                        cmds.Add(cmd);
                        cmd = "";
                    }
                    else
                    {
                        cmd += line + "\r\n";
                    }
                }

                if (cmd.Length > 0)
                {
                    cmds.Add(cmd);
                    cmd = "";
                }
                tr.Close();
            }

            if (cmds.Count > 0)
            {
                SqlCommand command = new SqlCommand();

                command.Connection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=master;Integrated Security=True");
                command.CommandType = System.Data.CommandType.Text;
                command.Connection.Open();
                for (int i = 0; i < cmds.Count; i++)
                {
                    command.CommandText = cmds[i];
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
