using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWF.Models
{
    public class Conditioner:Applience
    {
        private int temperature;
        private int defaultTemp;
        public string air_conditioning;
        public Conditioner()
        {
            Name = "Conditioner";
            defaultTemp = 25;
        }
        public int Temperature
        {
            set
            {
                temperature = value;
            }
            get
            {
                return temperature;
            }
        }
        public void Air_Conditioning()
        {
            if (Temperature > defaultTemp)
            
                air_conditioning = "heating to "+ Temperature;
                           
            else
               air_conditioning = "cooling to "+ Temperature;

            defaultTemp = Temperature;
        }
        public override string ShowStatus()
        {
            string status = base.ShowStatus();
            if (State)
                status += " current temperature is " + defaultTemp + " C";
            return status;
        }


    }
}