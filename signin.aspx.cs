using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Configuration;


namespace CLIR_Book_A_Seat
{
    public partial class signin : System.Web.UI.Page
    {
        //connects to server
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

        protected void seatsubmit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan currenttime = DateTime.Now.TimeOfDay;
                //adds hour,min,seconds to current time
                TimeSpan outTime = currenttime.Add(new TimeSpan(0, 1, 0));
                string seatCode = Session["seatCode"].ToString();
                string semester = Application["semester"].ToString();
                long studentNumber_txt = long.Parse(seatnum_txt.Text);
                string studentPass_txt = seatpass_txt.Text;
                //query for selecting all records from user_accounts
                string checkquery = "SELECT * FROM user_accounts WHERE studentNumber = @studentNumber";
                //query for inserting new record
                string registerquery = "INSERT user_logs(studentNumber, studentName, department, program, yearLevel,semester, seatCode) SELECT ua.studentNumber, ua.studentName, ua.department, ua.program, ua.yearLevel, @semester, @seatCode FROM user_accounts ua WHERE ua.studentNumber = @studentNumber";
                //updates seat_info
                string updatequery = "UPDATE seat_info SET studentNumber = @studentNumber, studentName = @studentName, seatStatus = 'Occupied', outTime = @outTime WHERE seatCode = @seatCode";
                //checks if the student number is currently logged in
                string existquery = "SELECT * FROM seat_info WHERE studentNumber = @studentNumber";
                //pushers query to the database
                using (SqlCommand checkAccount = new SqlCommand(checkquery, connection))
                {
                    connection.Open();
                    //prevents sql injection
                    checkAccount.Parameters.AddWithValue("@studentNumber", studentNumber_txt);
                    //execute the query and get the data reader
                    using (SqlDataReader reader = checkAccount.ExecuteReader())
                    {
                        //checks if the record exists
                        if (reader.Read())
                        {
                            //stores data in the column as variable
                            long studentNumber = reader.GetInt64(reader.GetOrdinal("studentNumber"));
                            string studentName = reader.GetString(reader.GetOrdinal("studentName"));
                            string studentPass = reader.GetString(reader.GetOrdinal("hashedPassword"));
                            reader.Close();
                            //command for checking if user is already logged
                            using (SqlCommand seatCheck = new SqlCommand(existquery, connection))
                            {
                                seatCheck.Parameters.AddWithValue("@studentNumber", studentNumber);
                                using (SqlDataReader exists = seatCheck.ExecuteReader())
                                {
                                    seatCheck.Parameters.AddWithValue("@studentNumber", studentNumber);
                                    if (exists.Read())
                                    {
                                        seatregister_lbl.Text = "Account is already in use.";
                                        return;
                                    }
                                }
                                //verifies is password matches
                                if (VerifyPassword(studentPass_txt, studentPass))
                                {
                                    using (SqlCommand userLog = new SqlCommand(registerquery, connection))
                                    {
                                        //sets variables used in query
                                        userLog.Parameters.AddWithValue("@studentNumber", studentNumber);
                                        userLog.Parameters.AddWithValue("@semester", semester);
                                        userLog.Parameters.AddWithValue("@seatCode", seatCode);
                                        userLog.ExecuteNonQuery();
                                    }

                                    using (SqlCommand seatUpdate = new SqlCommand(updatequery, connection))
                                    {
                                        Session[seatCode] = "Occupied";
                                        seatUpdate.Parameters.AddWithValue("@studentNumber", studentNumber);
                                        seatUpdate.Parameters.AddWithValue("@studentName", studentName);
                                        seatUpdate.Parameters.AddWithValue("@seatCode", seatCode);
                                        seatUpdate.Parameters.AddWithValue("@outTime", outTime);
                                        seatUpdate.ExecuteNonQuery();
                                    }

                                    //redirects into admin page
                                    Response.Redirect("main.aspx");
                                }
                                else
                                {
                                    seatregister_lbl.Text = "Incorrect Password";
                                    return;
                                }
                            }
                        }
                        else
                        {
                            seatregister_lbl.Text = "Account number doesn't exist";
                            return;
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                seatregister_lbl.Text = "Invalid student number";
            }
        }

        protected void seatcancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}