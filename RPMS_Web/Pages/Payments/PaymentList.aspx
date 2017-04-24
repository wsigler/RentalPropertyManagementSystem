<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentList.aspx.cs" Inherits="RPMS_Web.Pages.Payments.PaymentList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Rent Payments</h2>
    <hr />
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                Information
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">Tenant(s)</div>
                    <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">Property</div>
                </div>
                <div class="row">
                    <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        <asp:Literal runat="server" ID="litTenants" />
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                        <address>
                            <asp:Literal runat="server" ID="litAddress" />
                        </address>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="table-responsive">
        <asp:Repeater runat="server" id="repPayments">
            <HeaderTemplate>
                <table class="table table-striped w60">
                    <tr>
                        <th class="table-headers tableHead w15">Payment Date</th>
                        <th class="table-headers tableHead w15 tar">Payment Amount</th>
                        <th class="table-headers tableHead w20">Paid Date</th>
                        <th class="table-headers tableHead w15 tar">Amount Paid</th>
                        <th class="table-headers tableHead w15 tar">Balance</th>
                        <th class="w20 tar">&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td><asp:Literal runat="server" ID="litPaymentDate" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litPaymentAmount" /></td>
                        <td><asp:Literal runat="server" ID="litPaidDate" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litAmountPaid" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litBalance" /></td>
                        <td class="f80 tar">
                            <asp:HyperLink runat="server" ID="hlLease" Text="Make Payment"/>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td colspan="2" class="tar f120">Total Balance: $<asp:Literal runat="server" ID="litTotalBalance" /></td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
