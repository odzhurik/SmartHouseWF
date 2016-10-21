using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWF.Models
{
    interface ISwitchable
    {
        bool State { get; }
        void OnOff();
    }
}
