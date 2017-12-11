using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        
        

        #region fields
        public static int yy = 0;
        public static string constr = @"Data Source=.\sqlexpress;Initial Catalog=clothes_shop;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(constr); 
        #endregion

        #region initialize form
        public Form2()
        {
            InitializeComponent();
        } 
	#endregion

        #region form load
        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = dateTimePicker4.Value = dateTimePicker5.Value = dateTimePicker6.Value = DateTime.Now;
            comboBox1.SelectedIndex = 0;
            textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = 0.ToString();



            textBox31.Enabled = textBox32.Enabled = false;

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;

            //SqlCommand ccmmdd = new SqlCommand("alter database clothes_shop set online",con);
            //con.Open();
            //ccmmdd.ExecuteNonQuery();
            //con.Close();

            //SqlCommand ccmmddd = new SqlCommand("alter database clothes_shop set online", con);
            //con.Open();
            //ccmmddd.ExecuteNonQuery();
            //con.Close();

            #region fill ComboBoxs
            SqlCommand cmdd = new SqlCommand("select * from mowareden", con);
            con.Open();
            SqlDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Add(drr["m_name"]);
            }

            con.Close();
            //////////////////////////////////////////////////////////////////////////////////
            SqlCommand cmd = new SqlCommand("select * from mowareden", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["m_name"]);
            }

            con.Close();

            //////////////////////////////////////////////////////////////////////////////////
            SqlCommand cmddd = new SqlCommand("select * from asnaf", con);
            con.Open();
            SqlDataReader drrr = cmddd.ExecuteReader();


            while (drrr.Read())
            {
                int x = 0;
                foreach (string item in comboBox3.Items)
                {
                    if (item == drrr["s_name"].ToString())
                    {
                        x = 1;
                        break;
                    }
                }

                if (x == 0)
                {
                    comboBox3.Items.Add(drrr["s_name"]);
                }

            }

            con.Close();

            ///////////////////////////////////////////////////

            SqlCommand cmddds = new SqlCommand("select * from asnaf", con);
            con.Open();
            SqlDataReader drrrs = cmddds.ExecuteReader();


            while (drrrs.Read())
            {
                int x = 0;
                foreach (string item in comboBox6.Items)
                {
                    if (item == drrrs["s_name"].ToString())
                    {
                        x = 1;
                        break;
                    }
                }

                if (x == 0)
                {
                    comboBox6.Items.Add(drrrs["s_name"]);
                }

            }

            con.Close();
            #endregion
            
            
            SqlDataReader drrrr=DataManager.GetDataReader("f_select_fatora_id",out con);
            int t = 0;
            while (drrrr.Read())
            {
                if (t < int.Parse(drrrr["f_number"].ToString()))
                {
                    t = int.Parse(drrrr["f_number"].ToString());
                }

                //textBox26.Text = drrrr["f_number"].ToString();
            }

            t += 36;
            textBox26.Text = t.ToString();
            con.Close();

            


            //////////////////////////////////////////////////////////////////////////////////



                dataGridView4.DataSource = null;
            
                int xx = 0;
                foreach (string item in comboBox6.Items)
                {
                    xx = 0;
                    SqlCommand cmdddss = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrss = cmdddss.ExecuteReader();
                    while(drrrss.Read())
                    {
                        if (item == drrrss["s_name"].ToString())
                        {
                            xx++;
                        }
                    }

                    DataManager.ExecuteNonQuery("m_update_by_name",
                                    new SqlParameter("@m_s_name", item),
                                    new SqlParameter("@m_s_number", xx));

                    con.Close();
                }

                #region new
                SqlCommand cmdcmd = new SqlCommand("select * from message", con);
                con.Open();
                SqlDataReader drdr = cmdcmd.ExecuteReader();
                while (drdr.Read())
                {
                    int tt = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        if (item == drdr["m_s_name"].ToString())
                        {
                            tt = 1;
                            continue;
                        }
                    }
                    if (tt == 0)
                    {
                        string f = drdr["m_s_name"].ToString();

                        DataManager.ExecuteNonQuery("m_delete_by_name",
                                    new SqlParameter("@m_s_name", f));
                    }
                }
                con.Close();
                #endregion

                ////////////////////  fill DataGridView4  ////////////////////////////////////////
                DataSet ds = DataManager.GetDataSet("m_select_all", "x");
                dataGridView4.DataSource = ds.Tables[0];


                textBox34.Text = "";

                SqlDataReader dre = DataManager.GetDataReader("m_select_all_txt", out con);
                while (dre.Read())
                {
                    if (dre.HasRows)
                    {
                        if (int.Parse(dre["m_s_number"].ToString()) < int.Parse(dre["m_s_less_number"].ToString()))
                        {
                            textBox34.Text += "لقد قل ال " + dre["m_s_name"].ToString() + " عن الحد الأدنى -------------";
                        }
                    }

                }

                con.Close();

                
        } 
        #endregion

        #region form closing
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        } 
        #endregion

        #region insert mowareden
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                     //DataManager.ExecuteNonQuery("m_insert",
                     //           new SqlParameter("@m_name", textBox1.Text),
                     //           new SqlParameter("@m_mobile", textBox2.Text),
                     //           new SqlParameter("@m_telephone", textBox3.Text),
                     //           new SqlParameter("@m_facs", textBox4.Text),
                     //           new SqlParameter("@m_e_mail", textBox5.Text),
                     //           new SqlParameter("@m_adress", textBox6.Text),
                     //           new SqlParameter("@m_nashat", textBox7.Text),
                     //           new SqlParameter("@m_draft", textBox8.Text));

                    ////////////////////////////////////////////////////////////////////////////

                     SqlConnection con = new SqlConnection(constr);
                     SqlCommand cmd = new SqlCommand("m_insert", con);

                     cmd.Parameters.Add(new SqlParameter("@m_name", textBox1.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_mobile", textBox2.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_telephone", textBox3.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_facs", textBox4.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_e_mail", textBox5.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_adress", textBox6.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_nashat", textBox7.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_draft", textBox8.Text));
                     cmd.Parameters.Add(new SqlParameter("@m_date", dateTimePicker2.Value));

                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     con.Open();
                     cmd.ExecuteNonQuery();
                     con.Close();

                    ////////////////////////////////////////////////////////////////////////////

                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
                    dateTimePicker2.Value = DateTime.Now;
                    MessageBox.Show("تم حفظ البيانات بنجاح");
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("قم بملئ البيانات الفارغه");
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("عفواٌ لقد قمت بإضافة هذا المورد من قبل");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            }


            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            SqlConnection conn=new SqlConnection(constr);
            SqlCommand cmdd = new SqlCommand("select * from mowareden", conn);
            conn.Open();
            SqlDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                comboBox1.Items.Add(drr["m_name"]);
            }
            
            conn.Close();
            //////////////////////////////////////////////////////////////////////////////////
            SqlCommand cmddd = new SqlCommand("select * from mowareden", conn);
            conn.Open();
            SqlDataReader dr = cmddd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["m_name"]);
            }

            conn.Close();
        } 
        #endregion

        #region tab1 name_textchanged
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        } 
        #endregion

        #region key press
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("غير مسموح بكتابة حروف");
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int x = 1;
                foreach (char item in textBox9.Text)
                {
                    if (item == '.')
                    {
                        x++;
                    }
                }
                if (x > 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int x = 1;
                foreach (char item in textBox10.Text)
                {
                    if (item == '.')
                    {
                        x++;
                    }
                }
                if (x > 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int x = 1;
                foreach (char item in textBox11.Text)
                {
                    if (item == '.')
                    {
                        x++;
                    }
                }
                if (x > 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region إضافة باقى
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("قم بإختيار مورد");
                textBox10.Text = "";
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("قم بملئ المحتوى");
            }
            else
            {
                if (textBox9.Text == "")
                    textBox9.Text = "0";
                if (textBox12.Text == "")
                    textBox12.Text = "0";

                textBox12.Text = (float.Parse(textBox12.Text) + float.Parse(textBox10.Text)).ToString();

                DataManager.ExecuteNonQuery("m_d_insert",
                            new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()),
                            new SqlParameter("@m_sdd", textBox11.Text),
                            new SqlParameter("@m_baky", textBox10.Text),
                            new SqlParameter("@m_mtbky", textBox12.Text),
                            new SqlParameter("@m_date", dateTimePicker4.Value));


                MessageBox.Show("لقد قمت بإضافة باقى مقداره " + float.Parse(textBox10.Text));
                textBox10.Text = "";



                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                string namee = comboBox1.SelectedItem.ToString();

                #region تعديل علبى جدول الموردين
                SqlCommand cmddd = new SqlCommand("m_update_egmaly_mostahak", con);
                ////////
                cmddd.Parameters.Add(new SqlParameter("@m_name", namee));

                cmddd.Parameters.Add(new SqlParameter("@m_egmaly_mostahak", float.Parse(textBox12.Text)));
                cmddd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader dr = cmddd.ExecuteReader();
                con.Close();
                #endregion


                //////////////////////////////////////////////////////////////////////////
                SqlCommand cmd = new SqlCommand("m_select_egmaly_mostahak", con);
                ////////
                cmd.Parameters.Add(new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader drr = cmd.ExecuteReader();

                //SqlDataReader dr= DataManager.GetDataReader("m_select_egmaly_mostahak", out con,
                //                new SqlParameter("@m_name", name));
                if (drr.Read())
                {
                    textBox9.Text = textBox12.Text = drr["m_egmaly_mostahak"].ToString();
                    dateTimePicker3.Value = (DateTime)drr["m_date"];
                }

                con.Close();
                if (textBox9.Text == "")
                    textBox9.Text = 0.ToString();
                if (textBox12.Text == "")
                    textBox12.Text = 0.ToString();

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlCommand cmdd = new SqlCommand("m_d_select_by_name", con);
                cmdd.Parameters.Add(new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()));
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView5.DataSource = dt;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////////////////////////////////////



            }
        }

        #endregion

        #region المبلغ المسدد
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("قم بإختيار مورد");
                textBox11.Text = "";
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("قم بملئ المحتوى");
            }
            else
            {
                if (textBox9.Text == "")
                    textBox9.Text = "0";
                if (textBox12.Text == "")
                    textBox12.Text = "0";

                textBox12.Text = (float.Parse(textBox12.Text) - float.Parse(textBox11.Text)).ToString();

                DataManager.ExecuteNonQuery("m_d_insert",
                            new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()),
                            new SqlParameter("@m_sdd", textBox11.Text),
                            new SqlParameter("@m_baky", textBox10.Text),
                            new SqlParameter("@m_mtbky", textBox12.Text),
                            new SqlParameter("@m_date", dateTimePicker4.Value));

                MessageBox.Show("لقد قمت بالسداد بمقدار  " + float.Parse(textBox11.Text));
                textBox11.Text = "";

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                string namee = comboBox1.SelectedItem.ToString();

                #region تعديل علبى جدول الموردين
                SqlCommand cmddd = new SqlCommand("m_update_egmaly_mostahak", con);
                ////////
                cmddd.Parameters.Add(new SqlParameter("@m_name", namee));

                cmddd.Parameters.Add(new SqlParameter("@m_egmaly_mostahak", float.Parse(textBox12.Text)));
                cmddd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader dr = cmddd.ExecuteReader();
                con.Close();
                #endregion

                //////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlCommand cmd = new SqlCommand("m_select_egmaly_mostahak", con);
                ////////
                cmd.Parameters.Add(new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader drr = cmd.ExecuteReader();

                //SqlDataReader dr= DataManager.GetDataReader("m_select_egmaly_mostahak", out con,
                //                new SqlParameter("@m_name", name));
                if (drr.Read())
                {
                    textBox9.Text = textBox12.Text = drr["m_egmaly_mostahak"].ToString();
                    dateTimePicker3.Value = (DateTime)drr["m_date"];
                }

                con.Close();
                if (textBox9.Text == "")
                    textBox9.Text = 0.ToString();
                if (textBox12.Text == "")
                    textBox12.Text = 0.ToString();

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlCommand cmdd = new SqlCommand("m_d_select_by_name", con);
                cmdd.Parameters.Add(new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()));
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView5.DataSource = dt;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
        }

        #endregion

        #region tab 3 name_combo_select_changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;



            if (comboBox1.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("m_select_egmaly_mostahak", con);
                ////////
                cmd.Parameters.Add(new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                //SqlDataReader dr= DataManager.GetDataReader("m_select_egmaly_mostahak", out con,
                //                new SqlParameter("@m_name", name));
                if (dr.Read())
                {
                    textBox9.Text = textBox12.Text = dr["m_egmaly_mostahak"].ToString();
                    dateTimePicker3.Value = (DateTime)dr["m_date"];
                }

                con.Close();
                if (textBox9.Text == "")
                    textBox9.Text = 0.ToString();
                if (textBox12.Text == "")
                    textBox12.Text = 0.ToString();

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                SqlCommand cmdd = new SqlCommand("m_d_select_by_name",con);
                cmdd.Parameters.Add(new SqlParameter("@m_name", comboBox1.SelectedItem.ToString()));
                cmdd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmdd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView5.DataSource = dt;

                /////////////////////////////////////////////////////////////////////////////////////////////////////////

            }

        } 
        #endregion

        #region tab 3 save_button
        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("قم بإختيار زبون");
                textBox10.Text = "";
            }
            else
            {

                string namee = comboBox1.SelectedItem.ToString();

                #region تعديل علبى جدول الموردين
                SqlCommand cmd = new SqlCommand("m_update_egmaly_mostahak", con);
                ////////
                cmd.Parameters.Add(new SqlParameter("@m_name", namee));

                cmd.Parameters.Add(new SqlParameter("@m_egmaly_mostahak", float.Parse(textBox12.Text)));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                con.Close(); 
                #endregion

                

                MessageBox.Show("لقد تمت عملية الحفظ بنجاح");
                comboBox1.SelectedItem = null;
                textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = "0";
                dateTimePicker3.Value = dateTimePicker3.Value = DateTime.Now;
                dataGridView5.DataSource = null;
            }
        } 
        #endregion

        #region tab 2 delete_button
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("قم بإختيار زبون");
                textBox10.Text = "0";
                textBox11.Text = "0";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("m_delete", con);
                ////////
                cmd.Parameters.Add(new SqlParameter("@m_name", comboBox2.SelectedItem.ToString()));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("لقد تم حذف العنصر بنجاح");

                textBox19.Text = "";
                textBox18.Text = "";
                textBox17.Text = "";
                textBox16.Text = "";
                textBox15.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox21.Text = "";
                comboBox2.SelectedItem = null;

                ///////////////////////////////////////////////

                comboBox1.Items.Clear();
                comboBox2.Items.Clear();

                SqlCommand cmdd = new SqlCommand("select * from mowareden", con);
                con.Open();
                SqlDataReader drr = cmdd.ExecuteReader();

                while (drr.Read())
                {
                    comboBox1.Items.Add(drr["m_name"]);
                }

                con.Close();
                //////////////////////////////////////////////////////////////////////////////////
                SqlCommand cmddd = new SqlCommand("select * from mowareden", con);
                con.Open();
                SqlDataReader dr = cmddd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["m_name"]);
                }

                con.Close();
            }

        } 
        #endregion

        #region tab 2 select to delete
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("m_all_by_name", con);
                ////////
                cmd.Parameters.Add(new SqlParameter("@m_name", comboBox2.SelectedItem.ToString()));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                ////////
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                //SqlDataReader dr= DataManager.GetDataReader("m_select_egmaly_mostahak", out con,
                //                new SqlParameter("@m_name", name));
                if (dr.Read())
                {
                    textBox19.Text = dr["m_mobile"].ToString();
                    textBox18.Text = dr["m_telephone"].ToString();
                    textBox17.Text = dr["m_facs"].ToString();
                    textBox16.Text = dr["m_e_mail"].ToString();
                    textBox15.Text = dr["m_adress"].ToString();
                    textBox14.Text = dr["m_nashat"].ToString();
                    textBox13.Text = dr["m_draft"].ToString();
                    textBox21.Text = dr["m_egmaly_mostahak"].ToString();
                }

                con.Close();
            }
            else
            {
                textBox19.Text = "";
                textBox18.Text = "";
                textBox17.Text = "";
                textBox16.Text = "";
                textBox15.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox21.Text = "";
            }
        } 
        #endregion

        #region tab 4 prize key press
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int x = 1;
                foreach (char item in textBox24.Text)
                {
                    if (item == '.')
                    {
                        x++;
                    }
                }
                if (x > 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("غير مسموح بكتابة حروف");
            }
        }

        #endregion

        #region tab 4 text changed
        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            if (textBox28.Text == "")
            {
                label32.Visible = true;
            }
            else
            {
                label32.Visible = false;
            }
        }
        

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (textBox24.Text == "")
            {
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
            }

            if (textBox24.Text != "" && textBox35.Text != "")
            {
                textBox36.Text = (float.Parse(textBox24.Text) - float.Parse(textBox35.Text)).ToString();
            }
            
        }

        #endregion
        /*Complete*/
        #region tab 4 add_button
        private void button6_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (comboBox3.Text != ""&&textBox24.Text!=""&&textBox28.Text!="")
                {
                    //DataManager.ExecuteNonQuery("m_insert",
                    //           new SqlParameter("@m_name", textBox1.Text),
                    //           new SqlParameter("@m_mobile", textBox2.Text),
                    //           new SqlParameter("@m_telephone", textBox3.Text),
                    //           new SqlParameter("@m_facs", textBox4.Text),
                    //           new SqlParameter("@m_e_mail", textBox5.Text),
                    //           new SqlParameter("@m_adress", textBox6.Text),
                    //           new SqlParameter("@m_nashat", textBox7.Text),
                    //           new SqlParameter("@m_draft", textBox8.Text));

                    ////////////////////////////////////////////////////////////////////////////

                    SqlConnection con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand("s_insert", con);

                    cmd.Parameters.Add(new SqlParameter("@s_code", textBox28.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_name", comboBox3.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_maqas", comboBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_color", textBox25.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_prize", textBox24.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_gomla", textBox35.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_maksab", textBox36.Text));
                    cmd.Parameters.Add(new SqlParameter("@s_mol", textBox37.Text));
                    

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    ////////////////////////////////////////////////////////////////////////////

                    int x = 0;
                    foreach (var item in comboBox3.Items)
                    {
                        if (comboBox3.Text == item.ToString())
                        {
                            x = 1;
                            continue;
                        }
                    }

                    if (x == 0)
                    {
                        MessageBox.Show("لقد قمت بإضافة عنصر جديد");
                    }

                    textBox37.Text = textBox28.Text = textBox25.Text = textBox24.Text = "";
                    comboBox3.SelectedItem = comboBox4.SelectedItem = null;
                    comboBox3.Text = comboBox4.Text = "";
                    textBox24.Text = textBox35.Text = textBox36.Text = 0.ToString();
                    

                    MessageBox.Show("تم حفظ البيانات بنجاح");

                    

                    ///////////////////////////////////////

                    #region for combo
                    SqlCommand cmddd = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrr = cmddd.ExecuteReader();


                    while (drrr.Read())
                    {
                        int xo = 0;
                        foreach (string item in comboBox3.Items)
                        {
                            if (item == drrr["s_name"].ToString())
                            {
                                xo = 1;
                                break;
                            }
                        }

                        if (xo == 0)
                        {
                            comboBox3.Items.Add(drrr["s_name"]);
                        }

                    }

                    con.Close();

                    ///////////////////////////////////////////////////

                    SqlCommand cmddds = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrs = cmddds.ExecuteReader();


                    while (drrrs.Read())
                    {
                        int xoo = 0;
                        foreach (string item in comboBox6.Items)
                        {
                            if (item == drrrs["s_name"].ToString())
                            {
                                xoo = 1;
                                break;
                            }
                        }

                        if (xoo == 0)
                        {
                            comboBox6.Items.Add(drrrs["s_name"]);
                        }

                    }

                    con.Close(); 
                    #endregion

                    ///////////////////////////////////////

                    #region for message
                    dataGridView4.DataSource = null;

                    int xx = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        xx = 0;
                        SqlCommand cmdddss = new SqlCommand("select * from asnaf", con);
                        con.Open();
                        SqlDataReader drrrss = cmdddss.ExecuteReader();
                        while (drrrss.Read())
                        {
                            if (item == drrrss["s_name"].ToString())
                            {
                                xx++;
                            }
                        }

                        DataManager.ExecuteNonQuery("m_update_by_name",
                                        new SqlParameter("@m_s_name", item),
                                        new SqlParameter("@m_s_number", xx));

                        con.Close();
                    }

                    #region new
                    SqlCommand cmdcmd = new SqlCommand("select * from message", con);
                    con.Open();
                    SqlDataReader drdr = cmdcmd.ExecuteReader();
                    while (drdr.Read())
                    {
                        int tt = 0;
                        foreach (string item in comboBox6.Items)
                        {
                            if (item == drdr["m_s_name"].ToString())
                            {
                                tt = 1;
                                continue;
                            }
                        }
                        if (tt == 0)
                        {
                            string f = drdr["m_s_name"].ToString();

                            DataManager.ExecuteNonQuery("m_delete_by_name",
                                        new SqlParameter("@m_s_name", f));
                        }
                    }
                    con.Close();
                    #endregion

                    ////////////////////  fill DataGridView4  ////////////////////////////////////////
                    DataSet ds = DataManager.GetDataSet("m_select_all", "x");
                    dataGridView4.DataSource = ds.Tables[0];
                    #endregion

                    ///////////////////////////////////////

                    #region textbox34 for messages
                    textBox34.Text = "";

                    SqlDataReader dre = DataManager.GetDataReader("m_select_all_txt", out con);
                    while (dre.Read())
                    {
                        if (dre.HasRows)
                        {
                            if (int.Parse(dre["m_s_number"].ToString()) < int.Parse(dre["m_s_less_number"].ToString()))
                            {
                                textBox34.Text += "لقد قل ال " + dre["m_s_name"].ToString() + " عن الحد الأدنى -------------";
                            }
                        }

                    }

                    con.Close(); 
                    #endregion


                    textBox28.Focus();
                }
                else
                {
                    MessageBox.Show("قم بملئ البيانات الفارغه");
                    textBox28.Focus();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());

            //}

            /////////////////////////////////////////

                #region the combo 3 ممكن نقول متكرره
                comboBox3.Items.Clear();
                comboBox3.Items.Add("--------");

                SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=clothes_shop;Integrated Security=True");
                SqlCommand cmdddq = new SqlCommand("select * from asnaf", conn);
                conn.Open();
                SqlDataReader drrrq = cmdddq.ExecuteReader();

                while (drrrq.Read())
                {
                    int x = 0;
                    foreach (string item in comboBox3.Items)
                    {
                        if (item == drrrq["s_name"].ToString())
                        {
                            x = 1;
                            break;
                        }
                    }

                    if (x == 0)
                    {
                        comboBox3.Items.Add(drrrq["s_name"]);
                    }

                } 
                #endregion

            conn.Close();
        } 
        #endregion

        #region tab 5 add another
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
                textBox20.Text = 0.ToString();
            if (textBox41.Text == "")
                textBox41.Text = 0.ToString();


            if (textBox23.Text == "" || textBox26.Text == "")
            {
                MessageBox.Show("قم بوضع كود الصنف و رقم الفاتوره");
                textBox23.Focus();
            }
            else
            {
                SqlDataReader dr = DataManager.GetDataReader("f_select_by_s_id", out con,
                            new SqlParameter("@s_code", textBox23.Text));


                if (dr.HasRows == false)
                {
                    MessageBox.Show("لايوجد هذا الصنف \n حاول إدخال كود الصنف صحيح");
                    textBox23.Text = "";

                    con.Close();
                }
                else
                {
                    con.Close();

                    try
                    {
                        yy = 1;
                        ///////////////////////////////////////////////////////////////////////////////
                        DataManager.ExecuteNonQuery("f_insert",
                                        new SqlParameter("@f_number", textBox26.Text),
                                        new SqlParameter("@f_s_code", textBox23.Text),
                                        new SqlParameter("@f_s_name", textBox27.Text),
                                        new SqlParameter("@f_s_maqas", textBox29.Text),
                                        new SqlParameter("@f_s_color", textBox22.Text),
                                        new SqlParameter("@f_s_prize", textBox20.Text),
                                        new SqlParameter("@f_date", dateTimePicker1.Value),
                                        new SqlParameter("@f_s_gomla", textBox38.Text),
                                        new SqlParameter("@f_s_maksab", textBox39.Text),
                                        new SqlParameter("@f_s_mol", textBox40.Text));

                        //////////////////////////////////////////
                        DataManager.ExecuteNonQuery("s_delete",
                                        new SqlParameter("@s_code", textBox23.Text));

                        //DataSet ds= DataManager.GetDataSet("f_select_all_by_f_number", "fatora",
                        //            new SqlParameter("@f_number", textBox26.Text));

                        SqlCommand cmd = new SqlCommand("f_select_all_by_f_number", con);

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@f_number", textBox26.Text));

                        con.Open();

                        //SqlDataReader dr = cmd.ExecuteReader();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dataGridView1.DataSource = dt;

                        con.Close();

                        //////////////////////////////////////////

                        textBox41.Text = (float.Parse(textBox41.Text) + float.Parse(textBox20.Text)).ToString();

                        /////////////////////////////////////////

                        textBox23.Text = "";
                        textBox27.Text = "";
                        textBox29.Text = "";
                        textBox22.Text = "";
                        textBox20.Text = "0";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                textBox23.Focus();
            }

            

        }
        #endregion
        //complete
        #region tab 5 TextBox_changed
        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox23.Text == "")
                {
                    label34.Visible = true;
                    textBox27.Text = "";
                    textBox29.Text = "";
                    textBox22.Text = "";
                    textBox20.Text = "";
                    textBox38.Text = "";
                    textBox39.Text = "";
                    textBox40.Text = "";
                }
                else
                {
                    label34.Visible = false;
                    SqlDataReader dr = DataManager.GetDataReader("f_select_by_s_id", out con,
                                new SqlParameter("@s_code", textBox23.Text));
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            textBox27.Text = dr["s_name"].ToString();
                            textBox29.Text = dr["s_maqas"].ToString();
                            textBox22.Text = dr["s_color"].ToString();
                            textBox20.Text = dr["s_prize"].ToString();
                            textBox38.Text = dr["s_gomla"].ToString();
                            textBox39.Text = dr["s_maksab"].ToString();
                            textBox40.Text = dr["s_mol"].ToString();
                        }
                    }
                    else
                    {
                        textBox27.Text = "";
                        textBox29.Text = "";
                        textBox22.Text = "";
                        textBox20.Text = "";
                        textBox38.Text = "";
                        textBox39.Text = "";
                        textBox40.Text = "";
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        } 
        #endregion

        #region tab 5 key press
        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button7.PerformClick();

                
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("غير مسموح بكتابة حروف");
            }

            
        } 
        #endregion

        #region tab 5 save without print
        private void button8_Click(object sender, EventArgs e)
        {
            int y = 0;
            if (yy == 1)
            {


                //SqlDataReader drrrr = DataManager.GetDataReader("f_select_fatora_id", out con);
                //while (drrrr.Read())
                //{
                //    x = int.Parse(drrrr["f_number"].ToString());

                //    //textBox26.Text = drrrr["f_number"].ToString();
                //}
                //con.Close();

                #region new fatora number
                if (999999954 > int.Parse(textBox26.Text))
                {
                    dataGridView1.DataSource = null;
                    y = int.Parse(textBox26.Text) + 36;
                    textBox26.Text = y.ToString();
                }
                else
                {
                    DataManager.ExecuteNonQuery("f_delete_number");
                    DataManager.ExecuteNonQuery("f_insert_f_number");

                    dataGridView1.DataSource = null;
                    y = 1021;
                    textBox26.Text = y.ToString();
                } 
                #endregion

                


                yy = 0;

                

                comboBox3.Items.Clear();
                comboBox6.Items.Clear();

                #region for combo 6
                SqlCommand cmddd = new SqlCommand("select * from asnaf", con);
                con.Open();
                SqlDataReader drrr = cmddd.ExecuteReader();


                while (drrr.Read())
                {
                    int xo = 0;
                    foreach (string item in comboBox3.Items)
                    {
                        if (item == drrr["s_name"].ToString())
                        {
                            xo = 1;
                            break;
                        }
                    }

                    if (xo == 0)
                    {
                        comboBox3.Items.Add(drrr["s_name"]);
                    }

                }

                con.Close();

                ///////////////////////////////////////////////////

                SqlCommand cmddds = new SqlCommand("select * from asnaf", con);
                con.Open();
                SqlDataReader drrrs = cmddds.ExecuteReader();


                while (drrrs.Read())
                {
                    int xoo = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        if (item == drrrs["s_name"].ToString())
                        {
                            xoo = 1;
                            break;
                        }
                    }

                    if (xoo == 0)
                    {
                        comboBox6.Items.Add(drrrs["s_name"]);
                    }

                }

                con.Close();
                #endregion

                ///////////////////////////////////////

                ///////////////////////

                #region for message
                dataGridView4.DataSource = null;

                int xx = 0;
                foreach (string item in comboBox6.Items)
                {
                    xx = 0;
                    SqlCommand cmdddss = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrss = cmdddss.ExecuteReader();
                    while (drrrss.Read())
                    {
                        if (item == drrrss["s_name"].ToString())
                        {
                            xx++;
                        }
                    }

                    DataManager.ExecuteNonQuery("m_update_by_name",
                                    new SqlParameter("@m_s_name", item),
                                    new SqlParameter("@m_s_number", xx));

                    con.Close();
                }

                #region new
                SqlCommand cmdcmd = new SqlCommand("select * from message", con);
                con.Open();
                SqlDataReader drdr = cmdcmd.ExecuteReader();
                while (drdr.Read())
                {
                    int tt = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        if (item == drdr["m_s_name"].ToString())
                        {
                            tt = 1;
                            continue;
                        }
                    }
                    if (tt == 0)
                    {
                        string f = drdr["m_s_name"].ToString();

                        DataManager.ExecuteNonQuery("m_delete_by_name",
                                    new SqlParameter("@m_s_name", f));
                    }
                }
                con.Close();
                #endregion

                ////////////////////  fill DataGridView4  ////////////////////////////////////////
                DataSet ds = DataManager.GetDataSet("m_select_all", "x");
                dataGridView4.DataSource = ds.Tables[0];
                #endregion

                ///////////////////////

                #region textbox34 for messages
                textBox34.Text = "";

                SqlDataReader dre = DataManager.GetDataReader("m_select_all_txt", out con);
                while (dre.Read())
                {
                    if (dre.HasRows)
                    {
                        if (int.Parse(dre["m_s_number"].ToString()) < int.Parse(dre["m_s_less_number"].ToString()))
                        {
                            textBox34.Text += "لقد قل ال " + dre["m_s_name"].ToString() + " عن الحد الأدنى -------------";
                        }
                    }

                }

                con.Close();
                #endregion

                MessageBox.Show("تمت عملية البيع بنجاح");
                dateTimePicker1.Value = DateTime.Now;
                textBox41.Text = 0.ToString();
                textBox23.Focus();
            }
            else
            {
                MessageBox.Show("قم بإضافة أصناف للبيع");
                textBox23.Focus();
            }

        } 
        #endregion

        #region tab 6 return fatora
        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            if(textBox30.Text=="")
            {
                dataGridView2.DataSource = null;
                textBox42.Text = 0.ToString();
            }
            else
            {
                if(textBox42.Text=="")
                    textBox42.Text=0.ToString();
                //SqlDataReader dr= DataManager.GetDataReader("f_select_all_by_f_number", out con,
                //                new SqlParameter("@f_number", textBox30.Text));

                SqlCommand cmd = new SqlCommand("f_select_all_by_f_number", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@f_number", textBox30.Text));

                con.Open();

                //SqlDataReader dr = cmd.ExecuteReader();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView2.DataSource = dt;

                con.Close();

                foreach (DataRow item in dt.Rows)
                {
                    textBox42.Text = (float.Parse(textBox42.Text) + float.Parse(item[3].ToString())).ToString();
                }

                //if (dt.Rows == null)
                //    textBox42.Text = 0.ToString();


                /**/
                SqlDataReader dr = DataManager.GetDataReader("f_select_all_by_f_number", out con,
                                new SqlParameter("@f_number", textBox30.Text));
                    if (!dr.HasRows)
                    {
                        textBox42.Text = 0.ToString();
                    }
                    con.Close();
                 /**/
            }
        } 
        #endregion

        #region tab 6 cancel
        private void button11_Click(object sender, EventArgs e)
        {
            textBox30.Text = "";
            dataGridView2.DataSource = null;
            textBox30.Focus();
        }
        #endregion

        #region tab 6 cancel selling
        private void button10_Click(object sender, EventArgs e)
        {

            if (textBox30.Text == "")
            {
                
                MessageBox.Show("قم بإدخال رقم الفاتوره أولا");
                textBox30.Focus();
            }
            else
            {
                SqlDataReader dr = DataManager.GetDataReader("f_select_all_by_f_number", out con,
                                new SqlParameter("@f_number", textBox30.Text));

                if (dr.HasRows)
                {
                    //while (dr.Read())
                    //{
                    //    //DataManager.ExecuteNonQuery("s_insert",
                    //    //                new SqlParameter("@s_code", (int)(dr["f_s_code"])),
                    //    //                new SqlParameter("@s_name", dr["f_s_name"].ToString()),
                    //    //                new SqlParameter("@s_maqas", dr["f_s_maqas"].ToString()),
                    //    //                new SqlParameter("@s_color", dr["f_s_color"].ToString()),
                    //    //                new SqlParameter("@s_prize", dr["f_s_prize"].ToString()));


                    //    //SqlCommand cmd = new SqlCommand("s_insert", con);

                    //    //cmd.Parameters.Add(new SqlParameter("@s_code", dr["f_s_code"]));
                    //    //cmd.Parameters.Add(new SqlParameter("@s_name", dr["f_s_name"]));
                    //    //cmd.Parameters.Add(new SqlParameter("@s_maqas", dr["f_s_maqas"]));
                    //    //cmd.Parameters.Add(new SqlParameter("@s_color", dr["f_s_color"]));
                    //    //cmd.Parameters.Add(new SqlParameter("@s_prize", dr["f_s_prize"]));

                    //    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //    //con.Open();
                    //    //cmd.ExecuteNonQuery();
                    //    //con.Close();
                    //}

                    con.Close();


                    /////////////////////////////////////////

                    SqlCommand cmd = new SqlCommand("f_select_all_by_f_number", con);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@f_number", textBox30.Text));

                    con.Open();

                    //SqlDataReader dr = cmd.ExecuteReader();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    con.Close();

                    foreach (DataRow item in dt.Rows)
                    {
                        DataManager.ExecuteNonQuery("s_insert",
                                        new SqlParameter("@s_code", item[0]),
                                        new SqlParameter("@s_name", item[1]),
                                        new SqlParameter("@s_maqas", ""),
                                        new SqlParameter("@s_color", item[2]),
                                        new SqlParameter("@s_prize", item[3]),
                                        new SqlParameter("@s_gomla", item[4]),
                                        new SqlParameter("@s_maksab", item[5]),
                                        new SqlParameter("@s_mol", item[7]));
                    }


                    ////////////////////////////////////////


                    DataManager.ExecuteNonQuery("f_delete_by_f_number",
                                    new SqlParameter("@f_number", textBox30.Text));


                    #region fill ComboBoxs
                    SqlCommand cmdd = new SqlCommand("select * from mowareden", con);
                    con.Open();
                    SqlDataReader drr = cmdd.ExecuteReader();

                    while (drr.Read())
                    {
                        comboBox1.Items.Add(drr["m_name"]);
                    }

                    con.Close();
                    //////////////////////////////////////////////////////////////////////////////////
                    SqlCommand cmddd = new SqlCommand("select * from mowareden", con);
                    con.Open();
                    SqlDataReader drrr = cmddd.ExecuteReader();

                    while (drrr.Read())
                    {
                        comboBox2.Items.Add(drrr["m_name"]);
                    }

                    con.Close();

                    //////////////////////////////////////////////////////////////////////////////////
                    SqlCommand cmdddd = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrr = cmdddd.ExecuteReader();


                    while (drrrr.Read())
                    {
                        int x = 0;
                        foreach (string item in comboBox3.Items)
                        {
                            if (item == drrrr["s_name"].ToString())
                            {
                                x = 1;
                                break;
                            }
                        }

                        if (x == 0)
                        {
                            comboBox3.Items.Add(drrrr["s_name"]);
                        }

                    }

                    con.Close();

                    #endregion

                    ///////////////////////


                    #region for combo 6
                    SqlCommand cmdddq = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrq = cmdddq.ExecuteReader();


                    while (drrrq.Read())
                    {
                        int xo = 0;
                        foreach (string item in comboBox3.Items)
                        {
                            if (item == drrrq["s_name"].ToString())
                            {
                                xo = 1;
                                break;
                            }
                        }

                        if (xo == 0)
                        {
                            comboBox3.Items.Add(drrr["s_name"]);
                        }

                    }

                    con.Close();

                    ///////////////////////////////////////////////////

                    SqlCommand cmddds = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrs = cmddds.ExecuteReader();


                    while (drrrs.Read())
                    {
                        int xoo = 0;
                        foreach (string item in comboBox6.Items)
                        {
                            if (item == drrrs["s_name"].ToString())
                            {
                                xoo = 1;
                                break;
                            }
                        }

                        if (xoo == 0)
                        {
                            comboBox6.Items.Add(drrrs["s_name"]);
                        }

                    }

                    con.Close();
                    #endregion

                    ///////////////////////////////////////

                    #region for message
                    dataGridView4.DataSource = null;

                    int xx = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        xx = 0;
                        SqlCommand cmdddss = new SqlCommand("select * from asnaf", con);
                        con.Open();
                        SqlDataReader drrrss = cmdddss.ExecuteReader();
                        while (drrrss.Read())
                        {
                            if (item == drrrss["s_name"].ToString())
                            {
                                xx++;
                            }
                        }

                        DataManager.ExecuteNonQuery("m_update_by_name",
                                        new SqlParameter("@m_s_name", item),
                                        new SqlParameter("@m_s_number", xx));

                        con.Close();
                    }

                    #region new
                    SqlCommand cmdcmd = new SqlCommand("select * from message", con);
                    con.Open();
                    SqlDataReader drdr = cmdcmd.ExecuteReader();
                    while (drdr.Read())
                    {
                        int tt = 0;
                        foreach (string item in comboBox6.Items)
                        {
                            if (item == drdr["m_s_name"].ToString())
                            {
                                tt = 1;
                                continue;
                            }
                        }
                        if (tt == 0)
                        {
                            string f = drdr["m_s_name"].ToString();

                            DataManager.ExecuteNonQuery("m_delete_by_name",
                                        new SqlParameter("@m_s_name", f));
                        }
                    }
                    con.Close();
                    #endregion

                    ////////////////////  fill DataGridView4  ////////////////////////////////////////
                    DataSet ds = DataManager.GetDataSet("m_select_all", "x");
                    dataGridView4.DataSource = ds.Tables[0];
                    #endregion

                    ///////////////////////////////////////


                    #region textbox34 for messages
                    textBox34.Text = "";

                    SqlDataReader dre = DataManager.GetDataReader("m_select_all_txt", out con);
                    while (dre.Read())
                    {
                        if (dre.HasRows)
                        {
                            if (int.Parse(dre["m_s_number"].ToString()) < int.Parse(dre["m_s_less_number"].ToString()))
                            {
                                textBox34.Text += "لقد قل ال " + dre["m_s_name"].ToString() + " عن الحد الأدنى -------------";
                            }
                        }

                    }

                    con.Close();
                    #endregion


                    MessageBox.Show("لقد تمت عملية إلغاء البيع بنجاح");

                    textBox30.Text = "";
                    dataGridView2.DataSource = null;
                    textBox30.Focus();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("لا توجد هذه الفاتوره");
                    textBox30.Focus();
                }
            }
        } 
        #endregion

        #region tab 6 key press
        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("غير مسموح بكتابة حروف");
            }
        } 
        #endregion

        #region search by name or id
        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                if(textBox31.Text!="")
                {
                    SqlCommand cmd = new SqlCommand("s_select_by_s_name", con);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@s_name", textBox31.Text));

                    con.Open();

                    //SqlDataReader dr = cmd.ExecuteReader();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView3.DataSource = dt;

                    con.Close();
                }
                else
                {
                    dataGridView3.DataSource = null;
                }
                
            }
        } 
        #endregion

        #region select name or ParCode
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                textBox32.Enabled = false;
                textBox32.Text = "";
                textBox31.Enabled = true;
                textBox31.Focus();
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                textBox32.Enabled = true;
                textBox32.Focus();
                textBox31.Enabled = false;
                textBox31.Text = "";
            }
        } 
        #endregion

        #region key press for tab search
        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("غير مسموح بكتابة حروف");
            }
        } 
        #endregion
        //complete
        #region select ParCode
        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            if (textBox32.Text != "")
            {
                SqlCommand cmd = new SqlCommand("f_select_by_s_id_t_1", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@s_code", textBox32.Text));

                con.Open();

                //SqlDataReader dr = cmd.ExecuteReader();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView3.DataSource = dt;

                con.Close();
            }
            else
            {
                dataGridView3.DataSource = null;
            }
        } 
        #endregion


        #region print
        private void button9_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = true;

            int c = 0;
            int y = 0;
            if (yy == 1)
            {

                


                //SqlDataReader drrrr = DataManager.GetDataReader("f_select_fatora_id", out con);
                //while (drrrr.Read())
                //{
                //    x = int.Parse(drrrr["f_number"].ToString());

                //    //textBox26.Text = drrrr["f_number"].ToString();
                //}
                //con.Close();

                #region new fatora number
                if (999999954 > int.Parse(textBox26.Text))
                {
                    c = int.Parse(textBox26.Text);

                    dataGridView1.DataSource = null;
                    y = int.Parse(textBox26.Text) + 36;
                    textBox26.Text = y.ToString();
                }
                else
                {
                    c = int.Parse(textBox26.Text);

                    DataManager.ExecuteNonQuery("f_delete_number");
                    DataManager.ExecuteNonQuery("f_insert_f_number");

                    dataGridView1.DataSource = null;
                    y = 1021;
                    textBox26.Text = y.ToString();
                }
                #endregion




                yy = 0;

                

                comboBox3.Items.Clear();
                comboBox6.Items.Clear();

                #region for combo 6
                SqlCommand cmddd = new SqlCommand("select * from asnaf", con);
                con.Open();
                SqlDataReader drrr = cmddd.ExecuteReader();


                while (drrr.Read())
                {
                    int xo = 0;
                    foreach (string item in comboBox3.Items)
                    {
                        if (item == drrr["s_name"].ToString())
                        {
                            xo = 1;
                            break;
                        }
                    }

                    if (xo == 0)
                    {
                        comboBox3.Items.Add(drrr["s_name"]);
                    }

                }

                con.Close();

                ///////////////////////////////////////////////////

                SqlCommand cmddds = new SqlCommand("select * from asnaf", con);
                con.Open();
                SqlDataReader drrrs = cmddds.ExecuteReader();


                while (drrrs.Read())
                {
                    int xoo = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        if (item == drrrs["s_name"].ToString())
                        {
                            xoo = 1;
                            break;
                        }
                    }

                    if (xoo == 0)
                    {
                        comboBox6.Items.Add(drrrs["s_name"]);
                    }

                }

                con.Close();
                #endregion


                ///////////////////////

                #region for message
                dataGridView4.DataSource = null;

                int xx = 0;
                foreach (string item in comboBox6.Items)
                {
                    xx = 0;
                    SqlCommand cmdddss = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrss = cmdddss.ExecuteReader();
                    while (drrrss.Read())
                    {
                        if (item == drrrss["s_name"].ToString())
                        {
                            xx++;
                        }
                    }

                    DataManager.ExecuteNonQuery("m_update_by_name",
                                    new SqlParameter("@m_s_name", item),
                                    new SqlParameter("@m_s_number", xx));

                    con.Close();
                }

                #region new
                SqlCommand cmdcmd = new SqlCommand("select * from message", con);
                con.Open();
                SqlDataReader drdr = cmdcmd.ExecuteReader();
                while (drdr.Read())
                {
                    int tt = 0;
                    foreach (string item in comboBox6.Items)
                    {
                        if (item == drdr["m_s_name"].ToString())
                        {
                            tt = 1;
                            continue;
                        }
                    }
                    if (tt == 0)
                    {
                        string f = drdr["m_s_name"].ToString();

                        DataManager.ExecuteNonQuery("m_delete_by_name",
                                    new SqlParameter("@m_s_name", f));
                    }
                }
                con.Close();
                #endregion

                ////////////////////  fill DataGridView4  ////////////////////////////////////////
                DataSet ds = DataManager.GetDataSet("m_select_all", "x");
                dataGridView4.DataSource = ds.Tables[0];
                #endregion

                ///////////////////////

                Form3 f3 = new Form3();

                
                
                SqlDataAdapter da = new SqlDataAdapter("select * from fatora where f_number='" + c + "'", con);
                da.Fill(f3.clothes_shopDataSet.fatora);
                f3.reportViewer1.RefreshReport();

                f3.ShowDialog();



                #region textbox34 for messages
                textBox34.Text = "";

                SqlDataReader dre = DataManager.GetDataReader("m_select_all_txt", out con);
                while (dre.Read())
                {
                    if (dre.HasRows)
                    {
                        if (int.Parse(dre["m_s_number"].ToString()) < int.Parse(dre["m_s_less_number"].ToString()))
                        {
                            textBox34.Text += "لقد قل ال " + dre["m_s_name"].ToString() + " عن الحد الأدنى -------------";
                        }
                    }

                }

                con.Close();
                #endregion

                

                ///////////////////////////////////////

                MessageBox.Show("تمت عملية البيع بنجاح");

                ///////////////////////////////////////

                //pictureBox1.Visible = false;

                textBox23.Focus();
            }
            else
            {
                

                MessageBox.Show("قم بإضافة أصناف للبيع");

                //pictureBox1.Visible = false;
                textBox23.Focus();
            }

            textBox23.Focus();
        } 
        #endregion

        #region key press for tab message
        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                MessageBox.Show("غير مسموح بكتابة حروف");
            }
        } 
        #endregion

        #region tab message ComboBox change
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr = DataManager.GetDataReader("m_select_all_by_s_name", out con,
                            new SqlParameter("@m_s_name", comboBox6.Text));
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBox33.Text = dr["m_s_less_number"].ToString();
                }
            }
            con.Close();
        } 
        #endregion

        #region tab message button save
        private void button12_Click(object sender, EventArgs e)
        {

            if (comboBox6.Text == "" || textBox33.Text == "")
            {
                MessageBox.Show("قم بملئ الفراغات");
            }
            else
            {
                
                int y= DataManager.ExecuteNonQuery("m_update_by_name_for_less_number",
                            new SqlParameter("@m_s_name", comboBox6.Text),
                            new SqlParameter("@m_s_less_number", textBox33.Text));

                if(y==0)
                {
                    SqlDataReader dr =DataManager.GetDataReader("s_select_by_s_name",out con,
                                    new SqlParameter("@s_name",comboBox6.Text));
                    int x=0;
                    if(dr.HasRows)
                    {
                        
                        while(dr.Read())
                        {
                            x++;
                        }
                    }
                    con.Close();

                    DataManager.ExecuteNonQuery("m_insert_all",
                                    new SqlParameter("@m_s_name", comboBox6.Text),
                                    new SqlParameter("@m_s_number", x),
                                    new SqlParameter("@m_s_less_number", textBox33.Text));
                }

                MessageBox.Show("لقد تم حفظ البيانات بنجاح");

                comboBox6.SelectedItem = null;
                textBox33.Text = "";

                ///////////////////////////////////////

                #region for message
                dataGridView4.DataSource = null;

                int xx = 0;
                foreach (string item in comboBox6.Items)
                {
                    xx = 0;
                    SqlCommand cmdddss = new SqlCommand("select * from asnaf", con);
                    con.Open();
                    SqlDataReader drrrss = cmdddss.ExecuteReader();
                    while (drrrss.Read())
                    {
                        if (item == drrrss["s_name"].ToString())
                        {
                            xx++;
                        }
                    }

                    DataManager.ExecuteNonQuery("m_update_by_name",
                                    new SqlParameter("@m_s_name", item),
                                    new SqlParameter("@m_s_number", xx));

                    con.Close();
                }

                ////////////////////  fill DataGridView4  ////////////////////////////////////////
                DataSet ds = DataManager.GetDataSet("m_select_all", "x");
                dataGridView4.DataSource = ds.Tables[0];
                #endregion

                ///////////////////////////////////////

                textBox34.Text = "";

                SqlDataReader dre = DataManager.GetDataReader("m_select_all_txt", out con);
                while(dre.Read())
                {
                    if(dre.HasRows)
                    {
                        if (int.Parse(dre["m_s_number"].ToString()) < int.Parse(dre["m_s_less_number"].ToString()))
                        {
                            textBox34.Text += "لقد قل ال " + dre["m_s_name"].ToString() + " عن الحد الأدنى -------------";
                        }
                    }
                    
                }

                con.Close();
                ///////////////////////////////////////
            }




        } 
        #endregion

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
            //this.InvokePaint(dataGridView4, myPaintArgs);

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                restore re = new restore();
                re.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = 0.ToString();
            dataGridView5.DataSource = null;
            dateTimePicker3.Value = dateTimePicker4.Value = DateTime.Now;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            if (textBox35.Text == "")
            {
                label46.Visible = true;
            }
            else
            {
                label46.Visible = false;
            }

            if (textBox24.Text != "" && textBox35.Text != "")
            {
                textBox36.Text = (float.Parse(textBox24.Text) - float.Parse(textBox35.Text)).ToString();
            }
            
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            if (textBox36.Text == "")
            {
                label48.Visible = true;
            }
            else
            {
                label48.Visible = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int x = 1;
                foreach (char item in textBox35.Text)
                {
                    if (item == '.')
                    {
                        x++;
                    }
                }
                if (x > 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int x = 1;
                foreach (char item in textBox36.Text)
                {
                    if (item == '.')
                    {
                        x++;
                    }
                }
                if (x > 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            textBox43.Text = 0.ToString();

            DataSet ds = DataManager.GetDataSet("f_select_gard", "x",
                        new SqlParameter("@f_s_date", dateTimePicker5.Value),
                        new SqlParameter("@f_f_date", dateTimePicker6.Value));

            dataGridView6.DataSource = ds.Tables["x"];

            foreach (DataRow item in ds.Tables["x"].Rows)
            {
                textBox43.Text = (float.Parse(textBox43.Text) + float.Parse(item[4].ToString())).ToString();
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            dateTimePicker5.Value = dateTimePicker6.Value = DateTime.Now;
            dataGridView6.DataSource = null;
            textBox43.Text = 0.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select s_code'  كود الصنف  ' , s_name'  إسم الصنف  ' , s_color'  لون الصنف  ' , s_prize'  السعر  ' , s_gomla'  سعر الجمله  ' , s_maksab'  المكسب  ' , s_mol'  الملاحظات  ' from asnaf", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView7.DataSource = dt;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView7.DataSource = null;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        

       
    }
}
