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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhin\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FetchEmpData()
        {

            if(EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter a valid Employee ID!");
            }
            else
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

                    EmpNameTb.Text = dr["EmpName"].ToString();
                    EmpPosTb.Text = dr["EmpPos"].ToString();


                }
                Con.Close();
            }
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Salary_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            FetchEmpData();
        }
        int Dailybase,total;

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("======SALARY SLIP======", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(Top));
            e.Graphics.DrawString("Employee ID: " + EmpIdTb.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 100));
            e.Graphics.DrawString("Employee Name: " + EmpNameTb.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 150));
            e.Graphics.DrawString("Employee Position: " + EmpPosTb.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 200));
            e.Graphics.DrawString("Days Worked: " + WorkedTb.Text, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 250));
            e.Graphics.DrawString("Daily Base Salary: " + Dailybase, new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 300));
            e.Graphics.DrawString("Total Salary: " + total,new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Navy, new Point(20, 350));
            e.Graphics.DrawString("======EmpHub======", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(190, 400));
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpPosTb.Text == "")
            {
                MessageBox.Show("Select an Employee!");
            }
            else if (WorkedTb.Text =="" || Convert.ToInt32(WorkedTb.Text) > 28)
            {
                MessageBox.Show("Enter a Valid Number of Days!");
            }
            else
            {
                if (EmpPosTb.Text == "Manager")
                {
                    Dailybase = 1200;
                }
                else if (EmpPosTb.Text == "Senior Developer")
                {
                    Dailybase = 1000;
                }
                else if (EmpPosTb.Text == "Junior Developer")
                {
                    Dailybase = 950;
                }
                else
                {
                    Dailybase = 850;
                }
                total = Dailybase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = " Employee ID = "+EmpIdTb.Text + "\n Employee Name = " + EmpNameTb.Text + "\n Employee Position = " + EmpPosTb.Text + "\n Number of Days Worked = " + WorkedTb.Text + "\n Daily Base Salary = " + Dailybase + "\n Salary Total = " + total;
            }

        }
    }
}
