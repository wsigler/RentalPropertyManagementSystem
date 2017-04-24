$().ready(function ()
{
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_pageLoading(loadingPage);
    prm.add_pageLoaded(loadedPage);
    prm.add_beginRequest(startPage);
    prm = null;
});

function loadingPage(sender, args) {
    //var updatePanels = args.get_panelsUpdating();

}

function loadedPage(sender, args) {
    // set up Product Inventory Accordion toggle
    //SetupProductInventoryAccordion();

    $('.datepicker').datepicker(
    {
        dateFormat: 'mm/dd/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '1950:2100'
    });

    $('.expandedDiv').off('click').click(function () {
        if ($(this).hasClass('off')) {
            // show
            $(this).removeClass('off');

            // set hidden var
            //$(this).closest('div.s').find('input.hidden').val('0');
        }
        else {
            // hide
            $(this).addClass('off');

            // set hidden var
            //$(this).closest('div.s').find('input.hidden').val('1');
        }

        // toggle
        //$(this).closest('div.s').find('div.s-body').slideToggle('fast');

    });

    myMap();
}

function startPage() {
    //document.body.style.cursor = "wait";
}

function myMap() {
    var myCenter = new google.maps.LatLng($("#divLat").text(), $("#divLong").text());
    var mapCanvas = document.getElementById("googleMap");
    var mapOptions = { center: myCenter, zoom: 17 };
    var map = new google.maps.Map(mapCanvas, mapOptions);
    var marker = new google.maps.Marker({ position: myCenter });
    marker.setMap(map);
}



