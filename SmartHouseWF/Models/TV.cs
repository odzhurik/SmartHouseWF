using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseWF.Models
{
    public class TV:Applience, IChangleable
    {
        public List<string> channels;
        public string currentChannel;
        int max = 20;
        public TV()
        {
            Name = "TV";
            channels = new List<string>();
            channels.Add("MTV");
            channels.Add("1+1");
            channels.Add("ICTV");
            channels.Add("2+2");
            currentChannel = channels.ElementAt(0);
            Unit = 8;
        }
        public int Unit
        {
            get;
            private set;
        }
       
        public List<string> ShowChannels()
        {
            if (this.State)
                return channels;
            else
                return null;
        }
         public void AddChannel(string channel)
        {
         
            channels.Add(channel);
        }
        public void Up()
         {
             if (State)
             {
                 if (Unit == max)
                     Unit = 0;
                 else
                     Unit++;
             }
         }
        public void Down()
        {
            if (State)
            {
                if (Unit == 0)
                    Unit = max;
                else
                    Unit--;
            }
        }
        public override string ShowStatus()
        {
            string status = base.ShowStatus();
           
            if (State)
                status += " current volume "+ Unit+ " current channel "+ currentChannel;

            return status;
        }
        public void NextChannel()
        {
            if (State)
            {
                int index = channels.IndexOf(currentChannel);
                if (index == (channels.Count - 1))
                    currentChannel = channels[0];
                else
                    currentChannel = channels[++index];
            }
        }
        public void PrevChannel()
        {
            if (State)
            {
                int index = channels.IndexOf(currentChannel);
                if (index == 0)
                    currentChannel = channels[channels.Count - 1];
                else
                    currentChannel = channels[--index];
            }
        }
    }
}