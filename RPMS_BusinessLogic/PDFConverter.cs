using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoPdf;
using System.IO;

namespace RPMS_BusinessLogic
{
    public class PDFConverter
    {
        public const string fileExtension = ".pdf";

        #region PDF Pages

        public string ConvertLeaseToPDF(string host, int leaseID, string tenantDir, string filePath)
        {
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "93lpeGtreGtuYXhudmh4a2l2aWp2YWFhYXho";

            // Install a handler where you can set header and footer visibility or create a custom header and footer in each page
            htmlToPdfConverter.PrepareRenderPdfPageEvent += new PrepareRenderPdfPageDelegate(htmlToPdfConverter_PrepareRenderPdfPageEvent);

            #region Not Used
            // Add Header

            //// Enable header in the generated PDF document
            //htmlToPdfConverter.PdfDocumentOptions.ShowHeader = true;

            //// Optionally add a space between header and the page body
            //// The spacing for first page and the subsequent pages can be set independently
            //// Leave this option not set for no spacing
            //htmlToPdfConverter.PdfDocumentOptions.Y = 10;
            //htmlToPdfConverter.PdfDocumentOptions.TopSpacing = 5;

            //// Draw header elements
            //if (htmlToPdfConverter.PdfDocumentOptions.ShowHeader)
            //    DrawHeader(htmlToPdfConverter, true, customerId, host, header, endDate);

            // Enable footer in the generated PDF document
            //htmlToPdfConverter.PdfDocumentOptions.ShowFooter = true;

            // Optionally add a space between footer and the page body
            // Leave this option not set for no spacing
            //htmlToPdfConverter.PdfDocumentOptions.BottomSpacing = 20;

            #endregion

            // Set the CSS selectors of the HTML elements after which to insert page breaks
            htmlToPdfConverter.PdfDocumentOptions.PageBreakAfterHtmlElementsSelectors = new string[] { "#page-break-after-div" };


            // Convert the HTML page to a PDF document in a memory buffer
            var url = string.Format("http://{0}/Pages/Lease/Lease.aspx?id={1}", host, leaseID.ToString());
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);

            int count = 1;
            string tempFileName = tenantDir + filePath;

            if (!File.Exists(tenantDir))
            {
                // create dir
                Directory.CreateDirectory(tenantDir);
            }

            while (File.Exists(tempFileName + fileExtension))
            {
                count++;
                tempFileName = string.Format("{0}{1}({2})", tenantDir, filePath, count);
            }

            // Send the PDF as response to browser
            var newFilePath = tempFileName + fileExtension;

            // Send the PDF as response to browser
            File.WriteAllBytes(newFilePath, outPdfBuffer);

            return newFilePath;
        }

        public string ConvertNonRenewalToPDF(string host, int tenantID, string tenantDir, string filePath)
        {
            // Create a HTML to PDF converter object with default settings
            HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            // Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            htmlToPdfConverter.LicenseKey = "93lpeGtreGtuYXhudmh4a2l2aWp2YWFhYXho";

            // Install a handler where you can set header and footer visibility or create a custom header and footer in each page
            htmlToPdfConverter.PrepareRenderPdfPageEvent += new PrepareRenderPdfPageDelegate(htmlToPdfConverter_PrepareRenderPdfPageEvent);

            #region Not Used
            // Add Header

            //// Enable header in the generated PDF document
            //htmlToPdfConverter.PdfDocumentOptions.ShowHeader = true;

            //// Optionally add a space between header and the page body
            //// The spacing for first page and the subsequent pages can be set independently
            //// Leave this option not set for no spacing
            //htmlToPdfConverter.PdfDocumentOptions.Y = 10;
            //htmlToPdfConverter.PdfDocumentOptions.TopSpacing = 5;

            //// Draw header elements
            //if (htmlToPdfConverter.PdfDocumentOptions.ShowHeader)
            //    DrawHeader(htmlToPdfConverter, true, customerId, host, header, endDate);

            // Enable footer in the generated PDF document
            //htmlToPdfConverter.PdfDocumentOptions.ShowFooter = true;

            // Optionally add a space between footer and the page body
            // Leave this option not set for no spacing
            //htmlToPdfConverter.PdfDocumentOptions.BottomSpacing = 20;

            #endregion

            // Set the CSS selectors of the HTML elements after which to insert page breaks
            htmlToPdfConverter.PdfDocumentOptions.PageBreakAfterHtmlElementsSelectors = new string[] { "#page-break-after-div" };


            // Convert the HTML page to a PDF document in a memory buffer
            var url = string.Format("http://{0}/Pages/Documents/NonRenewal.aspx?id={1}", host, tenantID.ToString());
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);

            int count = 1;
            string tempFileName = tenantDir + filePath;

            if (!File.Exists(tenantDir))
            {
                // create dir
                Directory.CreateDirectory(tenantDir);
            }

            while (File.Exists(tempFileName + fileExtension))
            {
                count++;
                tempFileName = string.Format("{0}{1}({2})", tenantDir, filePath, count);
            }

            // Send the PDF as response to browser
            var newFilePath = tempFileName + fileExtension;

            // Send the PDF as response to browser
            File.WriteAllBytes(newFilePath, outPdfBuffer);

            return newFilePath;
        }

        #endregion

        /// <summary>
        /// The handler for HtmlToPdfConverter.PrepareRenderPdfPageEvent event where you can set the visibility of header and footer
        /// in each page or you can add a custom header or footer in a page
        /// </summary>
        /// <param name="eventParams">The event parameter containin the PDF page to customize before rendering</param>
        protected void htmlToPdfConverter_PrepareRenderPdfPageEvent(PrepareRenderPdfPageParams eventParams)
        {
            // Set the header visibility for all pages
            eventParams.Page.ShowHeader = true;
        }
    }
}
