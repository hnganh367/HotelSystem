using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBusinessLayer;

namespace HotelSystem.Controllers
{
    public class RoomController : Controller
    {
        public ActionResult Index()
        {
            RoomBusinessLayer roomBusinessLayer = new RoomBusinessLayer();
            List<Room> rooms = roomBusinessLayer.Rooms.ToList();
            return View(rooms);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Room room = new Room();
            TryUpdateModel(room);

            if (ModelState.IsValid)
            {
                RoomBusinessLayer roomBusinessLayer = new RoomBusinessLayer();
                roomBusinessLayer.AddRoom(room);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            RoomBusinessLayer roomBusinessLayer = new RoomBusinessLayer();
            Room room = roomBusinessLayer.Rooms.Single(r => r.RoomId == id);
            return View(room);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
                RoomBusinessLayer roomBusinessLayer = new RoomBusinessLayer();
                Room room = roomBusinessLayer.Rooms.Single(x => x.RoomId == id);
                UpdateModel<IRoom>(room);
                if (ModelState.IsValid)
                {
                    roomBusinessLayer.SaveRoom(room);
                    return RedirectToAction("Index");
                }
                return View(room);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            RoomBusinessLayer roomBusinessLayer = new RoomBusinessLayer();
            roomBusinessLayer.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}