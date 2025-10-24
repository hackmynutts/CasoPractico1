using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reserve.ReservationByRoom;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Reserve.ReserveList;
using CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.GetRoom;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Reservations;
using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using CasoPractico1_JorgeMorua.BusinessLogic.Reservations.AddReservation;
using CasoPractico1_JorgeMorua.BusinessLogic.Reserve.ReservationByRoom;
using CasoPractico1_JorgeMorua.BusinessLogic.Reserve.ReserveList;
using CasoPractico1_JorgeMorua.BusinessLogic.Rooms.GetRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CasoPractico1_JorgeMorua.Controllers
{
    public class ReserveController : Controller
    {
        private readonly IReserveList_BL _reserveListBL;
        private readonly IAddReservation_BL _addReservation_BL;
        private readonly IGetRoom_BL _getRoom_BL;
        private readonly IReservationByRoom_BL _reservationsByRoom_BL;
        public ReserveController() 
        {
            _reserveListBL = new ReserveList_BL();
            _addReservation_BL = new AddReservation_BL();
            _getRoom_BL = new GetRoom_BL();
            _reservationsByRoom_BL = new ReservationByRoom_BL();

        }
        // GET: Reserve
        public ActionResult ReserveList()
        {
            List<RoomsDTO> availableRooms = _reserveListBL.GetReserveList();
            return View(availableRooms);
        }

        // GET: Reserve/ReserveByRoom/5
        public ActionResult ReserveByRoom(int id)
        {
            List<ReservationsDTO> reservations = _reservationsByRoom_BL.GetReservationsByRoom(id);
            return View(reservations);
        }

        // GET: Reserve/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserve/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserve/Reserve/5
        public ActionResult Reserve(int id)
        {
            RoomsDTO roomSelected = _getRoom_BL.GetRoomID(id);
            ReservationsDTO reserve = new ReservationsDTO
            {
                idRoom = roomSelected.id
            };
            return View("~/Views/Reservations/Create.cshtml", reserve);
        }


        // GET: Reserve/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reserve/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
