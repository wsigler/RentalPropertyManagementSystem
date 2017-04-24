<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyDetail.aspx.cs" Inherits="RPMS_Web.Pages.Property.PropertyDetail" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-horizontal">
        <h2>Property Detail</h2>
        <hr />
        <div>
            <a href="PropertyList.aspx">Back To List</a> |
            <asp:HyperLink runat="server" ID="hlEditProperty">Edit</asp:HyperLink>
        </div>
        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Property Info</legend>
            <div class="row">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <address>
                        <asp:Literal runat="server" ID="litAddress" />
                    </address>
                    Active: <asp:Literal runat="server" ID="litActive" /> <br />
                    Sq Footage: <asp:Literal runat="server" ID="litSquareFootageEst" /><br />
                    Rented: <asp:Literal runat="server" ID="litIsRented" /><br />
                    Estimated Tax: <asp:Literal runat="server" ID="litEstimatedTax" /><br />
                    Lat: <div id="divLat" style="display:inline;"><asp:Literal runat="server" ID="litLat" /></div><br />
                    Long: <div id="divLong" style="display:inline;"><asp:Literal runat="server" ID="litLong" /></div><br />
                    <asp:Literal runat="server" ID="litTenantLable" Text="Current Tenant(s):" /> <asp:Literal runat="server" ID="litCurrentTenant" />
                </div>
                <div class="col-xs-9 col-sm-9 col-md-9 col-lg-9">
                    <div id="googleMap" style="width:100%;height:250px;"></div>
                </div>
            </div>

        </fieldset>
        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Rental Rates</legend>
            <div class="row">
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    Rent: <asp:Literal runat="server" ID="litRentAmount" />
                </div>
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    Deposit: <asp:Literal runat="server" ID="litDepositAmount" />
                </div>
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    Pet Deposit: <asp:Literal runat="server" ID="litPetDepositAmount" />
                </div>
            </div>
        </fieldset>
        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Amenities</legend>
            <div class="row">
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    Bedrooms: <asp:Literal runat="server" ID="litNumberOfBedrooms" />
                </div>
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    Bathrooms: <asp:Literal runat="server" ID="litNumberOfBathrooms" />
                </div>
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    Trash Day: <asp:Literal runat="server" ID="litDayOfTheWeek" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    W/D: <asp:Literal runat="server" ID="litHasWDConnection" />
                </div>
                <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                    A/C: <asp:Literal runat="server" ID="litHasCentralAC" />
                </div>
            </div>
        </fieldset>
        <fieldset class="form-group" style="margin-right: 0px; margin-left:0px">
            <legend>Auditing</legend>
            <div class="row">
                <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                    <asp:Literal runat="server" ID="litCreateAudit" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                    <asp:Literal runat="server" ID="litModifyAudit" />                        
                </div>
            </div>
        </fieldset>


        <%--<script>
        function myMap() {
        var mapProp= {
            center: new google.maps.LatLng(33.583508, -96.180505),
            zoom:5,
        };
        var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);
        }
    </script>--%>

    
    </div>

</asp:Content>
