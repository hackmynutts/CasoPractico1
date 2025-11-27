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
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CasoPractico1_JorgeMorua.Controllers
{
    public class RoomsAPIController : ApiController
    {

        private readonly IRoomsList_BL _roomsListBL;
        private readonly IAddRoom_BL _addRoomBL;
        private readonly IGetRoom_BL _getRoomBL;
        private readonly IEditRoom_BL _editRoomBL;
        public RoomsAPIController()
        {
            _roomsListBL = new RoomsList_BL();
            _addRoomBL = new AddRoom_BL();
            _getRoomBL = new GetRoom_BL();
            _editRoomBL = new EditRoom_BL();
        }
        [Authorize]
        // GET: api/RoomsAPI
        public List<RoomsDTO> Get()
        {
            return _roomsListBL.GetRooms();
        }

        // GET: api/RoomsAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomsAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RoomsAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RoomsAPI/5
        public void Delete(int id)
        {
        }
    }
}
