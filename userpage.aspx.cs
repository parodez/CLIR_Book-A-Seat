using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLIR_Book_A_Seat
{
    public partial class userpage : System.Web.UI.Page
    {
        //connects to database
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLIR_DB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = qr_ID.Value;
            //checks qr id then performs code
            switch (id)
            {
                case "C_01":
                    Session["seatCode"] = "C_01";
                    seatLogin();
                    break;
                case "C_02":
                    Session["seatCode"] = "C_02";
                    seatLogin();
                    break;
                case "C_03":
                    Session["seatCode"] = "C_03";
                    seatLogin();
                    break;
                case "C_04":
                    Session["seatCode"] = "C_04";
                    seatLogin();
                    break;
                case "C_05":
                    Session["seatCode"] = "C_05";
                    seatLogin();
                    break;
                case "C_06":
                    Session["seatCode"] = "C_06";
                    seatLogin();
                    break;
                case "C_07":
                    Session["seatCode"] = "C_07";
                    seatLogin();
                    break;
                case "C_08":
                    Session["seatCode"] = "C_08";
                    seatLogin();
                    break;
                case "C_09":
                    Session["seatCode"] = "C_09";
                    seatLogin();
                    break;
                case "C_10":
                    Session["seatCode"] = "C_10";
                    seatLogin();
                    break;
                case "C_11":
                    Session["seatCode"] = "C_11";
                    seatLogin();
                    break;
                case "C_12":
                    Session["seatCode"] = "C_12";
                    seatLogin();
                    break;
                case "C_13":
                    Session["seatCode"] = "C_13";
                    seatLogin();
                    break;
                case "C_14":
                    Session["seatCode"] = "C_14";
                    seatLogin();
                    break;
                case "C_15":
                    Session["seatCode"] = "C_15";
                    seatLogin();
                    break;
                case "C_16":
                    Session["seatCode"] = "C_16";
                    seatLogin();
                    break;
                case "C_17":
                    Session["seatCode"] = "C_17";
                    seatLogin();
                    break;
                case "C_18":
                    Session["seatCode"] = "C_18";
                    seatLogin();
                    break;
                case "C_19":
                    Session["seatCode"] = "C_19";
                    seatLogin();
                    break;
                case "C_20":
                    Session["seatCode"] = "C_20";
                    seatLogin();
                    break;
                case "C_21":
                    Session["seatCode"] = "C_21";
                    seatLogin();
                    break;
                case "C_22":
                    Session["seatCode"] = "C_22";
                    seatLogin();
                    break;
                case "C_23":
                    Session["seatCode"] = "C_23";
                    seatLogin();
                    break;
                case "C_24":
                    Session["seatCode"] = "C_24";
                    seatLogin();
                    break;
                case "C_25":
                    Session["seatCode"] = "C_25";
                    seatLogin();
                    break;
                case "C_26":
                    Session["seatCode"] = "C_26";
                    seatLogin();
                    break;
                case "C_27":
                    Session["seatCode"] = "C_27";
                    seatLogin();
                    break;
                case "C_28":
                    Session["seatCode"] = "C_28";
                    seatLogin();
                    break;
                case "C_29":
                    Session["seatCode"] = "C_29";
                    seatLogin();
                    break;
                case "C_30":
                    Session["seatCode"] = "C_30";
                    seatLogin();
                    break;
                case "C_31":
                    Session["seatCode"] = "C_31";
                    seatLogin();
                    break;
                case "C_32":
                    Session["seatCode"] = "C_32";
                    seatLogin();
                    break;
                case "C_33":
                    Session["seatCode"] = "C_33";
                    seatLogin();
                    break;
                case "C_34":
                    Session["seatCode"] = "C_34";
                    seatLogin();
                    break;
                case "C_35":
                    Session["seatCode"] = "C_35";
                    seatLogin();
                    break;
                case "C_36":
                    Session["seatCode"] = "C_36";
                    seatLogin();
                    break;
                case "C_37":
                    Session["seatCode"] = "C_37";
                    seatLogin();
                    break;
                case "C_38":
                    Session["seatCode"] = "C_38";
                    seatLogin();
                    break;
                case "C_39":
                    Session["seatCode"] = "C_39";
                    seatLogin();
                    break;
                case "C_40":
                    Session["seatCode"] = "C_40";
                    seatLogin();
                    break;
                case "C_41":
                    Session["seatCode"] = "C_41";
                    seatLogin();
                    break;
                case "C_42":
                    Session["seatCode"] = "C_42";
                    seatLogin();
                    break;
                case "C_43":
                    Session["seatCode"] = "C_43";
                    seatLogin();
                    break;
                case "C_44":
                    Session["seatCode"] = "C_44";
                    seatLogin();
                    break;
                case "C_45":
                    Session["seatCode"] = "C_45";
                    seatLogin();
                    break;
                case "C_46":
                    Session["seatCode"] = "C_46";
                    seatLogin();
                    break;
                case "C_47":
                    Session["seatCode"] = "C_47";
                    seatLogin();
                    break;
                case "C_48":
                    Session["seatCode"] = "C_48";
                    seatLogin();
                    break;
                case "C_49":
                    Session["seatCode"] = "C_49";
                    seatLogin();
                    break;
                case "sign_out":
                    sign_out();
                    break;
            }

            if (!IsPostBack)
            {
                if (Application["semester"] != null)
                {
                    qr_scanner.Enabled = true;
                }
                else
                {
                    qr_scanner.Enabled = false;
                }
                InitializeSeatStatus();
                autoOut();
            }
            Response.AddHeader("Refresh", "10");
        }


        protected void userlogout_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        private void sign_out()
        {
            //updates seat_info
            string updatequery = "UPDATE seat_info SET studentNumber = null, studentName = null, seatStatus = 'Vacant', outTime = null WHERE studentNumber = @userNumber";
            try
            {
                long userNumber = long.Parse(Session["userNumber"].ToString());
                using (SqlCommand seatUpdate = new SqlCommand(updatequery, connection))
                {
                    connection.Open();
                    seatUpdate.Parameters.AddWithValue("@userNumber", userNumber);
                    seatUpdate.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void InitializeSeatStatus()
        {
            long userNumber = long.Parse(Session["userNumber"].ToString());
            string query = "SELECT * FROM seat_info";
            using (SqlCommand checkStatus = new SqlCommand(query, connection))
            {
                connection.Open();
                //check current seat status from database and changes color depending on the state
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
                        }
                        else
                        {
                            Session[seatCode] = "Occupied";
                            long currentNumber = reader.GetInt64(reader.GetOrdinal("studentNumber"));
                            TimeSpan rawTime = reader.GetTimeSpan(reader.GetOrdinal("outTime"));
                            DateTime outTime = DateTime.Today.Add(rawTime);
                            if (DateTime.Now > outTime)
                            {
                                if (currentNumber == userNumber)
                                {
                                    seatControl.Text = "You\n"+ seatCode + "\nTime's up!";
                                }
                                else
                                {
                                    seatControl.Text = seatCode+"\nTime's up!";
                                }
                                seatControl.Font.Size = 7;
                                seatControl.ForeColor = ColorTranslator.FromHtml("#fd4141");
                                seatControl.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                                seatControl.BorderColor = ColorTranslator.FromHtml("#fd4141"); // Red
                            }
                            else
                            {
                                if (currentNumber == userNumber)
                                {
                                    seatControl.Text = "You\n"+seatCode+"\n"+outTime.ToString("h:mm tt");
                                }
                                else
                                {
                                    seatControl.Text = seatCode+"\n"+outTime.ToString("h:mm tt");
                                }
                                seatControl.Font.Size = 9;
                                seatControl.BackColor = ColorTranslator.FromHtml("#db4b4b"); // Red
                                seatControl.BorderColor = ColorTranslator.FromHtml("#FA8080");
                            }
                        }
                        seatControl.BorderWidth = 3;
                    }
                    reader.Close();
                }
            }
        }

        //auto log out after 30 secs after times up
        private void autoOut()
        {
            TimeSpan finalTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 0, -30));
            string outquery = "UPDATE seat_info SET studentNumber = null, studentName = null, seatStatus = 'Vacant', outTime = null WHERE outTime < @finalTime";
            using (SqlCommand outCommand = new SqlCommand(outquery, connection))
            {
                outCommand.Parameters.AddWithValue("@finalTime", finalTime);
                outCommand.ExecuteNonQuery();
            }
        }

        private void seatLogin()
        {
            TimeSpan currenttime = DateTime.Now.TimeOfDay;
            //adds hour,min,seconds to current time
            TimeSpan outTime = currenttime.Add(new TimeSpan(0, 1, 0));
            string seatCode = Session["seatCode"].ToString();
            string semester = Application["semester"].ToString();
            long studentNumber_txt = long.Parse(Session["userNumber"].ToString());
            string studentPass_txt = Session["userPassword"].ToString();
            //query for selecting all records from user_accounts
            string checkquery = "SELECT * FROM user_accounts WHERE studentNumber = @studentNumber";
            //string checks if seat is vacant
            string vacantquery = "SELECT seatStatus from seat_info WHERE seatCode = @seatCode";
            //query for inserting new record
            string registerquery = "INSERT user_logs(studentNumber, studentName, department, program, yearLevel,semester, seatCode) SELECT ua.studentNumber, ua.studentName, ua.department, ua.program, ua.yearLevel, @semester, @seatCode FROM user_accounts ua";
            //updates seat_info
            string updatequery = "UPDATE seat_info SET seatStatus = 'Occupied',studentNumber = @studentNumber, studentName = @studentName, outTime = @outTime WHERE seatCode = @seatCode";
            //checks if the student number is currently logged in
            string existquery = "SELECT * FROM seat_info WHERE studentNumber = @studentNumber";

            using (SqlCommand vacantCommand = new SqlCommand(vacantquery, connection))
            {
                connection.Open();
                vacantCommand.Parameters.AddWithValue("seatCode", seatCode);

                using (SqlDataReader vacantseat = vacantCommand.ExecuteReader())
                {
                    vacantseat.Read();
                    string seatStatus = vacantseat.GetString(vacantseat.GetOrdinal("seatStatus"));

                    if (seatStatus == "Occupied")
                    {
                        user_lbl.Text = "This seat is already occupied";
                        vacantseat.Close();
                        connection.Close();
                        return;
                    } else
                    {
                        connection.Close();
                    }

                }

            }
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
                        string studentName = reader.GetString(reader.GetOrdinal("studentName"));
                        long studentNumber = reader.GetInt64(reader.GetOrdinal("studentNumber"));
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
                                    user_lbl.Text = "Account is already in use.";
                                    exists.Close();
                                    return;
                                }
                            }

                            using (SqlCommand userLog = new SqlCommand(registerquery, connection))
                            {
                                //sets variables used in query
                                userLog.Parameters.AddWithValue("@studentNumber", studentNumber);
                                userLog.Parameters.AddWithValue("@studentName", studentName);
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
                        }
                    }
                    else
                    {
                        user_lbl.Text = "Account number doesn't exist";
                        return;
                    }
                }
            }
        }
    }
}