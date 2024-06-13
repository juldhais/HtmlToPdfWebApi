using HtmlToPdfWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HtmlToPdfWebApi.Controllers;
[Route("api/invoice")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly HtmlToPdfService htmlToPdfService;

    public InvoiceController(HtmlToPdfService htmlToPdfService)
    {
        this.htmlToPdfService = htmlToPdfService;
    }

    private string htmlContent = @"<!DOCTYPE html>
    <html lang=""en"">
    <head>
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <title>Invoice</title>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                background-color: #f4f4f4;
            }
            .invoice-box {
                max-width: 800px;
                margin: 20px auto;
                padding: 30px;
                border: 1px solid #eee;
                background-color: #fff;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
            }
            .invoice-box table {
                width: 100%;
                line-height: inherit;
                text-align: left;
                border-collapse: collapse;
            }
            .invoice-box table td {
                padding: 8px;
                vertical-align: top;
            }
            .invoice-box table tr td:nth-child(2) {
                text-align: right;
            }
            .invoice-box table tr.top table td {
                padding-bottom: 20px;
            }
            .invoice-box table tr.top table td.title {
                font-size: 45px;
                line-height: 45px;
                color: #333;
            }
            .invoice-box table tr.information table td {
                padding-bottom: 40px;
            }
            .invoice-box table tr.heading td {
                background: #eee;
                border-bottom: 1px solid #ddd;
                font-weight: bold;
            }
            .invoice-box table tr.item td {
                border-bottom: 1px solid #eee;
            }
            .invoice-box table tr.item.last td {
                border-bottom: none;
            }
            .invoice-box table tr.total td:nth-child(2) {
                border-top: 2px solid #eee;
                font-weight: bold;
            }
        </style>
    </head>
    <body>
        <div class=""invoice-box"">
            <table>
                <tr class=""top"">
                    <td colspan=""2"">
                        <table>
                            <tr>
                                <td class=""title"">
                                    <h2>Invoice</h2>
                                </td>
                                <td>
                                    Invoice #: 123<br>
                                    Created: January 1, 2024<br>
                                    Due: January 15, 2024
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class=""information"">
                    <td colspan=""2"">
                        <table>
                            <tr>
                                <td>
                                    Billing to:<br>
                                    John Doe<br>
                                    1234 Main St.<br>
                                    Springfield, IL 62704
                                </td>
                                <td>
                                    Company Name<br>
                                    info@company.com
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class=""heading"">
                    <td>Item</td>
                    <td>Price</td>
                </tr>
                <tr class=""item"">
                    <td>Website design</td>
                    <td>$300.00</td>
                </tr>
                <tr class=""item"">
                    <td>Hosting (3 months)</td>
                    <td>$75.00</td>
                </tr>
                <tr class=""item"">
                    <td>Domain name (1 year)</td>
                    <td>$10.00</td>
                </tr>
                <tr class=""item last"">
                    <td>SEO Optimization</td>
                    <td>$150.00</td>
                </tr>
                <tr class=""total"">
                    <td></td>
                    <td>Total: $535.00</td>
                </tr>
            </table>
        </div>
    </body>
    </html>
    ";

    [HttpGet("pdf")]
    public async Task<FileResult> GetPdf(CancellationToken cancellationToken)
    {
        var pdfContent = await htmlToPdfService.ToByteArray(htmlContent);
        return File(pdfContent, "application/pdf", "invoice.pdf");
    }
}