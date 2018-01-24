using APPSWS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace APPSWS
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        //GetCars
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void GetCars()
        {
            List<Cars> listCars = new List<Cars>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Cars cars = new Cars();
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("sp_GetAllCars", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    cars = new Cars()
                    {
                        ID = Convert.ToInt32(data["ID"]),
                        CAR_Brand = data["CAR_Brand"].ToString(),
                        CAR_No = data["CAR_No"].ToString(),
                        CAR_Type = data["CAR_Type"].ToString(),
                        CAR_Status = data["CAR_Status"].ToString(),
                        Category_Type = data["Category_Type"].ToString(),
                        CAR_Model = data["CAR_Model"].ToString(),
                        Check_Status = data["Check_Status"].ToString(),
                        Colors = data["Colors"].ToString(),
                        Car_Size = data["Car_Size"].ToString(),
                        CAR_Photo = data["CAR_Photo"].ToString(),
                        Check_Photo = data["Check_Photo"].ToString(),
                        City = data["City"].ToString(),
                        Pay_Type = data["Pay_Type"].ToString(),
                        Location = data["Location"].ToString(),
                        Notes = data["Notes"].ToString(),
                        CAR_Price = Convert.ToDecimal(data["CAR_Price"]),
                        Check_Date = data["Check_Date"].ToString()
                    };
                    listCars.Add(cars);
                }
            }

            Context.Response.Write(js.Serialize(listCars));
        }

        // GetCarById
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void GetCarById(int id)
        {
            List<Cars> listCars = new List<Cars>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            SqlDataReader data;
            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Cars cars = new Cars();
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("SP_GetCarsById", con);
                SqlParameter[] para = new SqlParameter[0];
                cmd.Parameters.AddWithValue("@id", id);
                Connection.AddParam(cmd, para);
                cmd.CommandType = CommandType.StoredProcedure;
                data = cmd.ExecuteReader();
                while (data.Read())
                {
                    cars = new Cars()
                    {
                        ID = Convert.ToInt32(data["ID"]),
                        CAR_Brand = data["CAR_Brand"].ToString(),
                        CAR_No = data["CAR_No"].ToString(),
                        CAR_Type = data["CAR_Type"].ToString(),
                        CAR_Status = data["CAR_Status"].ToString(),
                        Category_Type = data["Category_Type"].ToString(),
                        CAR_Model = data["CAR_Model"].ToString(),
                        Check_Status = data["Check_Status"].ToString(),
                        Colors = data["Colors"].ToString(),
                        Car_Size = data["Car_Size"].ToString(),
                        CAR_Photo = data["CAR_Photo"].ToString(),
                        Check_Photo = data["Check_Photo"].ToString(),
                        City = data["City"].ToString(),
                        Pay_Type = data["Pay_Type"].ToString(),
                        Location = data["Location"].ToString(),
                        Notes = data["Notes"].ToString(),
                        CAR_Price = Convert.ToDecimal(data["CAR_Price"]),
                        Check_Date = data["Check_Date"].ToString()
                    };
                    listCars.Add(cars);
                }
            }

            Context.Response.Write(js.Serialize(listCars));
        }

        // Get Search
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void Search(string CAR_Brand, string CAR_No, string CAR_Type, string CAR_Status, string CAR_Model)
        {
            List<Cars> listCars = new List<Cars>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            SqlDataReader data;


            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Cars cars = new Cars();
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("SP_Search", con);

                // Create parameters
                SqlParameter[] para = new SqlParameter[5];
                // para CAR_Brand
                para[0] = new SqlParameter("@CAR_Brand", SqlDbType.NVarChar, 200);
                para[0].Value = CAR_Brand;

                // para CAR_No
                para[1] = new SqlParameter("@CAR_No", SqlDbType.NVarChar, 200);
                para[1].Value = CAR_No;

                // para CAR_Type
                para[2] = new SqlParameter("@CAR_Type", SqlDbType.NVarChar, 200);
                para[2].Value = CAR_Type;

                // para CAR_Status
                para[3] = new SqlParameter("@CAR_Status", SqlDbType.NVarChar, 50);
                para[3].Value = CAR_Status;

                // para CAR_Model
                para[4] = new SqlParameter("@CAR_Model", SqlDbType.NVarChar, 250);
                para[4].Value = CAR_Model;

                Connection.AddParam(cmd, para);
                cmd.CommandType = CommandType.StoredProcedure;
                data = cmd.ExecuteReader();
                while (data.Read())
                {
                    cars = new Cars()
                    {
                        ID = Convert.ToInt32(data["ID"]),
                        CAR_Brand = data["CAR_Brand"].ToString(),
                        CAR_No = data["CAR_No"].ToString(),
                        CAR_Type = data["CAR_Type"].ToString(),
                        CAR_Status = data["CAR_Status"].ToString(),
                        Category_Type = data["Category_Type"].ToString(),
                        CAR_Model = data["CAR_Model"].ToString(),
                        Check_Status = data["Check_Status"].ToString(),
                        Colors = data["Colors"].ToString(),
                        Car_Size = data["Car_Size"].ToString(),
                        CAR_Photo = data["CAR_Photo"].ToString(),
                        Check_Photo = data["Check_Photo"].ToString(),
                        City = data["City"].ToString(),
                        Pay_Type = data["Pay_Type"].ToString(),
                        Location = data["Location"].ToString(),
                        Notes = data["Notes"].ToString(),
                        CAR_Price = Convert.ToDecimal(data["CAR_Price"]),
                        Check_Date = data["Check_Date"].ToString()
                    };
                    listCars.Add(cars);
                }
            }

            Context.Response.Write(js.Serialize(listCars));
        }



        //POST  Add Cars 
        [WebMethod]
        public int AddCars(string CAR_Brand, string CAR_No, string CAR_Type, string CAR_Status,
            string Category_Type, string CAR_Model, string Check_Status,
            string Colors, string Car_Size, string CAR_Photo, string Check_Photo,
            string City, string Pay_Type, decimal CAR_Price, string Location, string Notes, string Check_Date)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Cars cars = new Cars();
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("SP_AddCars", con);

                // Parameters
                #region
                // para CAR_Brand
                SqlParameter[] para = new SqlParameter[17];

                para[0] = new SqlParameter("@CAR_Brand", SqlDbType.NVarChar, 200);
                para[0].Value = CAR_Brand;

                // para CAR_No
                para[1] = new SqlParameter("@CAR_No", SqlDbType.NVarChar, 200);
                para[1].Value = CAR_No;

                // para CAR_Type
                para[2] = new SqlParameter("@CAR_Type", SqlDbType.NVarChar, 200);
                para[2].Value = CAR_Type;

                // para CAR_Status
                para[3] = new SqlParameter("@CAR_Status", SqlDbType.NVarChar, 50);
                para[3].Value = CAR_Status;

                // para Category_Type
                para[4] = new SqlParameter("@Category_Type", SqlDbType.NVarChar, 50);
                para[4].Value = Category_Type;
                // para CAR_Model
                para[5] = new SqlParameter("@CAR_Model", SqlDbType.NVarChar, 250);
                para[5].Value = CAR_Model;

                // para Check_Status
                para[6] = new SqlParameter("@Check_Status", SqlDbType.NVarChar, 250);
                para[6].Value = Check_Status;

                // para Colors
                para[7] = new SqlParameter("@Colors", SqlDbType.NVarChar, 250);
                para[7].Value = Colors;

                // para Car_Size
                para[8] = new SqlParameter("@Car_Size", SqlDbType.NVarChar, 250);
                para[8].Value = Car_Size;

                // para CAR_Photo
                para[9] = new SqlParameter("@CAR_Photo", SqlDbType.NVarChar, 250);
                para[9].Value = CAR_Photo;

                // para Check_Photo
                para[10] = new SqlParameter("@Check_Photo", SqlDbType.NVarChar, 250);
                para[10].Value = Check_Photo;

                // para City
                para[11] = new SqlParameter("@City", SqlDbType.NVarChar, 250);
                para[11].Value = City;

                // para Pay_Type
                para[12] = new SqlParameter("@Pay_Type", SqlDbType.NVarChar, 250);
                para[12].Value = Pay_Type;


                // para CAR_Price
                para[13] = new SqlParameter("@CAR_Price", SqlDbType.Decimal, 250);
                para[13].Value = CAR_Price;

                // para Location
                para[14] = new SqlParameter("@Location", SqlDbType.NVarChar, 250);
                para[14].Value = Location;

                // para Notes
                para[15] = new SqlParameter("@Notes", SqlDbType.NVarChar, 250);
                para[15].Value = Notes;

                // para Check_Date
                para[16] = new SqlParameter("@Check_Date", SqlDbType.NVarChar, 250);
                para[16].Value = Check_Date;

                #endregion

                Connection.AddParam(cmd, para);

                cmd.CommandType = CommandType.StoredProcedure;
                int Type = cmd.ExecuteNonQuery();
                if (Type > 0)
                {
                    return Type;
                }
                else
                {
                    return 0;
                }
            }

        }



        // Post Delete Cars
        [WebMethod]
        public long DeleteCars(string CAR_No)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("SP_DeleteCares", con);
                // para CAR_Brand
                SqlParameter[] para = new SqlParameter[1];

                para[0] = new SqlParameter("@CAR_No", SqlDbType.NVarChar, 150);
                para[0].Value = CAR_No;

                Connection.AddParam(cmd, para);
                cmd.CommandType = CommandType.StoredProcedure;

                long status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return 0;
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void GetUsers()
        {
            List<Users> listUsers = new List<Users>();
            JavaScriptSerializer js = new JavaScriptSerializer();

            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Users users = new Users();
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("SP_GetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    users = new Users()
                    {
                        UserId = Convert.ToInt32(data["UserId"]),
                        UserName = data["UserName"].ToString(),
                        UserPassword = data["UserPassword"].ToString(),
                        UserEmail = data["UserEmail"].ToString(),
                        Comments = data["Comments"].ToString(),
                        Phone = data["Phone"].ToString()
                    };
                    listUsers.Add(users);
                }


            }
            Context.Response.Write(js.Serialize(listUsers));
        }

        // POST Delete Users
        [WebMethod]
        public long DeleteUsers(string email)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand("SP_DeleteUsers", con);
                // para CAR_Brand
                SqlParameter[] para = new SqlParameter[1];

                para[0] = new SqlParameter("@email", SqlDbType.NVarChar, 150);
                para[0].Value = email;

                Connection.AddParam(cmd, para);
                cmd.CommandType = CommandType.StoredProcedure;

                long status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return 0;
                }
            }
        }

        
        // POST Delete Users
        [WebMethod]
        public Boolean checkLogin(string email)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConnection))
            {

                string SQL = "select * from tblUsers where UserEmail = @email";
                Connection.openConection(con);
                SqlCommand cmd = new SqlCommand(SQL, con);
                // Create parameters
                SqlParameter[] para = new SqlParameter[1];
                // para email
                para[0] = new SqlParameter("@email", SqlDbType.NVarChar,200);
                para[0].Value = email;
                Connection.AddParam(cmd, para);
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                if(table.Rows.Count > 0)
                {
                    if (email == table.Rows[0]["UserEmail"].ToString())
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            return false;

        }


    }

}