<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PropertyDetail.aspx.cs" Inherits="RPMS_Web.Pages.Property.PropertyDetail" MasterPageFile="~/Site.Master" %>
<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>

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
        <div id="dragandrophandler">
            <iz:FileManager ID="fmCustomers" runat="server" Height="400" Width="600">
                <RootDirectories>
                    <iz:RootDirectory DirectoryPath="/Files/Properties/" Text="Property Files" ShowRootIndex="false" />
                </RootDirectories>
                <FileTypes>
                    <iz:FileType Extensions="zip, rar, iso" Name="Archive" SmallImageUrl="/images/16x16/compressed.gif" LargeImageUrl="/images/32x32/compressed.gif"></iz:FileType>
                    <iz:FileType Extensions="doc, rtf" Name="Microsoft Word Document" SmallImageUrl="/images/16x16/word.gif" LargeImageUrl="/images/32x32/word.gif"></iz:FileType>
                    <iz:FileType Extensions="xls, csv" Name="Microsoft Excel Worksheet" SmallImageUrl="/images/16x16/excel.gif" LargeImageUrl="/images/32x32/excel.gif"></iz:FileType>
                    <iz:FileType Extensions="ppt, pps" Name="Microsoft PowerPoint Presentation" SmallImageUrl="/images/16x16/PowerPoint.gif" LargeImageUrl="/images/32x32/PowerPoint.gif"></iz:FileType>
                    <iz:FileType Extensions="pdf" Name="Adobe PDF" SmallImageUrl="/images/16x16/pdf.png" LargeImageUrl="/images/32x32/pdf.png"></iz:FileType>                    
                    <iz:FileType Extensions="gif, jpg, png" Name="Image" SmallImageUrl="/images/16x16/image.gif" LargeImageUrl="/images/32x32/image.gif"></iz:FileType>
                    <iz:FileType SmallImageUrl="/images/16x16/media.gif" Name="Windows Media File" Extensions="mp3,wma,vmv,avi,divx" LargeImageUrl="/images/32x32/media.gif"></iz:FileType>
                    <iz:FileType Extensions="txt" Name="Text Document">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="xml, xsl, xsd" Name="XML Document" LargeImageUrl="/images/32x32/xml.gif" SmallImageUrl="/images/16x16/xml.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="css" Name="Cascading Style Sheet" LargeImageUrl="/images/32x32/styleSheet.gif" SmallImageUrl="/images/16x16/styleSheet.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="js, vbs" Name="Script File" LargeImageUrl="/images/32x32/script.gif" SmallImageUrl="/images/16x16/script.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                    <iz:FileType Extensions="htm, html" Name="HTML Document" LargeImageUrl="/images/32x32/html.gif" SmallImageUrl="/images/16x16/html.gif">
                        <Commands>
                            <iz:FileManagerCommand Name="Edit with WYSWYG editor" CommandName="WYSWYG" />
                            <iz:FileManagerCommand Name="Edit" CommandName="EditText" SmallImageUrl="/images/16x16/edit.gif" />
                        </Commands>
                    </iz:FileType>
                </FileTypes>
            </iz:FileManager>
        </div>
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
