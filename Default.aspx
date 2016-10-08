<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouseWF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" class="main">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap.css" rel="bootstap" type="text/css" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" type="text/css" />
     <style>
        .figure-div {
            border: 1px dashed;
            border-color:blue;
            float: left;
            margin: 3px;
            padding: 3px;
        }
    </style>

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
