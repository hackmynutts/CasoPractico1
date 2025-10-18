using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.RoomsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CasoPractico1_JorgeMorua.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsList_BL _roomsListBL;
        private readonly IAddRoom_BL _addRoomBL;
        public RoomsController() 
        {
            _roomsListBL = new RoomsList_BL();
            _addRoomBL = new AddRoom_BL();
        }
        // GET: Rooms
        public ActionResult RoomsList()
        {
            List<RoomsDTO> rooms = _roomsListBL.GetRooms();
            return View(rooms);
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoomsDTO room)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(room);
                }

                int insertedRoom = await _addRoomBL.AddRoom(room);
                if (insertedRoom > 0) return RedirectToAction("RoomsList");

                ModelState.AddModelError("", "No se pudo insertar la habitación.");
                return View(room);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al insertar: " + ex.GetBaseException().Message);
                return View(room);
            }
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("RoomsList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("RoomsList");
            }
            catch
            {
                return View();
            }
        }
    }
}
