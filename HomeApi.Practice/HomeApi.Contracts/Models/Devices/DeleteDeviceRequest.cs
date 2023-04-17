using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Devices
{
    /// <summary>
    /// Запрос для удаления подключенного устройства
    /// </summary>
    public class DeleteDeviceRequest
    {
        public string DeleteRoom { get; set; }
        public string DeleteName { get; set; }
        public string DeleteSerial { get; set; }

    }
}
