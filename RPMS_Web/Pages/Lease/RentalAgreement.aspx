<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentalAgreement.aspx.cs" Inherits="RPMS_Web.Pages.Lease.RentalAgreement" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script type = "text/javascript">
         function SetTarget() {
             document.forms[0].target = "_blank";
         }
    </script>--%>

    <h2>Lease Agreement Information Sheet</h2>
    <hr />
    <asp:Panel runat="server" ID="pnlTenant">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Address
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">Property</div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                            <address>
                                <asp:Literal runat="server" ID="litAddress" />
                            </address>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default" runat="server" id="divTenants">
                <div class="panel-heading">
                    Tenant(s)
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            Primary: <asp:Literal runat="server" ID="litName" /> 
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            Email: <asp:Literal runat="server" ID="litEmail" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            <asp:Literal runat="server" ID="litOtherTenants" /> 
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            Number of Children: 
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            Max Number of Occupants:
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumberOfChildren" /> 
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                           <asp:TextBox runat="server" CssClass="form-control" ID="txtMaxNumOfOccupants" /> 
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    Financial Info
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Rent</div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Deposit Amount</div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Pet Deposit Amount</div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRent" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDeposit" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPetDeposit" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    Dates
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Deposit Date</div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">Start Date</div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">End Date</div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtDepositDate" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtStartDate" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtEndDate" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <br />
        <br />
        <div class="form-group">
            <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10">
            </div>
            <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2 right">
                <%--<asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success"  OnClick="btnCreate_Click" OnClientClick="SetTarget();"/>--%>
                <asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success"  OnClick="btnCreate_Click"/>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
