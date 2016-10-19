using SmartHouseWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHouseWF.Controls
{
    public class ConditionerControl : Panel
    {
        private int id;
        private IDictionary<int, Applience> applienceDictionary;
        private Button deleteButton;
        private Button bAirCondition;
        TextBox tbTemperature;
        ImageButton imImageCond;
        Label lState;
        public ConditionerControl(int id, IDictionary<int, Applience> applienceDictionary)
        {
            this.id = id;
            this.applienceDictionary = applienceDictionary;
            Initializer();
        }
        protected void Initializer()
        {

            CssClass = "app-div";
            Controls.Add(Label(applienceDictionary[id].Name + "<br />"));
            deleteButton = new Button();

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
        private void imImage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            applienceDictionary[id].On_Off();
            lState.Text = applienceDictionary[id].ShowStatus();

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
                    con.Temperature = Convert.ToInt32(tbTemperature.Text);
                    con.Air_Conditioning();
                    lState.ForeColor = System.Drawing.Color.Black;
                    lState.Text = con.air_conditioning;
                    con.On_Off();
                    ScriptSet(con.Temperature);
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
            if (applienceDictionary[id] is Conditioner)

                tb.Text = "Input temperature what you want";


            return tb;
        }
        protected ImageButton ImageButton()
        {


            ImageButton imbt = new ImageButton();
            imbt.ID = "imagebutton" + id;
            imbt.ToolTip = "Press the image to turn on";
            imbt.Click += imImage_Click;

            imbt.ImageUrl = @"~\Images1\112132-2001.png";
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
        protected void ScriptSet(int temp)
        {
            string script = " ";



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
            alert('Stop. Your temperature now is " + temp + @"');
            

           btn.click();
            
            }, 8000);
}

</script>
             ";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Count", script);



        }
        private void GenerateBr()
        {
            HtmlGenericControl br = new HtmlGenericControl("br");
            Controls.Add(br);
        }
    }
}