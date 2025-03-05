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
    public partial class signout : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLIR_DB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

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

        //verifying hashed password
        static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword); // hash the entered password
            return inputHash == storedHash; // compare with stored hash
        }

        protected void signoutsubmit_btn_Click(object sender, EventArgs e)
        {
            string seatCode = Session["seatCode"].ToString();
            //updates seat_info
            string updatequery = "UPDATE seat_info SET seatStatus='Vacant',studentNumber = null, studentName = null, outTime = null WHERE seatCode = @seatCode";
            if (signoutnum_txt.Text == Session["adm_uname"].ToString() && signoutpass_txt.Text == Session["adm_pass"].ToString())
            {
                //need to return seat state
                using (SqlCommand seatUpdate = new SqlCommand(updatequery, connection))
                {
                    connection.Open();
                    Session[seatCode] = "Vacant";
                    seatUpdate.Parameters.AddWithValue("@seatCode", seatCode);
                    seatUpdate.ExecuteNonQuery();
                }
                //redirects into admin page
                Response.Redirect("main.aspx");
            }
            try
            {
                
                long signoutNumber_txt = long.Parse(signoutnum_txt.Text);
                string signoutPass_txt = signoutpass_txt.Text;
                //query for selecting all records from user_accounts
                string checkquery = "SELECT * FROM user_accounts WHERE studentNumber = @signoutNumber_txt";
                //checks current student seated
                string currentquery = "SELECT studentNumber FROM seat_info WHERE seatCode = @seatCode";
                using (SqlCommand currentStudent = new SqlCommand(currentquery, connection))
                {
                    connection.Open();

                    currentStudent.Parameters.AddWithValue("@seatCode", seatCode);
                    using (SqlDataReader seatReader = currentStudent.ExecuteReader())
                    {
                        if (seatReader.Read())
                        {
                            long studentNumber = seatReader.GetInt64(seatReader.GetOrdinal("studentNumber"));
                            if (studentNumber != signoutNumber_txt)
                            {
                                signout_lbl.Text = "Incorrect student number";
                                return;
                            }
                        }
                    }
                    connection.Close();
                }
                //pushes query to the database
                using (SqlCommand checkAccount = new SqlCommand(checkquery, connection))
                {
                    //prevents sql injection
                    checkAccount.Parameters.AddWithValue("@signoutNumber_txt", signoutNumber_txt);
                    //opens connection to database
                    connection.Open();
                    //execute the query and get the data reader
                    using (SqlDataReader reader = checkAccount.ExecuteReader())
                    {
                        //checks if the record exists
                        if (reader.Read())
                        {
                            //stores data in the column as variable
                            string studentName = reader.GetString(reader.GetOrdinal("studentName"));
                            string studentPass = reader.GetString(reader.GetOrdinal("hashedPassword"));
                            reader.Close();
                            //verifies is password matches
                            if (VerifyPassword(signoutPass_txt, studentPass))
                            {
                                using (SqlCommand seatUpdate = new SqlCommand(updatequery, connection))
                                {
                                    Session[seatCode] = "Vacant";
                                    seatUpdate.Parameters.AddWithValue("@seatCode", seatCode);
                                    seatUpdate.ExecuteNonQuery();
                                }
                                //redirects into admin page
                                Response.Redirect("main.aspx");
                            }
                            else
                            {
                                signout_lbl.Text = "Incorrect Password";
                            }
                        }
                        else
                        {
                            signout_lbl.Text = "Account number doesn't exist";
                        }
                    }
                }
            }
        catch (Exception ex)
        {
            signout_lbl.Text = ex.ToString();
        }
        }

        protected void signoutcancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}