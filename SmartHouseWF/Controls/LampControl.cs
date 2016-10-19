using SmartHouseWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouseWF.Controls
{
    public class LampControl : Panel
    {
        private int id;
        private IDictionary<int, Applience> applienceDictionary;
        private Button bUp;
        private Button bDown;
        private Button deleteButton;
        ImageButton imImageLamp;
        Label lState;
        public LampControl(int id, IDictionary<int, Applience> applienceDictionary)
        {
            this.id = id;
            this.applienceDictionary = applienceDictionary;
            Initializer();
        }
        protected void Initializer()
        {
            CssClass = "app-div";
            Controls.Add(Label(applienceDictionary[id].Name + "<br />"));
            bUp = new Button();
            bDown = new Button();
            deleteButton = new Button();

            imImageLamp = ImageButton();
            Controls.Add(imImageLamp);
            GenerateBr();
            UpAndDownButtons(bDown, bUp);
            GenerateBr();



            lState = LabelofState();
            lState.ID = "LabelofState" + id;
            lState.CssClass = "labelStatus";
            Controls.Add(lState);
            deleteButton.ID = "deletebutton" + id;
            deleteButton.Text = "Delete";
            deleteButton.CssClass = "btn btn-danger";
            deleteButton.Click += DeleteButtonClick;
            GenerateBr();
            Controls.Add(deleteButton);

        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            applienceDictionary.Remove(id);
            Parent.Controls.Remove(this);
        }
        private void bUp_Click(object sender, EventArgs e)
        {


            if (!applienceDictionary[id].State)
                lState.Text = " Turn on " + applienceDictionary[id].Name;
            else
            {
                Lamp lamp = applienceDictionary[id] as Lamp;
                lamp.Up();
                lState.Text = lamp.ShowStatus();

            }



        }

        private void bDown_Click(object sender, EventArgs e)
        {
            if (!applienceDictionary[id].State)
            {
                lState.Text = " Turn on " + applienceDictionary[id].Name;
            }
            else
            {
                Lamp lamp = applienceDictionary[id] as Lamp;
                lamp.Down();
                lState.Text = lamp.ShowStatus();

            }


        }
        private void imImage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            applienceDictionary[id].On_Off();
            lState.Text = applienceDictionary[id].ShowStatus();


        }
        private Label Label(string text)
        {
            Label label = new Label();
            label.ID = "LabelName" + id;
            label.Text = text;
            label.CssClass = "labelstyle ";
            return label;
        }

        protected ImageButton ImageButton()
        {
            ImageButton imbt = new ImageButton();
            imbt.ID = "imagebutton" + id;
            imbt.ToolTip = "Press the image to turn on";
            imbt.Click += imImage_Click;



            imbt.ImageUrl = @"~\Images1\15-Light-Bulb-icon1.png";
            imbt.CssClass = "img-thumbnail";

            return imbt;
        }
        protected Label LabelofState()
        {
            Label l = new Label();
            l.ID = "LabelofState" + id;
            l.Text = "Off";
            return l;
        }
        private void UpAndDownButtons(Button button1, Button button2)
        {
            button1.ID = "Down" + id;
            button2.ID = "Up" + id;
            button1.Text = "-";
            button2.Text = "+";
            button1.CssClass = "btn btn-warning";
            button2.CssClass = "btn btn-success";
            button1.Click += bDown_Click;
            button2.Click += bUp_Click;
            Controls.Add(button1);
            Controls.Add(button2);
        }
        private void GenerateBr()
        {
            HtmlGenericControl br = new HtmlGenericControl("br");
            Controls.Add(br);
        }
    }
}