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

namespace EmpoyeeManagementSystem
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abhin\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" ||EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into EmployeeTbl values('"+EmpIdTb.Text+"','"+EmpNameTb.Text+"','"+EmpAddTb.Text+"','"+EmpPosCb.SelectedItem.ToString()+"','"+EmpDOB.Value.Date+"','"+EmpPhoneTb.Text+"','"+EmpEduCb.SelectedItem.ToString()+"','"+EmpGenCb.SelectedItem.ToString()+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added Succesfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpEduCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
            
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter an Employee ID");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmployeeTbl where EmpId='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdTb.Text = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
            EmpNameTb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpPosCb.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpDOB.Text = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpPhoneTb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpEduCb.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
            EmpGenCb.Text = EmpDGV.SelectedRows[0].Cells[7].Value.ToString();
            
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update EmployeeTbl set EmpName='"+EmpNameTb.Text+"',EmpAdd='"+EmpAddTb.Text+"',EmpPos='"+EmpPosCb.SelectedItem.ToString()+"',EmpDOB='"+EmpDOB.Value.Date+"',EmpPhone='"+EmpPhoneTb.Text+"',EmpEdu='"+EmpEduCb.SelectedItem.ToString()+"',EmpGen='"+EmpGenCb.SelectedItem.ToString()+"'where EmpId='"+EmpIdTb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    Con.Close(); 
                    populate();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }


        }
    }
}
