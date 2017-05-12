<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RPMS_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>Property Management Dashboard</h2>
        <hr />
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Rented Properties
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <a href="Pages/Property/PropertyList.aspx">Property List</a>
                                    <asp:Repeater runat="server" id="repPropertiesRented">
                                        <HeaderTemplate>
                                            <table class="table table-striped w100">
                                                <tr>
                                                    <th class="table-headers tableHead w30">Address</th>
                                                    <th class="table-headers tableHead w20">Lease Exp. Date</th>
                                                    <th class="table-headers tableHead w20 tar">Rent Current</th>
                                                    <th class="w25">&nbsp;</th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <tr>
                                                    <td><asp:Literal runat="server" ID="litStreetAddress" /></td>
                                                    <td><asp:Literal runat="server" ID="litLeaseExpireDate" /></td>
                                                    <td class="tar"><asp:CheckBox runat="server" ID="cbRentCurrent" /></td>
                                                    <td class="f80 tar">
                                                        <asp:HyperLink runat="server" ID="hlDetails" Text="Details"/> | 
                                                        <asp:HyperLink runat="server" ID="hlMakePayment" Text="Make Payment"/>
                                                    </td>
                                                </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Available Properties
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <a href="Pages/Property/PropertyList.aspx">Property List</a>
                                    <asp:Repeater runat="server" id="repAvailProperties">
                                        <HeaderTemplate>
                                            <table class="table table-striped w100">
                                                <tr>
                                                    <th class="table-headers tableHead w25">Address</th>
                                                    <th class="table-headers tableHead w10 tar">Rent</th>
                                                    <th class="table-headers tableHead w10 tar">Deposit</th>
                                                    <th class="table-headers tableHead w10 tar">Bdr #</th>
                                                    <th class="table-headers tableHead w10 tar">Bath #</th>
                                                    <th class="table-headers tableHead w8 tac">W/D</th>
                                                    <th class="table-headers tableHead w7 tac">A/C</th>
                                                    <th class="w15">&nbsp;</th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <tr>
                                                    <td><asp:Literal runat="server" ID="litStreetAddress" /></td>
                                                    <td class="tar"><asp:Literal runat="server" ID="litRent" /></td>
                                                    <td class="tar"><asp:Literal runat="server" ID="litDeposit" /></td>
                                                    <td class="tar"><asp:Literal runat="server" ID="litBedrooms" /></td>
                                                    <td class="tar"><asp:Literal runat="server" ID="litBathrooms" /></td>
                                                    <td class="tac"><asp:CheckBox runat="server" ID="cbWD" /></td>
                                                    <td class="tac"><asp:CheckBox runat="server" ID="cbAC" /></td>
                                                    <td class="f80 tar">
                                                        <asp:HyperLink runat="server" ID="hlDetails" Text="Details"/>
                                                    </td>
                                                </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Current Leases
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                  <a href="Pages/Lease/LeaseList.aspx">Lease List</a>
                                    <div class="table-responsive">
                                        <asp:Repeater runat="server" id="repLeases">
                                            <HeaderTemplate>
                                                <table class="table table-striped w100">
                                                    <tr>
                                                        <th class="table-headers tableHead w5">Rented</th>
                                                        <th class="table-headers tableHead w35">Address</th>
                                                        <th class="table-headers tableHead w20">Tenant</th>
                                                        <th class="table-headers tableHead w10">Start Date</th>
                                                        <th class="table-headers tableHead w10">End Date</th>
                                                        <th class="w20">&nbsp;</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                    <tr>
                                                        <td class="tac"><asp:CheckBox runat="server" ID="cbIsRented" /></td>
                                                        <td><asp:HyperLink runat="server" ID="hlStreetAddress" /></td>
                                                        <td><asp:HyperLink runat="server" ID="hlTenantName" /></td>
                                                        <td><asp:Literal runat="server" ID="litStartDate" /></td>
                                                        <td><asp:Literal runat="server" ID="litEndDate" /></td>
                                                        <td style="font-size: .8em;">
                                                            <asp:HyperLink runat="server" ID="hlLease" Text="Renew Lease"/>
                                                        </td>
                                                    </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Tenant Quick List
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <a href="Pages/Tenant/TenantList.aspx">Tenant List</a>
                                    <asp:Repeater runat="server" ID="repTenants">
                                        <HeaderTemplate>
                                            <table class="table table-striped w100">
                                                <tr>
                                                    <th class="table-headers w20">Name</th>
                                                    <th class="table-headers w30">Address</th>
                                                    <th class="table-headers w20">Phone</th>
                                                    <th class="w30">&nbsp;</th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <tr>
                                                    <td><asp:Literal runat="server" ID="litFullName" /></td>
                                                    <td><asp:Literal runat="server" ID="litStreetAddress1" /></td>
                                                    <td><asp:Literal runat="server" ID="litPhone" /></td>
                                                    <td class="f80 tar">
                                                        <asp:HyperLink runat="server" ID="hlDetails" Text="Details"/> 
                                                        <asp:HyperLink runat="server" ID="hlLease" Text="Create Lease"/>

                                                    </td>
                                                </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            New Property Listing feed ??
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <asp:Repeater ID="repFeed" runat="server">
                                        <HeaderTemplate></HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal runat="server" ID="lt" />
                                        </ItemTemplate>
                                        <FooterTemplate></FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
