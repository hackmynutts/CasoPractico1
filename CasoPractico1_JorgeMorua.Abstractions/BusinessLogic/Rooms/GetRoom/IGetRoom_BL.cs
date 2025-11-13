using CasoPractico1_JorgeMorua.Abstractions.UIModules.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoPractico1_JorgeMorua.Abstractions.BusinessLogic.Rooms.GetRoom
{
    public interface IGetRoom_BL
    {
        RoomsDTO GetRoom(string roomId);
        RoomsDTO GetRoomID(int roomId);
    }
}
