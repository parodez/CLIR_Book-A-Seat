using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLIR_Book_A_Seat
{
    public partial class records : System.Web.UI.Page
    {
        //connects to database
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CLIR_DB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tableName"] != null) // Check if a table was previously selected
                {
                    string tableName = Session["tableName"].ToString();
                    lblTableName.Text = tableHeading(tableName);
                    LoadData(tableName);
                }
                else
                {
                    lblTableName.Text = "General";
                    generalFunction();
                }
            }
            Response.AddHeader("Refresh", "5");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string tableName = "";

            switch (clickedButton.ID)
            {
                case "general":
                    lblTableName.Text = "General";
                    generalFunction();
                    Session["tableName"] = null;
                    return;
                case "user_accounts":
                    tableName = "user_accounts";
                    break;
                case "user_logs":
                    tableName = "user_logs";
                    break;
                case "seat_info":
                    tableName = "seat_info";
                    break;
                case "back":
                    lblTableName.Text = "Back";
                    Response.Redirect("main.aspx");
                    break;
            }
            Session["tableName"] = tableName;

            if (!string.IsNullOrEmpty(tableName))
            {
                Session["tableName"] = tableName;
                lblTableName.Text = tableHeading(tableName);
                LoadData(tableName);
            }
        }
        //function for computing total logs for each department
        private void generalFunction()
        {
            long grandTotal = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Department");
            dt.Columns.Add("Total");

            //list of departments to include
            List<string> departments = new List<string> { "CAS", "CCIS", "CHS", "CMET", "ETYCB", "MIA", "CET", "MITL", "SHS" };

            foreach (string dept in departments)
            {
                long count = generalCount(dept);
                dt.Rows.Add(dept, generalCount(dept));
                grandTotal += count;
            }

            dt.Rows.Add("Total Reservations", grandTotal);

            //bind to gridView
            gvRecords.DataSource = dt;
            gvRecords.DataBind();
        }

        //shows each total of users per department
        private long generalCount(string dept)
        {
            string query = "SELECT COUNT(*) FROM user_logs WHERE department = @dept";
            long total = 0;
            using (SqlCommand count = new SqlCommand(query, connection))
            {
                count.Parameters.AddWithValue("@dept", dept);
                connection.Open();

                object result = count.ExecuteScalar(); //get result
                total = (result != DBNull.Value) ? Convert.ToInt64(result) : 0; //safe conversion

                connection.Close();
            }
            return total;
        }
        //computes overall total of reservations
        protected void totalText(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Check if the first cell contains "TOTAL LOGS"
                if (e.Row.Cells[0].Text == "Total Reservations")
                {
                    e.Row.Font.Bold = true; // Make text bold
                }
            }
        }
        //renames table headings
        private string tableHeading(string tableName)
        {
            switch (tableName)
            {
                case "user_accounts":
                    return "User Accounts";
                case "user_logs":
                    return "User Logs";
                case "seat_info":
                    return "Seat Info";
                case "General":
                    return "General";
                default:
                    return "Unknown Table";
            }
        }
        private void LoadData(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            if (tableName == "user_logs")
            {
               query = $"SELECT * FROM {tableName} ORDER BY logTime DESC";
            }

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Columns.Contains("hashedPassword"))
                {
                    dt.Columns.Remove("hashedPassword");
                }

                //check if "outTime" exists in the table
                if (dt.Columns.Contains("outTime"))
                {
                    //create a new column for formatted time
                    dt.Columns.Add("FormattedOutTime", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["outTime"] != DBNull.Value)
                        {
                            TimeSpan outTime = (TimeSpan)row["outTime"];
                            string formattedTime = DateTime.Today.Add(outTime).ToString("h:mm tt"); //convert to 12-hour format
                            row["FormattedOutTime"] = formattedTime; //store formatted time in new column
                        }
                    }

                    //remove original "outTime" column
                    dt.Columns.Remove("outTime");

                    //rename "FormattedOutTime" to "Time Out"
                    dt.Columns["FormattedOutTime"].ColumnName = "Time Out";
                }
                //set custom headers
                Dictionary<string, string> columnHeaders = new Dictionary<string, string>();

                switch (tableName)
                {
                    case "user_accounts":
                        columnHeaders = new Dictionary<string, string>
                {
                    { "studentNumber", "ID Number" },
                    { "studentName", "Username" },
                    { "department", "Department" },
                    { "program", "Program" },
                    { "yearLevel", "Year Level" }
                };
                        break;

                    case "user_logs":
                        columnHeaders = new Dictionary<string, string>
                {
                    { "logID", "Log ID" },
                    { "studentNumber", "ID Number" },
                    { "studentName", "Username" },
                    { "department", "Department" },
                    { "program", "Program" },
                    { "yearLevel", "Year Level" },
                    { "semester", "Semester" },
                    { "seatCode", "Seat Code" },
                    { "logTime", "Log Time" }
                };
                        break;

                    case "seat_info":
                        columnHeaders = new Dictionary<string, string>
                {
                    { "seatCode", "Seat Code" },
                    { "studentNumber", "ID Number" },
                    { "studentName", "Username" },
                    { "seatStatus", "Status" },
                    { "outTime", "Time Out" }
                };
                        break;
                }

                foreach (var column in columnHeaders)
                {
                    if (dt.Columns.Contains(column.Key))
                    {
                        dt.Columns[column.Key].ColumnName = column.Value;
                    }
                }

                gvRecords.DataSource = dt;
                gvRecords.DataBind();
            }
        }
    }
}