using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWF.Models
{
    interface IChannel
    {
        void NextChannel();
        void PrevChannel();
        void AddChannel(string channel);
        List<string> ShowChannels();
    }
}
