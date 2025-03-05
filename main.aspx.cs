using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
namespace CLIR_Book_A_Seat
{
    public partial class main : System.Web.UI.Page
    {
        //connects to database
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLIR_DB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //admin account and password
            Session["adm_uname"] = "admin";
            Session["adm_pass"] = "12345";
            if (!IsPostBack)
            {
                //session semester is a variable which can be accessed through multiple pages
                if (Application["semester"] != null)
                {
                    //sets selected value to session
                    semester.SelectedValue = Application["semester"].ToString();
                }
                else
                {
                    //sets default value if session is null
                    semester.SelectedValue = "1";  //default semester
                    Application["semester"] = "1";
                }
                InitializeSeatStatus();
                autoOut();
            }
            Response.AddHeader("Refresh", "5");
        }

        //updates seat status every 5 seconds depending on changes within the database
        private void InitializeSeatStatus()
        {
            string query = "SELECT * FROM seat_info";
            using (SqlCommand checkStatus = new SqlCommand(query, connection)) 
            {
                connection.Open();
                using (SqlDataReader reader = checkStatus.ExecuteReader())
                {
                    //iterates through all results
                    while (reader.Read())
                    {
                        string seatCode = reader.GetString(reader.GetOrdinal("seatCode"));
                        string seatStatus = reader.GetString(reader.GetOrdinal("seatStatus"));
                        var seatControl = FindControl(seatCode) as Button;
                        if (seatStatus == "Vacant")
                        {
                            Session[seatCode] = "Vacant";
                            seatControl.BackColor = ColorTranslator.FromHtml("#00CC66"); //green
                        } else
                        {
                            //checks if the time out is met or not
                            Session[seatCode] = "Occupied";
                            long studentNumber = reader.GetInt64(reader.GetOrdinal("studentNumber"));
                            TimeSpan rawTime = reader.GetTimeSpan(reader.GetOrdinal("outTime"));
                            DateTime outTime = DateTime.Today.Add(rawTime);
                            if (DateTime.Now > outTime)
                            {
                                seatControl.Text = seatCode+"\nTime's up!\n"+studentNumber;
                                seatControl.Font.Size = 7;
                                seatControl.ForeColor = ColorTranslator.FromHtml("#fd4141");
                                seatControl.BackColor = ColorTranslator.FromHtml("#FFFFFF"); 
                                seatControl.BorderColor = ColorTranslator.FromHtml("#fd4141"); // Red
                            }
                            else
                            {
                                seatControl.Text = seatCode+"\n"+outTime.ToString("h:mm tt")+"\n"+studentNumber;
                                seatControl.Font.Size = 7;
                                seatControl.BackColor = ColorTranslator.FromHtml("#db4b4b"); // Red
                                seatControl.BorderColor = ColorTranslator.FromHtml("#FA8080");
                            }
                            seatControl.BorderWidth = 3;
                        }
                    }
                    reader.Close();
                }
            }
        }

        //proper redirection
        private void CheckSeatStatus()
        {
            if (Session[Session["seatCode"].ToString()].ToString() == "Vacant")
            {
                Response.Redirect("signin.aspx");
            } else
            {
                Response.Redirect("signout.aspx");
            }
        }


        //updates semester on the user_logs
        protected void semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Application["semester"] = semester.SelectedValue;
                connection.Open();
                string query = "ALTER TABLE user_logs ALTER COLUMN semester SET DEFAULT @semester";
                using (SqlCommand booking = new SqlCommand(query, connection))
                {
                    connection.Open();
                    booking.Parameters.AddWithValue("@semester", semester.SelectedValue);
                    booking.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //errors
            }
        }
        //auto sign out agter certain period of time
        private void autoOut()
        {
            TimeSpan finalTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 0, -30));
            string outquery = "UPDATE seat_info SET studentNumber = null, studentName = null, seatStatus = 'Vacant', outTime = null WHERE outTime < @finalTime";
            using(SqlCommand outCommand = new SqlCommand(outquery, connection))
            {
                outCommand.Parameters.AddWithValue("@finalTime", finalTime);
                outCommand.ExecuteNonQuery();
            }
        }

        protected void records_Click(object sender, EventArgs e)
        {
            Response.Redirect("records.aspx");
        }

        protected void signup_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        //logs out of admin account, automatically vacates all seats
        protected void logout_btn_Click(object sender, EventArgs e)
        {
            string outquery = "UPDATE seat_info SET studentNumber = null, studentName = null, seatStatus = 'Vacant', outTime = null";
            using (SqlCommand outCommand = new SqlCommand(outquery, connection))
            {
                connection.Open();
                outCommand.ExecuteNonQuery();
            }
            Response.Redirect("index.aspx");
        }

        //event handling for every button instance
        protected void btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Session["seatCode"] = clickedButton.ID;
            CheckSeatStatus();
        }

       
    }
}