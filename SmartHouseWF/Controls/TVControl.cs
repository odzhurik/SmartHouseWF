using SmartHouseWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouseWF.Controls
{
    public class TVControl : Panel
    {
        private IDictionary<int, Applience> applienceDictionary;
        private int id;
        private Button bUp;
        private Button bDown;
        private Button deleteButton;
        private ImageButton imImageTV;
        private PlaceHolder plTV;
        private Button bShowChannels;
        private TextBox tbAddChannel;
        private Button bAddChannel;
        private Button bPrevChannel;
        private Button bNextChannel;
        private Label lState;
        public TVControl(int id, IDictionary<int, Applience> applienceDictionary)
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

            imImageTV = ImageButton();
            plTV = new PlaceHolder();
            plTV.ID = "PlaceHolder" + id;
            bShowChannels = new Button();
            bShowChannels.ID = "showChannelsButton" + id;
            bShowChannels.CssClass = "btn btn-primary";
            bShowChannels.Text = "Show channels";
            bShowChannels.Click += bShowChannels_Click;
            tbAddChannel = TextBox();
            bAddChannel = new Button();
            bAddChannel.ID = "addChannelButton" + id;
            bAddChannel.CssClass = "btn btn-primary";
            bAddChannel.Text = "Add channel";
            bAddChannel.Click += bAddChannel_Click;
            bPrevChannel = new Button();
            bPrevChannel.ID = "buttonprevchannel" + id;
            bPrevChannel.Text = "<-";
            bPrevChannel.CssClass = "btn btn-info";
            bPrevChannel.Click += bPrevChannel_Click;
            bNextChannel = new Button();
            bNextChannel.ID = "buttonNextChannel" + id;
            bNextChannel.Text = "->";
            bNextChannel.CssClass = "btn btn-primary";
            bNextChannel.Click += bNextChannel_Click;
            Controls.Add(imImageTV);
            GenerateBr();
            Controls.Add(bShowChannels);
            Controls.Add(plTV);
            GenerateBr();
            Controls.Add(tbAddChannel);
            Controls.Add(bAddChannel);
            GenerateBr();
            UpAndDownButtons(bDown, bUp);
            GenerateBr();
            Controls.Add(bPrevChannel);
            Controls.Add(bNextChannel);
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
        private void bNextChannel_Click(object sender, EventArgs e)
        {
            if (!applienceDictionary[id].State)
            {
                lState.Text = "Turn on TV";
            }
            else
            {
                TV tv = (TV)applienceDictionary[id];
                tv.NextChannel();
                lState.Text = tv.ShowStatus();
            }

        }

        private void bPrevChannel_Click(object sender, EventArgs e)
        {
            if (!applienceDictionary[id].State)
            {
                lState.Text = "Turn on TV";
            }
            else
            {
                TV tv = (TV)applienceDictionary[id];
                tv.PrevChannel();
                lState.Text = tv.ShowStatus();
            }

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

                TV tv = applienceDictionary[id] as TV;
                tv.Up();
                lState.Text = tv.ShowStatus();
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
                TV tv = applienceDictionary[id] as TV;
                tv.Down();
                lState.Text = tv.ShowStatus();
            }




        }
        private void imImage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            applienceDictionary[id].On_Off();
            lState.ForeColor = System.Drawing.Color.Black;
            lState.Text = applienceDictionary[id].ShowStatus();


        }
        private void bAddChannel_Click(object sender, EventArgs e)
        {
            if (applienceDictionary[id].State)
            {
                TV tv = applienceDictionary[id] as TV;
                if (!String.IsNullOrEmpty(tbAddChannel.Text))
                {
                    tv.AddChannel(tbAddChannel.Text);
                }
            }
        }
        private void bShowChannels_Click(object sender, EventArgs e)
        {
            if (applienceDictionary[id].State)
            {
                TV tv = applienceDictionary[id] as TV;
                ListBox lb = new ListBox();
                List<string> list = tv.ShowChannels();
                foreach (string item in list)
                    lb.Items.Add(item);
                lb.DataBind();
                plTV.Controls.Add(lb);
            }
            else
            {
                lState.ForeColor = System.Drawing.Color.Red;
                lState.Text = "Turn on TV";
            }
        }


        private Label Label(string text)
        {
            Label label = new Label();
            label.ID = "LabelName" + id;
            label.Text = text;
            label.CssClass = "labelstyle ";
            return label;
        }

        protected TextBox TextBox()
        {
            TextBox tb = new TextBox();
            tb.ID = "TextBox" + id;

            if (applienceDictionary[id] is TV)
                tb.Text = "Input the name of the new channel";

            return tb;
        }
        protected ImageButton ImageButton()
        {
            ImageButton imbt = new ImageButton();
            imbt.ID = "imagebutton" + id;
            imbt.ToolTip = "Press the image to turn on";
            imbt.Click += imImage_Click;

            imbt.ImageUrl = @"~\Images1\retro-tv-icon-615261.png";
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