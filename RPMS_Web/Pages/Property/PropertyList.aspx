<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyList.aspx.cs" Inherits="RPMS_Web.Pages.Property.PropertyList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Property List</h2>
    <hr />
    <div>
        <a href="PropertyAction.aspx">Create New</a>
    </div>
    <div class="table-responsive">
        <asp:Repeater runat="server" id="repProperties">
            <HeaderTemplate>
                <table class="table table-striped w100">
                    <tr>
                        <th class="table-headers tableHead w3">Rented</th>
                        <th class="table-headers tableHead w12">Address</th>
                        <th class="table-headers tableHead w9">City</th>
                        <th class="table-headers tableHead w6">State</th>
                        <th class="table-headers tableHead w6">Zip</th>
                        <th class="table-headers tableHead w6 tar">Rent</th>
                        <th class="table-headers tableHead w6 tar">Deposit</th>
                        <th class="table-headers tableHead w7 tar">Pet Deposit</th>
                        <th class="table-headers tableHead w4 tar">Bdrms</th>
                        <th class="table-headers tableHead w4 tar">Bth</th>
                        <th class="table-headers tableHead w6 tar">Sq Ft</th>
                        <th class="table-headers tableHead w6 tar">Est Tax</th>
                        <th class="table-headers tableHead w3">W/D</th>
                        <th class="table-headers tableHead w3">A/C</th>
                        <th class="w15">&nbsp;</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td class="tac"><asp:CheckBox runat="server" ID="cbIsRented" /></td>
                        <td><asp:Literal runat="server" ID="litStreetAddress" /></td>
                        <td><asp:Literal runat="server" ID="litCity" /></td>
                        <td><asp:Literal runat="server" ID="litState" /></td>
                        <td><asp:Literal runat="server" ID="litZip" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litRentAmount" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litDepositAmount" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litPetDepositAmount" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litNumberOfBedrooms" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litNumberOfBathrooms" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litSquareFootageEst" /></td>
                        <td class="tar"><asp:Literal runat="server" ID="litEstimatedTax" /></td>
                        <td class="tac"><asp:CheckBox runat="server" ID="cbHasWDConnection" /></td>
                        <td class="tac"><asp:CheckBox runat="server" ID="cbHasCentralAC" /></td>
                        <td class="f80 tar">
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit"/> |
                            <asp:HyperLink runat="server" ID="hlDetails" Text="Details"/> |
                            <asp:HyperLink runat="server" ID="hlLease" Text="Blank Lease"/>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
