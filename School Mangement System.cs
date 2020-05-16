using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Info st = new Student_Info();
            st.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\osama\source\repos\WindowsFormsApp15\WindowsFormsApp15\Database1.mdf;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            if (username == "")
            {
                errorProvider1.SetError(txtusername, "Name is Missing");
            }
            else if (password == "")
            {
                errorProvider1.SetError(txtpassword, "Password is Missing");
            }

            //else if(username=="1" && password == "osama")
            // {

            //     Student_Info mf = new Student_Info();
            //     mf.Show();
            //     MessageBox.Show("You Login In Successfully");
            // }
           
                string query = "Select * from LoginDB where username ='" + txtusername.Text.Trim() + "'and Password='" + txtpassword.Text.Trim() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Student_Info st = new Student_Info();
                    st.Show();
                    this.Hide();
                }
         
            
            


                //SqlDataAdapter da =new SqlDataAdapter("Select count(*) FROM LoginForm Where Username='"+txtusername.Text+"',Password='"+txtpassword.Text+"'",conn);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //if (dt.Rows[0][0].ToString() =="1")
                //{
                //    this.Hide();
                //    Student_Info mf = new Student_Info();
                //    mf.Show();
                //    MessageBox.Show("You Login SuccessFully");
                //}
                else
                {
                    MessageBox.Show("Invalid Username & Password");
                }

                //conn.Open();
                //string query = "Select * FROM LoginForm";
                //SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //conn.Close();
            }

            private void txtpassword_TextChanged(object sender, EventArgs e)
            {

            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../download.png");


            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    } 
