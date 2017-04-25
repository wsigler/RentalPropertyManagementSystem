<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eviction.aspx.cs" Inherits="RPMS_Web.Pages.Documents.Eviction" %>

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
        <div class="w100 f120 tar">3 DAY NOTICE TO VACATE<br />DEMAND FOR PAYMENT</div>
        <br />
        <br />
        <div>
            Sigler Properties, LLC<br />
            P.O. Box 2281<br />
            Coppell, TX. 75019
        </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <div>
            <asp:Literal runat="server" ID="litTenantNames" /><br />
            <asp:Literal runat="server" ID="litAddress" />
        </div>
        <div id='page-break-after-div' style='width: 100%;'></div>
        <div class="w100" style="padding:10px;">&nbsp;</div> 
        <div class="letter-head">
            Sigler Properties, LLC
        </div>
        <br /><br /><br />
        To: <asp:Literal runat="server" ID="litTenantNames2" />
        <br />
        <br />
        From: Sigler Properties, LLC
        <br />
        <br />
        Date of Notice: <asp:Literal runat="server" ID="litDateOfNotice" />
        <br />
        <br />
        RE: <asp:Literal runat="server" ID="litStreetAddress" />
        <br />
        <br />
        <br />
        <br />
        To: Tenants Listed Above and All Persons Now in Possession of the Leased Premises,
        <br />
        <br />
        <br />
        <br />
        As of the date of this notice, you are past due for the total amount of: $<asp:Literal runat="server" ID="litPastDueAmount" />
        <br />
        <br />
        <br />
        <br />
        <b>NOTICE:</b> You are hereby required to vacate the premises, within <b>THREE DAYS</b> after service on you of this notice. In the event that 
        the premises at <asp:Literal runat="server" ID="litStreetAddress2" />, in <asp:Literal runat="server" ID="litCounty" /> County are not vacated by you within 3 days from delivery of this notice, 
        I/we will file a Forcible Detainer suit against you.  
        <br />
        <br />
        <br />
        <br />
        Additionally if any rent is due, I/we will file a suit for the recovery of that rent and such other charges as may be permitted under the terms of the lease or the laws of the State of Texas. 
        <br />
        <br />
        <br />
        <br />
        ____________________________________________________________
        <br />
        <br />
        Wade Sigler<br />
        CEO, Sigler Properties, LLC
        <div id='page-break-after-div' style='width: 100%;'></div>
        <div class="w100" style="padding:10px;">&nbsp;</div> 
        <div class="letter-head">
            Sigler Properties, LLC
        </div>
        <br /><br /><br />
        SERVICE OF NOTICE  
        <br />
        <br />
        <br />
        I hereby certify that a copy of the following Notice was served upon the above named tenant(s) at the above address on the following 
        date: <asp:Literal runat="server" ID="litDateOfNotice2" /> by the following means: (check all that apply)  
        <br />
        <br />
        ___Certified Mail - Return Receipt Requested  
        <br />
        <br />
        ___Regular Mail  
        <br />
        <br />
        ___Hand delivered to PRINT NAME:_________________________X SIGNATURE:__________________________  
        <br />
        <br />
        ___Posted a copy at the premises  
        <br />
        <br />
        <br />
        <br />
        ____________________________________  
        <br />
        Wade Sigler<br />
        CEO, Sigler Properties, LLC  
    </div>
    </form>
</body>
</html>
