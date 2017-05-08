<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="RPMS_Web.Pages.Payments.MakePayment" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>Make Payment</h2>
        <hr />
        <div>
            <asp:HyperLink runat="server" ID="hlBackToList">Back To List</asp:HyperLink>                
        </div>
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Address
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                            <address>
                                <asp:Literal runat="server" ID="litAddress" />
                            </address>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Tenant(s)
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                            <asp:Literal runat="server" ID="litTenants" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Payment
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Amount Due: <asp:Literal runat="server" ID="litAmountDue" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Due Date: <asp:Literal runat="server" ID="litDueDate" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Balance: <asp:Literal runat="server" ID="litBalance" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Amount to pay
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Date
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPaymentAmount" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control datepicker" ID="txtPaymentDate" />
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
                <asp:Button runat="server" ID="btnSubmitPayment" Text="Submit Payment" class="btn btn-success"  OnClick="btnSubmitPayment_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
