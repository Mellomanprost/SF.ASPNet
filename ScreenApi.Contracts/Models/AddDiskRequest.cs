using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenApi.Contracts.Models
{
    public class AddDiskRequest
    {
        public string Name { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int Capacity { get; set; }
    }
}
