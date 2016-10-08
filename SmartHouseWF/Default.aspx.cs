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
                figuresPanel.Controls.Add(new ApplienceControl(key, applienceDictionary));
            }
        }

        protected void addAppsButton_Click(object sender, EventArgs e)
        {
            Applience app;
            switch (dropDownListApp.SelectedIndex)
            {
                default:
                    app = new Lamp();
                    break;
                case 1:
                    app = new  Conditioner();
                    break;
                case 2:
                    app = new Microwave();
                    break;
                case 3:
                    app = new TV();
                    break;
            }

            int id = (int)Session["NextId"];
            applienceDictionary.Add(id, app); 
            figuresPanel.Controls.Add(new ApplienceControl(id,applienceDictionary)); 
            id++;
            Session["NextId"] = id;
        }
        }
    
}