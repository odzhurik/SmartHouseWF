using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseWF.Models
{
    interface IChangleable
    {
        int Unit
        {
            get;
           
        }
         void Up();
         void Down();
    }
}
