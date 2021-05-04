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
    }
}
