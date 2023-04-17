using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Rooms
{
    public class DeleteRoomRequest
    {
        public string Name { get; set; }
        public int Area { get; set; }
    }
}
