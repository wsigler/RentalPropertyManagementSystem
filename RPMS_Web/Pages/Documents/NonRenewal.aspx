<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NonRenewal.aspx.cs" Inherits="RPMS_Web.Pages.Documents.NonRenewal" %>

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
    <title>Sigler Property Non Renewal</title>
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
                (972) 951-3617
            </div>
            <br />
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
                <b>TO TENANT(S) AND ALL OTHERS IN POSSESSION OF THE PREMISES LOCATED AT:</b>
                <br />
                <br />
                <asp:Literal runat="server" ID="litFullAddress" />
                <br />
                <br />
                <b>PLEASE TAKE NOTICE</b> that the lease under which you hold possession of the above described property will terminate pursuant 
                to its own terms on <asp:Literal runat="server" ID="litEndDate" /> and will not be renewed for a new term, nor allowed to be converted to a month-to-month 
                tenancy. Please do not tender any money that will pay rent beyond the end of the term. Please further be advised that any money 
                tendered, if accepted, will have been accepted in error and will be returned.
                <br />
                <br />
                <b>PLEASE TAKE FURTHER NOTICE</b> that you are required to surrender the premises to Wade and Rachel Sigler upon the termination 
                date. Please return the premises in the same condition as you found it upon move-in, normal wear and tear expected. Furthermore, 
                you are required to return all keys upon vacating the premises. Failure to vacate the premises on or before the termination date 
                will result in legal proceedings against you to recover possession of said premises.
                <br />
                <br />
                <b>LANDLORD RESERVES ALL THE RIGHTS AND REMEDIES PROVIDED UNDER THE RENTAL AGREEMENT AND UNDER APPLICABLE LAWS OF THE STATE OF TEXAS 
                    INCLUDING BUT NOT LIMITED TO DAMAGES FOR UNPAID RENT OR PROPERTY AND NOTHING IN THIS NOTICE MAY BE CONSTRUED AS A WAIVER OF SUCH 
                    RIGHTS AND REMEDIES.</b>
                <br />
                <br />
                Dated: <asp:Literal runat="server" ID="litDateOfLetter2" />
                <br />
                <br />
                By: 	__________________________________ 
                <br />
                <div style="padding-left:20px">
                    <p>Wade Sigler<br />
	                Sigler Properties<br />
	                P.O. Box 2281<br />
	                Coppell, Texas 75019<br />
	                (972) 951-3617</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
