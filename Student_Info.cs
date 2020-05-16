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
    public partial class Student_Info : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\osama\source\repos\WindowsFormsApp15\WindowsFormsApp15\Database1.mdf;Integrated Security=True");
        public Student_Info()
        {
            InitializeComponent();
        }

        private void Student_Info_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {

            conn.Open();
            string query = "Select * FROM Student";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string query="DELETE Student WHERE Student_ID='"+txtStudent_ID.Text+"'";
            SqlCommand comm = new SqlCommand(query, conn);

            conn.Open();
            comm.ExecuteNonQuery();
            MessageBox.Show("Student is Deleted Successfully");
            conn.Close();
            RefreshGrid();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
      
            string query="Insert INTO Student values('"+txtStudent_ID.Text+"','"+txtStudentName.Text+"','"+txtStudentAddress.Text+"','"+txtClass.Text+"')";
            SqlCommand comm = new SqlCommand(query,conn);

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Student is Inserted Successfully");
            RefreshGrid();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "update Student Set Student_Name = '"+txtStudentName.Text+"',Student_Address = '"+txtStudentAddress.Text+"', Class = '"+txtClass.Text+"'" +
             "where Student_ID = '"+txtStudent_ID.Text+"' "; 
               
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            RefreshGrid();
            MessageBox.Show("Student is Updated Successfully");
          
        
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
