using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace CLIR_Book_A_Seat
{
    public partial class signup : System.Web.UI.Page
    {
        //connects to database
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLIR_DB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            signupsubmit_btn.Enabled = false;
        }

        //hashing function
        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        protected void dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDept = dept.SelectedValue;
            prog.Items.Clear(); //clear existing selections

            //populate the program dropdown based on the selected department
            switch (selectedDept)
            {
                case "CAS":
                    prog.Items.Add(new ListItem("COMM"));
                    prog.Items.Add(new ListItem("MMA"));
                    break;
                case "CCIS":
                    prog.Items.Add(new ListItem("CS"));
                    prog.Items.Add(new ListItem("IT"));
                    break;
                case "CHS":
                    prog.Items.Add(new ListItem("BIO"));
                    prog.Items.Add(new ListItem("BSN"));
                    prog.Items.Add(new ListItem("ENVS"));
                    prog.Items.Add(new ListItem("PSY"));
                    break;
                case "CMET":
                    prog.Items.Add(new ListItem("MarE"));
                    prog.Items.Add(new ListItem("MT"));
                    break;
                case "ETYCB":
                    prog.Items.Add(new ListItem("ACT"));
                    prog.Items.Add(new ListItem("AIS"));
                    prog.Items.Add(new ListItem("BIA"));
                    prog.Items.Add(new ListItem("FM"));
                    prog.Items.Add(new ListItem("GM"));
                    prog.Items.Add(new ListItem("HM"));
                    prog.Items.Add(new ListItem("MKT"));
                    prog.Items.Add(new ListItem("OM"));
                    prog.Items.Add(new ListItem("TM"));
                    break;
                case "MIA":
                    prog.Items.Add(new ListItem("AEE"));
                    prog.Items.Add(new ListItem("AMT"));
                    break;
                case "MITL":
                    prog.Items.Add(new ListItem("AR"));
                    prog.Items.Add(new ListItem("CE"));
                    prog.Items.Add(new ListItem("CHE"));
                    prog.Items.Add(new ListItem("COE"));
                    prog.Items.Add(new ListItem("ECE"));
                    prog.Items.Add(new ListItem("EE"));
                    prog.Items.Add(new ListItem("IE"));
                    prog.Items.Add(new ListItem("ME"));
                    break;
                case "SHS":
                    prog.Items.Add(new ListItem("ABM"));
                    prog.Items.Add(new ListItem("HE"));
                    prog.Items.Add(new ListItem("HUMMS"));
                    prog.Items.Add(new ListItem("ICT"));
                    prog.Items.Add(new ListItem("PBM"));
                    prog.Items.Add(new ListItem("STEM"));
                    break;
            }
        }
        //registers user into user_accounts
        protected void signupsubmit_btn_Click(object sender, EventArgs e)
        {
            signup_lbl.Text = "";
            try
            {
                if (studnum_txt.Text.Length == 10)
                {
                    if (pass_txt.Text.Length >= 8) {
                        long studentNumber = long.Parse(studnum_txt.Text);
                        string studentName = studname_txt.Text;
                        string department = dept.SelectedValue;
                        string program = prog.SelectedValue;
                        string yearLevel = year.SelectedValue;
                        if (pass_txt.Text != confpass_txt.Text)
                        {
                            signup_lbl.Text = "Password doesn't match";
                        }
                        else
                        {
                            string hashedPassword = HashPassword(pass_txt.Text);
                            string query = "INSERT INTO user_accounts (studentNumber, studentName, department, program, yearLevel, hashedPassword) VALUES (@studentNumber, @studentName, @department, @program, @yearLevel, @hashedPassword);";
                            using (SqlCommand registerUser = new SqlCommand(query, connection))
                            {
                                registerUser.Parameters.AddWithValue("@studentNumber", studentNumber);
                                registerUser.Parameters.AddWithValue("@studentName", studentName);
                                registerUser.Parameters.AddWithValue("@department", department);
                                registerUser.Parameters.AddWithValue("@program", program);
                                registerUser.Parameters.AddWithValue("@yearLevel", yearLevel);
                                registerUser.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                                connection.Open();

                                int rowsAffected = registerUser.ExecuteNonQuery();  //execute query

                                if (rowsAffected > 0)
                                {
                                    Response.Redirect("main.aspx");  //redirect on successful insertion
                                }
                                else
                                {
                                    signup_lbl.Text = "Failed to register. Please try again.";
                                }
                            }
                        }

                    } else
                    {
                        signup_lbl.Text = "Password must be at least 8 characters.";
                    }
                }
                else
                {
                    signup_lbl.Text = "Student number must be 10 digits.";
                }
            }
            catch (Exception ex)
            {
                signup_lbl.Text = "An error occured, please try again.";
            }
        }

        protected void back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}