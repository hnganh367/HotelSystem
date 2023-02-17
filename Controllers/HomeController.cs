using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBusinessLayer;

namespace HotelSystem.Controllers
{
    public class HomeController : Controller
    {
        RoomBusinessLayer roomBusinessLayer = new RoomBusinessLayer();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show_Room()
        {
            return View();
        }
        public ActionResult Update_Room(int id)
        {
            return View();
        }
        public JsonResult Get_DataById(int id)
        {
            DataSet ds = roomBusinessLayer.get_recordbyid(id);

            List<Room> listrs = new List<Room>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listrs.Add(new Room

                {

                    RoomId = Convert.ToInt32(dr["RoomId"]),

                    RoomNumber = Convert.ToInt32(dr["RoomNumber"]),

                    RoomPrice = dr["RoomPrice"].ToString(),

                    RoomType = dr["RoomType"].ToString(),

                    RoomCapacity = Convert.ToInt32(dr["RoomCapacity"]),

                    RoomDescription = dr["RoomDescription"].ToString(),

                    IsActive = dr["IsActive"].ToString()

                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add_record(Room room)
        {
            string response = string.Empty;
            try
            {
                roomBusinessLayer.Add_record(room);
                response = "Inserted";
            }
            catch(Exception)
            {
                response = "failed";
                throw;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update_RoomHotel(Room room)
        {
            string response = string.Empty;
            try
            {
                roomBusinessLayer.update_record(room);
                response = "Updated";
            }
            catch (Exception)
            {
                response = "failed";
                throw;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_RoomHotel(int id)
        {
            string response = string.Empty;
            try
            {
                roomBusinessLayer.deletedata(id);
                response = "Deleted";
            }
            catch (Exception)
            {
                response = "failed";
                throw;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Get_Data()
        {
            DataSet ds = roomBusinessLayer.get_record();

            List<Room> listrs = new List<Room>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listrs.Add(new Room

                {

                    RoomId = Convert.ToInt32(dr["RoomId"]),

                    RoomNumber = Convert.ToInt32(dr["RoomNumber"]),

                    RoomPrice = dr["RoomPrice"].ToString(),

                    RoomType = dr["RoomType"].ToString(),

                    RoomCapacity = Convert.ToInt32(dr["RoomCapacity"]),

                    RoomDescription = dr["RoomDescription"].ToString(),

                    IsActive = dr["IsActive"].ToString()

                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
    }
}