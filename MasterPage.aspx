<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterPage.aspx.cs" Inherits="MasterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css" />
    <title></title>
    <style type="text/css">
        #form1 {
            height: 291px;
            width: 981px;
        }
    </style>
</head>
<body style="height: 70px">
    <form id="form1" runat="server">        
    <div>    
        <h1>Instructions</h1>
        <center style="height: 242px; width: 1331px">
        <br />
        <br />
        -Specify one or more search crieteria.<br />
        - Any combination of search criteria is allowed.<br />
        - Select a movie from the list and see the information for that movie.<br />
        <br />
        Example: Enter &#39;the&#39; in partial title box, then search, then enter &#39;2001&#39; in from year box, enter &#39;comedy&#39; in genre box.<br />
        <br />
        <br />
        <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Ok" />
    
    </div>
        </center>
    </form>
</body>
</html>
