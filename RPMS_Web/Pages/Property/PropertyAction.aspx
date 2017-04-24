<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyAction.aspx.cs" Inherits="RPMS_Web.Pages.Property.PropertyAction" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h2><asp:Literal runat="server" ID="litHeading" /></h2>
        <hr />
        <div>
            <a href="PropertyList.aspx">Back To List</a>
        </div>
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Address
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Street Address
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            City
                        </div>
                        <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                            State
                        </div>
                        <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                            Zip
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtStreetAddress1" />
                            <div style="margin-top:3px;">
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtStreetAddress2" />
                            </div>
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCity" />
                        </div>
                        <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                            <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" />                            
                        </div>
                        <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtZipCode" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            Lat
                        </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            Long
                        </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            Sq Ft
                        </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            Est Tax
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtLat" />
                        </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtLong" />
                        </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtSquareFootageEst" />
                        </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEstimatedTax" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Rental Rates
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Rent
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Deposit
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Pet Deposit
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtRentAmount" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDepositAmount" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPetDepositAmount" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Amenities
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Bedrooms
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Bathrooms
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            Trash Day
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumberOfBedrooms" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNumberOfBathrooms" />
                        </div>
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:DropDownList runat="server" ID= "ddlTrashDay" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:CheckBox runat="server" ID="cbWDConnection" Text="W/D Connection" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:CheckBox runat="server" ID="cbAC" Text="Central A/C" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:CheckBox runat="server" ID="cbIsActive" Text="Active" />
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
                <asp:Button runat="server" ID="btnCreate" Text="Create" class="btn btn-success"  OnClick="btnCreate_Click"/>
            </div>
        </div>
    </div>

</asp:Content>