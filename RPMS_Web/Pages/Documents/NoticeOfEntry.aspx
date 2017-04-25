<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeOfEntry.aspx.cs" Inherits="RPMS_Web.Pages.Documents.NoticeOfEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../../Content/Site.css" />
    <link rel="stylesheet" href="../../Content/bootstrap.css" />
    <link rel="stylesheet" href="../../Content/jquery-ui.css" />
    <script type="text/javascript" src="../../Scripts/Site.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-1.12.1.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.js"></script>
    <title>Sigler Property Eviction Notice</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container body-content">
        <div class="letter-head">
            Sigler Properties, LLC
        </div>
        <div class="tac">
            P.O.Box 2281<br />
            Coppell, TX<br />
            (972) 951-3617<br />
        </div>
        <br />
        <div class="w100 f120 tar">NOTICE OF ENTRY</div>
        <br />
        <br />
        <div>
            <asp:Literal runat="server" ID="litDateOfLetter" />
            <br />
            <br />
            <asp:Literal runat="server" ID="litTenants" />
            <br />
            <asp:Literal runat="server" ID="litStreet" />
            <br />
            <asp:Literal runat="server" ID="litCityStateZip" />
            <br />
            <br />
        </div>
        <br />
        <br />
        <div>
            It has become necessary to enter the Leased Premises for the reason described as:<br />
            <asp:Literal runat="server" ID="litReasonsForEntry" />
            <br /><br />
            We will need to be able to have access on <asp:Literal runat="server" ID="litDateOfEntry" /> at approximately <asp:Literal runat="server" ID="litTimeOfEntry" />.
            <br /><br />
            Thank you in advance for your full cooperation in this matter, and please feel free to contact me with any questions.
        </div>
        <br />
        <br />
        ____________________________________________________________
        <br />
        <br />
        Wade Sigler<br />
        CEO, Sigler Properties, LLC<br />
        (972) 951-3617
    </div>
    </form>
</body>
</html>
