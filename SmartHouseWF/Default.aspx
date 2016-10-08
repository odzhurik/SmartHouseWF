<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.css" rel="bootstap" type="text/css" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" type="text/css" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="This is a smart house" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:DropDownList ID="dropDownListApp" runat="server" >
                <asp:ListItem>Lamp</asp:ListItem>
                <asp:ListItem>Conditioner</asp:ListItem>
                <asp:ListItem>Microwave</asp:ListItem>
                <asp:ListItem>TV</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="addAppsButton" runat="server" Text="Add" OnClick="addAppsButton_Click"  CssClass="btn btn-default"/>
            <br />
           <asp:Panel ID="figuresPanel" runat="server" ></asp:Panel>
            </div>
    </form>
    
</body>
</html>
