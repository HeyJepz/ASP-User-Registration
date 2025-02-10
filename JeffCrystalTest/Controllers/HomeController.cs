using JeffCrystalTest.Models;
using MySql.Data.MySqlClient;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace JeffCrystalTest.Controllers
{
    public class HomeController : Controller
    {
        string cn = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Users());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(UserModels model)
        {
            // Create 
            if (ModelState.IsValid)
            {
                //string cn = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(cn))
                {
                    con.Open();
                    MySqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        string query = @"INSERT INTO users (FirstName, LastName, Email, Gender) 
                            VALUES (@fname, @lname, @email, @gender)";

                        using (MySqlCommand cmd = new MySqlCommand(query, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@fname", model.FirstName);
                            cmd.Parameters.AddWithValue("@lname", model.LastName);
                            cmd.Parameters.AddWithValue("@email", model.Email);
                            cmd.Parameters.AddWithValue("@gender", model.Gender);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        // Process the data (e.g., save to database, send email, etc.)
                        return Json(new { success = true, message = "Registration successful!" });


                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Registration failed." });

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return Json(new { success = false, message = "Registration failed due to invalid model state." });
        }

        [HttpPost]
        public ActionResult GetInfo()
        {
            //instance of a list
            List<dynamic> list = new List<dynamic>();

            // establish connection
            using (MySqlConnection con = new MySqlConnection(cn))
            {

                // sql query
                string query = @"SELECT * FROM test_db.users";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        // turn the returned data from query to a list
                        list = con.Query<dynamic>(query).ToList();
                        Console.Write(list);
                        // convert to json
                        return Json(new { success = true, responseText = JsonConvert.SerializeObject(list), }, JsonRequestBehavior.AllowGet);
                    }catch(Exception e)
                    {
                        return Json(new { success = false, responseText = e.Message, }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult UpdateInfo(int id, string fname, string lname, string email, string gender)
        {
            using(MySqlConnection con = new MySqlConnection(cn))
            {
                string query = "UPDATE test_db.users SET FirstName=@fname, LastName=@lname, Email=@email, Gender=@gender WHERE id=@id";
                using(MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    try
                    {
                        DynamicParameters dp = new DynamicParameters();
                        dp.Add("@id", id);
                        dp.Add("@fname", fname);
                        dp.Add("@lname", lname);
                        dp.Add("@email", email);
                        dp.Add("@gender", gender);

                        con.Execute(query, dp);
                        return Json(new { success = true, responseText = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        return Json(new { success = false, responseText = e.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult DeleteInfo(int id)
        {
            using(MySqlConnection con = new MySqlConnection(cn))
            {
                string query = "DELETE FROM test_db.users WHERE id=@id";
                using(MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        DynamicParameters dp = new DynamicParameters();
                        dp.Add("@id", id);

                        con.Execute(query, dp);
                        return Json(new { success = true, responseText = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        return Json(new { success = false, responseText = e.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }
    }
    
}