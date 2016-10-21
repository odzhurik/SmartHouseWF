using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace SmartHouseWF.Models
{
    public class Microwave:Applience, IChangeable, ICook
    {
        private bool food;
        private int max=250;
       
        public Microwave()
        {
            Name = "Microwave";
            Unit = 50;
        }
        
        public int Unit
        {
            get;
           private set;
        }
        public bool Food
        {
            set
            {
                food = value;
            }
            get
            {
                return food;
            }
        }
        public void Cook()
        {
            if(Food && State)
            {
                food = false;
            }
        }
        public void Up()
        {
            if (State)
            {
                if (Unit == max)
                    Unit = 10;
                else
                    Unit += 50;
            }
        }
        public void Down()
        {
            if (State)
            {
                if (Unit<=0)
                    Unit = max;
                else
                   
                    Unit -= 50;
                if (Unit == 0)
                    Unit = max;
            }
        }
        public override string ShowStatus()
        {
            string status= base.ShowStatus();
            if (State)
                status += " current microwave power is " + Unit + " W";
            return status;
        }
        
    }
}