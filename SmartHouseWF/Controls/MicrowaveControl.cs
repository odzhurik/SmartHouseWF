using SmartHouseWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouseWF.Controls
{
    public class MicrowaveControl : Panel
    {
        private IDictionary<int, Applience> applienceDictionary;
        private int id;
        private Button bUp;
        private Button bDown;
        private Button deleteButton;
        private Button bReheat;
        TextBox tbMicrowave;
        ImageButton imImageMicro;
        private CheckBox cbFood;
        Label lState;
        public MicrowaveControl(int id, IDictionary<int, Applience> applienceDictionary)
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
            if (applienceDictionary[id] is Microwave)
            {

                tbMicrowave = TextBox();
                imImageMicro = ImageButton();
                cbFood = new CheckBox();
                cbFood.ID = "CheckBoxFood" + id;
                cbFood.Text = "Food";
                cbFood.Checked = false;
                cbFood.AutoPostBack = true;
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
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            applienceDictionary.Remove(id);
            Parent.Controls.Remove(this);
        }


        private void bUp_Click(object sender, EventArgs e)
        {
                   
            
                    if(applienceDictionary[id] is Microwave)
                    {
                        Microwave micro = applienceDictionary[id] as Microwave;
                        micro.Up();
                        lState.Text = micro.ShowStatus();

                        
                    }
               

            if (!applienceDictionary[id].State)
                lState.Text = " Turn on " + applienceDictionary[id].Name;
        }

        private void bDown_Click(object sender, EventArgs e)
        {
         
                    if(applienceDictionary[id] is Microwave)
                    {
                        Microwave micro = applienceDictionary[id] as Microwave;
                        micro.Down();
                        lState.Text = micro.ShowStatus();
                        
                    }
                
            if (!applienceDictionary[id].State && applienceDictionary[id] is Microwave)
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
            if (applienceDictionary[id] is Microwave)
            {
                applienceDictionary[id].On_Off();
                lState.Text = applienceDictionary[id].ShowStatus();

                cbFood.Checked = false;
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
            if (!applienceDictionary[id].State)
            {
                lState.ForeColor = System.Drawing.Color.Red;
                lState.Text = "Turn on Microwave";
            }
            micro.On_Off();

            ScriptSet();
            lState.Text = "Working ";

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
              return tb;
        }
        protected ImageButton ImageButton()
        {
            ImageButton imbt = new ImageButton();
            imbt.ID = "imagebutton" + id;
            imbt.ToolTip = "Press the image to turn on";
            imbt.Click += imImage_Click;
          
                 if(applienceDictionary[id] is Microwave)
                    imbt.ImageUrl = @"~\Images1\microwave-icon-20.png";
                    
                
            return imbt;
        }
        protected Label LabelofState()
        {
            Label l = new Label();
            l.ID = "LabelofState" + id;
            l.Text = "Off";
            return l;
        }
        protected void ScriptSet()
        {
            string script = " ";
           
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