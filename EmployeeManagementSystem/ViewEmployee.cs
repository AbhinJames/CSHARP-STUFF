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

namespace EmployeeManagementSystem
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhin\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FetchEmpData()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where EmpId='" + EmpIdTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmpIdlbl.Text = dr["EmpId"].ToString();
                EmpNamelbl.Text = dr["EmpName"].ToString();
                EmpAddlbl.Text = dr["EmpAdd"].ToString();
                EmpPoslbl.Text = dr["EmpPos"].ToString();
                EmpDOBlbl.Text = dr["EmpDOB"].ToString();
                EmpPhonelbl.Text = dr["EmpPhone"].ToString();
                EmpEdulbl.Text = dr["EmpEdu"].ToString();
                EmpGenlbl.Text = dr["EmpGen"].ToString();

                EmpIdlbl.Visible = true;
                EmpNamelbl.Visible = true; 
                EmpAddlbl.Visible = true; 
                EmpPoslbl.Visible = true;
                EmpDOBlbl.Visible = true;
                EmpPhonelbl.Visible = true;
                EmpEdulbl.Visible = true;
                EmpGenlbl.Visible = true;

            }
            Con.Close();
        }

        private void ViewEmployee_Load(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Please enter a valid Employee ID!");
            }
            else
            {
                FetchEmpData();
            }
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======Employee Summary======", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(Top));
            e.Graphics.DrawString("Employee ID: "+EmpIdlbl.Text+"\t Employee Name: "+EmpNamelbl.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20,100));
            e.Graphics.DrawString("Employee Address: " + EmpAddlbl.Text + "\t Gender: " + EmpGenlbl.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 150));
            e.Graphics.DrawString("Employee Position: " + EmpPoslbl.Text + "\t Date Of Birth: " + EmpDOBlbl.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 200));
            e.Graphics.DrawString("Phone: " + EmpPhonelbl.Text + "\t Education: " + EmpEdulbl.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 250));
            e.Graphics.DrawString("======EmpHub======", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(190,300));
        }
    }
}
