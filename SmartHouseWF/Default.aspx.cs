using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWF.Models;
using SmartHouseWF.Controls;

namespace SmartHouseWF
{
    public partial class Default : System.Web.UI.Page
    {
        private IDictionary<int, Applience> applienceDictionary;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                applienceDictionary = (SortedDictionary<int, Applience>)Session["App"];
            }
            else
            {
                applienceDictionary = new SortedDictionary<int, Applience>();
                applienceDictionary.Add(1, new Lamp());
                applienceDictionary.Add(2, new Conditioner());
                applienceDictionary.Add(3, new Microwave());
                applienceDictionary.Add(4, new TV());

                Session["App"] = applienceDictionary;
                Session["NextId"] = 5;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            InitialisePanel();
            
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
           
          
        }
        protected void InitialisePanel()
        {
            foreach (int key in applienceDictionary.Keys)
            {
                //figuresPanel.Controls.Add(new ApplienceControl(key, applienceDictionary));
                if (applienceDictionary[key] is Lamp)
                    figuresPanel.Controls.Add(new LampControl(key, applienceDictionary));
                if(applienceDictionary[key] is Conditioner)
                    figuresPanel.Controls.Add(new ConditionerControl(key, applienceDictionary));
                if(applienceDictionary[key] is Microwave)
                    figuresPanel.Controls.Add(new MicrowaveControl(key, applienceDictionary));
                if(applienceDictionary[key] is TV)
                    figuresPanel.Controls.Add(new TVControl(key, applienceDictionary));
            }
        }

        protected void addAppsButton_Click(object sender, EventArgs e)
        {
            Applience app;
            int id=0;
            switch (dropDownListApp.SelectedIndex)
            {
                default:
                    {
                        app = new Lamp();
                        id = (int)Session["NextId"];
                        applienceDictionary.Add(id, app);
                        figuresPanel.Controls.Add(new LampControl(id, applienceDictionary));
                        break;
                    }
                case 1:
                    {
                        app = new Conditioner();
                        id = (int)Session["NextId"];
                        applienceDictionary.Add(id, app);
                        figuresPanel.Controls.Add(new ConditionerControl(id, applienceDictionary));
                        break;
                    }
                case 2:
                    {
                        app = new Microwave();
                        id = (int)Session["NextId"];
                        applienceDictionary.Add(id, app);
                        figuresPanel.Controls.Add(new MicrowaveControl(id, applienceDictionary));
                        break;
                    }
                case 3:
                    {
                        app = new TV();
                        id = (int)Session["NextId"];
                        applienceDictionary.Add(id, app);
                        figuresPanel.Controls.Add(new TVControl(id, applienceDictionary));
                        break;
                    }
            }

            
           
            id++;
            Session["NextId"] = id;
        }
        }
    
}