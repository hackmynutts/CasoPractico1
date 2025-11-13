using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.RoomsList;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.AddRoom;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.EditRoom;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.GetRoom;
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
        private readonly IGetRoom_BL _getRoomBL;
        private readonly IEditRoom_BL _editRoomBL;
        public RoomsController() 
        {
            _roomsListBL = new RoomsList_BL();
            _addRoomBL = new AddRoom_BL();
            _getRoomBL = new GetRoom_BL();
            _editRoomBL = new EditRoom_BL();
        }

        public ActionResult PartialViewRooms()
        {
            List<RoomsDTO> rooms = _roomsListBL.GetRooms();
            return PartialView("_PartialViewRoomsList", rooms);
        }
        // GET: Rooms
        public ActionResult RoomsList()
        {
            List<RoomsDTO> rooms = _roomsListBL.GetRooms();
            return View(rooms);
        }

        // GET: Rooms/Details/5
        public ActionResult Details(string id)
        {
            RoomsDTO room = _getRoomBL.GetRoom(id);
            return View(room);
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
        public ActionResult Edit(string id)
        {
            RoomsDTO room = _getRoomBL.GetRoom(id);
            return View(room);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, RoomsDTO room)
        {
            try
            {
                // TODO: Add update logic here
                RoomsDTO original = _getRoomBL.GetRoom(id);
                int editedLines = await _editRoomBL.EditRoom(room); 
                if (editedLines > 0)
                {
                    return RedirectToAction("RoomsList");
                }
                ModelState.AddModelError("", "No se editó ningún registro.");
                return View(original);
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", "Ocurrió un error al editar el cliente.");
                return View(room);
            }
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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
