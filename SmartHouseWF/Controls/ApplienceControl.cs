using SmartHouseWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouseWF.Controls
{
    public class ApplienceControl : Panel
    {
        private int id;
        private IDictionary<int, Applience> applienceDictionary;
        private Button bShowChannels;
        private Button bAddChannel;
        private Button bAirCondition;
        private Button bUp;
        private Button bDown;
        private Button bNextChannel;
        private Button bPrevChannel;
        private Button deleteButton;
        private TextBox tbAddChannel;
        private TextBox tbTemperature;
        private TextBox tbMicrowave;
        private ImageButton imImageTV;
        private ImageButton imImageLamp;
        private ImageButton imImageMicro;
        private ImageButton imImageCond;
        private CheckBox cbFood;
        private Button bReheat;
        private Label lState;
        private PlaceHolder plTV;
        public ApplienceControl(int id, IDictionary<int, Applience> applienceDictionary)
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
            if (applienceDictionary[id] is TV)
            {
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
                bPrevChannel.Click+=bPrevChannel_Click;
                bNextChannel = new Button();
                bNextChannel.ID = "buttonNextChannel" + id;
                bNextChannel.Text = "->";
                bNextChannel.CssClass = "btn btn-primary";
                bNextChannel.Click+=bNextChannel_Click;
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

            }

            if (applienceDictionary[id] is Conditioner)
            {
                imImageCond = ImageButton();
                tbTemperature = TextBox();
                bAirCondition = new Button();
                bAirCondition.ID = "AirConButton" + id;
                bAirCondition.Text = "Set";
                bAirCondition.CssClass = "btn btn-primary";
                bAirCondition.Click += bAirCondition_Click;
                Controls.Add(imImageCond);
                GenerateBr();
                Controls.Add(tbTemperature);
                Controls.Add(bAirCondition);
                GenerateBr();
            }

            if (applienceDictionary[id] is Microwave)
            {
               
                tbMicrowave = TextBox();
                imImageMicro = ImageButton();
                cbFood = new CheckBox();
                cbFood.ID = "CheckBoxFood" + id;
                cbFood.Text = "Food";
                cbFood.Checked = false;
                cbFood.AutoPostBack=true;
                cbFood.CheckedChanged += cbFood_CheckedChanged;
                bReheat = new Button();
                bReheat.ID = "ReheatButton" + id;
                bReheat.CssClass = "btn btn-info";
                bReheat.Text = "Reheat";
                bReheat.Click += bReheat_Click;
                Controls.Add(imImageMicro);
                GenerateBr();
                Controls.Add(tbMicrowave);
                Controls.Add(cbFood);
                Controls.Add(bReheat);
                GenerateBr();
                UpAndDownButtons(bDown, bUp);
                GenerateBr();
                
            }
            if (applienceDictionary[id] is Lamp)
            {
                imImageLamp = ImageButton();
               Controls.Add(imImageLamp);
               GenerateBr();
               UpAndDownButtons(bDown, bUp);
               GenerateBr();
            }

           
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
           
                TV tv = (TV)applienceDictionary[id];
                tv.NextChannel();
                lState.Text = tv.ShowStatus();
            
            if(!applienceDictionary[id].State)
            
            {
                lState.Text = "Turn on TV";
            }
        }

        private void bPrevChannel_Click(object sender, EventArgs e)
        {
           
                TV tv = (TV)applienceDictionary[id];
                tv.PrevChannel();
                lState.Text = tv.ShowStatus();
           
            if(!applienceDictionary[id].State)
            {
                lState.Text = "Turn on TV";
            }
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            applienceDictionary.Remove(id); 
            Parent.Controls.Remove(this);
        }

       
        private void bUp_Click(object sender, EventArgs e)
        {
            
                switch (applienceDictionary[id].ToString())
                {
                    case "SmartHouseWF.Models.Lamp":
                        {
                            Lamp lamp = applienceDictionary[id] as Lamp;
                            lamp.Up();
                            lState.Text = lamp.ShowStatus();
                            break;
                        }


                    case "SmartHouseWF.Models.Microwave":
                        {
                            Microwave micro = applienceDictionary[id] as Microwave;
                            micro.Up();
                            lState.Text = micro.ShowStatus();
                           
                            break;
                        }
                    case "SmartHouseWF.Models.TV":
                        {
                            TV tv = applienceDictionary[id] as TV;
                            tv.Up();
                            lState.Text = tv.ShowStatus();
                            break;
                        }
                }
            
            if(!applienceDictionary[id].State)
                lState.Text = " Turn on " + applienceDictionary[id].Name;
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            
                switch (applienceDictionary[id].ToString())
                {
                    case "SmartHouseWF.Models.Lamp":
                        {
                            Lamp lamp = applienceDictionary[id] as Lamp;
                            lamp.Down();
                            lState.Text = lamp.ShowStatus();
                            break;
                        }


                    case "SmartHouseWF.Models.Microwave":
                        {
                            Microwave micro = applienceDictionary[id] as Microwave;
                            micro.Down();
                            lState.Text = micro.ShowStatus();
                            break;
                        }
                    case "SmartHouseWF.Models.TV":
                        {
                            TV tv = applienceDictionary[id] as TV;
                            tv.Down();
                            lState.Text = tv.ShowStatus();
                            break;
                        }
                }
           if(!applienceDictionary[id].State)
            {
                lState.Text = " Turn on " + applienceDictionary[id].Name;
            }
        }
         
        private void cbFood_CheckedChanged(object sender, EventArgs e)
        {
            if (!applienceDictionary[id].State)
            {
                lState.ForeColor = System.Drawing.Color.Red;
                lState.Text = "Turn on Microwave";
            }
            else
            {
              
                Microwave micro = applienceDictionary[id] as Microwave;
                micro.Food = true;
               
            }
        }
        private void imImage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
          
            applienceDictionary[id].On_Off();
            lState.Text = applienceDictionary[id].ShowStatus();
            if (applienceDictionary[id] is Microwave)
                cbFood.Checked = false;
                     
            foreach ( int key in applienceDictionary.Keys)
            {
                if(applienceDictionary[key].GetType()==applienceDictionary[id].GetType()&&(applienceDictionary[id] is Microwave)&& (applienceDictionary[key].State)&& id!=key)
                {
                    applienceDictionary[id].State = false;
                    lState.Text = "You can't turn on 2 Microwaves at the same time";
                }
            }

        }

        private void bReheat_Click(object sender, EventArgs e)
        {

           
                Microwave micro = applienceDictionary[id] as Microwave;
               
                    
                    micro.Cook();
                 
                    if (!cbFood.Checked)
                    {
                        lState.ForeColor = System.Drawing.Color.Red;
                        lState.Text = "Check the food";
                    }
              if(!applienceDictionary[id].State)              
            {
                lState.ForeColor = System.Drawing.Color.Red;
                lState.Text = "Turn on Microwave";
            }
              micro.On_Off();

              ScriptSet(1);
              lState.Text = "Working ";
              
        }

        private void bAirCondition_Click(object sender, EventArgs e)
        {
            if (applienceDictionary[id].State)
            {
                Conditioner con = applienceDictionary[id] as Conditioner;
                int res;
                bool isInt = Int32.TryParse(tbTemperature.Text, out res);
                if ((!String.IsNullOrEmpty(tbTemperature.Text)) && (isInt))
                {
                    con.Temperature= Convert.ToInt32(tbTemperature.Text);
                    con.Air_Conditioning();
                    lState.ForeColor = System.Drawing.Color.Black;
                    lState.Text = con.air_conditioning;
                    con.On_Off();
                    ScriptSet(2, con.Temperature);
                }
                else
                {
                    lState.ForeColor = System.Drawing.Color.Red;
                    lState.Text = "Input integer";
                }

            }
            else
            {
                lState.ForeColor = System.Drawing.Color.Red;
                lState.Text = "Turn on Conditioner";

            }

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
            switch (applienceDictionary[id].ToString())
            {
                case "SmartHouseWF.Models.Conditioner":
                    tb.Text = "Input temperature what you want";
                    break;
                case "SmartHouseWF.Models.TV":
                    tb.Text = "Input the name of the new channel";
                    break;

            }
            return tb;
        }
        protected ImageButton ImageButton()
        {
            ImageButton imbt = new ImageButton();
            imbt.ID = "imagebutton" + id;
            imbt.ToolTip = "Press the image to turn on";
            imbt.Click += imImage_Click;
            switch (applienceDictionary[id].ToString())
            {
                case "SmartHouseWF.Models.Lamp":
                    imbt.ImageUrl = @"~\Images1\15-Light-Bulb-icon.png";
                    break;
                case "SmartHouseWF.Models.Conditioner":
                    imbt.ImageUrl = @"~\Images1\112132-200.png";
                    break;
                case "SmartHouseWF.Models.Microwave":
                    imbt.ImageUrl = @"~\Images1\microwave-icon-20.png";
                    break;
                case "SmartHouseWF.Models.TV":
                    imbt.ImageUrl = @"~\Images1\retro-tv-icon-61526.png";
                    break;

            }
            return imbt;
        }
        protected Label LabelofState()
        {
            Label l = new Label();
            l.ID = "LabelofState" + id;
            l.Text = "Off";
            return l;
        }
         protected void ScriptSet(int param, int temp=0)
         {
             string script = " ";
             if (param == 1)
             {
                 script = @"
<script>
         //var isCallPostBack = false;
//window.onload= function(){
                 function countdown() {
    var element =  document.getElementById('TextBox" + id + @"');
    var seconds = parseInt(element.value )* 1;
    var btn = get('imagebutton" + id + @"');
if(get('CheckBoxFood" + id + @"').checked==false)
          return true;
         //if (isCallPostBack) 
           // return true;
    if (seconds > 0) {
        element.value = seconds - 1;
        setTimeout(countdown, 1000);
//return false;
    }
    if (seconds == 0) {

        alert('Your meal is ready');
        element.value=' ';
//isCallPostBack = true;
 btn.click();

    }

} 
setTimeout(countdown, 1000);
//}
var get = function (id) {
        return document.getElementById(id);
    }
</script>
             ";

                 Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CountDown", script);
             }
             if(param==2)
             {
                 script = @"
<script>
          var counter = 1;
          var intervalHandler;
        window.onload= function()
{
    var element =  document.getElementById('LabelofState" + id + @"');
      function count() {
        element.innerText = counter;
        counter++;
        
    }
  var btn =  document.getElementById('imagebutton" + id + @"');
     intervalHandler = setInterval(count, 1000);

        var handler = setTimeout(function () {
            clearInterval(intervalHandler);
            alert('Stop. Your temperature now is " +temp+ @"');
            

           btn.click();
            
            }, 8000);
}

</script>
             ";

                 Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Count", script);
             }

           
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