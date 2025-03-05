using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace CLIR_Book_A_Seat
{
    public partial class index : System.Web.UI.Page
    {
        //connects to database
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLIR_DB"].ConnectionString);

        //hashing function
        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        //verifying hashed password
        static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword); // hash the entered password
            return inputHash == storedHash; // compare with stored hash
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //admin account and password
            Session["adm_uname"] = "admin";
            Session["adm_pass"] = "12345";
        }

        //verifies if account exists/password matches/admin account is logged
        protected void loginsubmit_btn_Click(object sender, EventArgs e)
        {
            string adm_uname = Session["adm_uname"].ToString();
            string adm_pass = Session["adm_pass"].ToString();
            login_lbl.Text = "";
            if (accnum_txt.Text == adm_uname && accpass_txt.Text == adm_pass)
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                try
                {
                    long accountNumber_txt = long.Parse(accnum_txt.Text);
                    string accountPass_txt = accpass_txt.Text;
                    //query for selecting all records from user_accounts
                    string query = "SELECT hashedPassword FROM user_accounts WHERE studentNumber = @accountNumber_txt";
                    //pushers query to the database
                    using (SqlCommand checkAccount = new SqlCommand(query, connection))
                    {
                        //prevents sql injection
                        checkAccount.Parameters.AddWithValue("@accountNumber_txt", accountNumber_txt);
                        //opens connection to database
                        connection.Open();
                        //execute the query and get the data reader
                        using (SqlDataReader reader = checkAccount.ExecuteReader())
                        {
                            //checks if the record exists
                            if (reader.Read())
                            {
                                //stores data in the column as variable
                                string accountPass = reader.GetString(reader.GetOrdinal("hashedPassword"));
                                //verifies is password matches
                                if (VerifyPassword(accountPass_txt, accountPass))
                                {
                                    Session["userNumber"] = accountNumber_txt;
                                    Session["userPassword"] = accountPass_txt;
                                    //redirects into admin page
                                    Response.Redirect("userpage.aspx");
                                } else
                                {
                                    login_lbl.Text = "Incorrect Password";
                                }
                            }
                            else
                            {
                                login_lbl.Text = "Account number doesn't exist";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    login_lbl.Text = "Invalid student number";
                }
            }
        }
    }
}