using Flurl.Http;
using GatewayApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GatewayApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> QrCode()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> CreditPayment()
        {
            string apikey = "fb4e35c9374940d7813ec3ae83b00024";
            string MerchantID = "UATAreeya";
            double Amount = 3200.5;
            //// multiple: 
            //  await url.WithHeaders(new { "apiKey"=apikey, Authorization = "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjJXOVpsMmtjR2ZNbExSZnU3dE9ON2ciLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MDI1NjU3MjUsImV4cCI6MTYzNDEyMjY3NywiaXNzIjoiaHR0cHM6Ly9pZGVudGl0eS1zZXJ2ZXIuc2l0LXBhY28uMmMycC5jb20iLCJhdWQiOiJQYUNvQVBJIiwiY2xpZW50X2lkIjoiQXNwTmV0Q29yZUlkZW50aXR5Iiwic3ViIjoiNTFlMzE2MDMtY2M3ZC00MWQ0LWIxYzgtNDAzY2NjM2FkYTUyIiwiYXV0aF90aW1lIjoxNjAyNTY1NzI0LCJpZHAiOiJsb2NhbCIsImNvbXBhbnlJZCI6ImYyOTNiZjM1M2VjMjRlZWFiMzdiOTllYjg0NmZkNjExIiwib3JnYW5pemF0aW9uSWQiOiIyIiwibmFtZSI6Im1yIENvbXBhbnkgQWRtaW4iLCJlbWFpbCI6ImFsZXhhbmRlci5wZXJAMmMycC5jb20iLCJ0ZW5hbnQiOiJtYWIiLCJncm91cElkIjoiNWIyOWFjYmEtYjVmZC00Y2UyLTg1MTYtMzRmNGViZGMxZTY0IiwiZ3JvdXBOYW1lIjoiQ29tcGFueSBBZG1pbnMiLCJsYXN0TG9nZ2VkSW4iOiIxMC8xMy8yMDIwIDA1OjA4OjQ0Iiwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsIlBhQ29BUEkiLCJvZmZsaW5lX2FjY2VzcyJdLCJhbXIiOlsicHdkIl19.CjyoBHCHUBlQ_M6ozfDlCot47peSf5LH2y3MpJaSrv5BW8uCs1qB-Yrh704057LEpM6JsN6f9wSK_HQB_Fao0nUdF4yKKEvVYv5oRTWfeHm520PNqrxgaDf9rQCu0-YTIDqDSpAWcyFPbkNitHq1m-fR0LYAK15Fr2ScU5q0-zzC4MDwI44PmnoPxDru_WM7AQUtisASNkQiBcoZc7UD2EraL-aaQuIPVbp-EseZWcAto4GZ2aPHnnUEKznaR60lWXRtqxv2bL7gYFOtB1b8x7LD1Q6FUV_K3nTPUO7cTXOGtzbk7VQrNKaSYEv-nhJQPJgRD0NLST5N_-eBZL-yvA" }).GetJsonAsync();
            CreditPaymentNonUI payment = new CreditPaymentNonUI();
            payment.apiRequest = new ApiRequest { language = "en-US", requestDateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffZ"), requestMessageID = Guid.NewGuid().ToString() };
            payment.officeId = MerchantID;
            payment.orderNo = $"post{DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
            payment.productDescription = $"Postman PPage {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
            payment.paymentCategory = "ECOM";
            payment.paymentType = "CC";
            payment.preferredPaymentTypes = new List<string> { "IPP", "CC" };
            payment.channelCode = "WEBPAY";
            payment.agentCode = "FPX_SBIA";
            payment.mcpFlag = "N";
            payment.request3dsFlag = "N";
            payment.transactionAmount = new TransactionAmount
            {
                amountText = (Amount * 100).ToString().PadLeft(12, '0'),
                currencyCode = "THB",
                decimalPlaces = 2,
                amount = Amount
            };
            payment.notificationURLs = new NotificationURLs
            {
                confirmationURL = "http://confirmation-url2c2p.com",
                failedURL = "http://failed-url2c2p.com",
                cancellationURL = "https://cancellation-url2c2p.com",
                backendURL = "http://backend-url2c2p.com"
            };
            payment.autoRedirectDelayTimer = 45;

            payment.generalPayerDetails = new GeneralPayerDetails
            {
                personType = "general",
                seqNo = 1,
                personName = new PersonName
                {
                    fullName = "Mr. Attasit Thipsongkhroh",
                    title = "Mr.",
                    firstName = "Attasit",
                    middleName = "string",
                    lastName = "Thipsongkhroh"
                },
                email = "attasit@2c2p.com",
                mobilePhone = "+66868124717",
                businessPhone = "+6621167000"
            };

            payment.billingAddress = new BillingAddress
            {
                billAddrCity = "Bangkok",
                billAddrCountry = "764",
                billAddrLine1 = "Bill Address Line 1",
                billAddrLine2 = "Bill Address Line 2",
                billAddrLine3 = "Bill Address Line 3",
                billAddrPostCode = "10230",
                billAddrState = "N/A",
                addrMatch = "Y"

            };
            payment.deviceDetails = new DeviceDetails
            {
                browser = "Firefox 77.0",
                browserAcceptHeader = "application/json",
                browserIP = "0.0.0.1",
                browserJavaEnabled = "Y",
                browserLanguage = "en-US",
                browserColorDepth = "1",
                browserScreenHeight = "480",
                browserScreenWidth = "640",
                browserTZ = "56",
                browserUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:84.0) Gecko/20100101 Firefox/84.0",
                mobileDeviceFlag = "N"
            };
            payment.purchaseItems = new List<PurchaseItem> {
           new PurchaseItem {
            purchaseItemType= "ticket",
            referenceNo= "2322460376026",
            purchaseItemDescription= "Bundled insurance",
            purchaseItemPrice= new PurchaseItemPrice {
           amountText= "000000999950",
           currencyCode= "THB",
           decimalPlaces= 2,
           amount= 9999.5
                },
                subMerchantID= "string",
                passengerSeqNo= 1
            }
             };

            payment.customFieldList = new List<CustomFieldList>  {
             new CustomFieldList  {
               fieldName ="ExternalID5",
               fieldValue ="AMADEUS"
               },
               new CustomFieldList {
                fieldName= "Remark",
                fieldValue= "Test remark from Postman"
                },
               new CustomFieldList  {
                fieldName= "orderRef2",
                 fieldValue= "ref2"
                },
              new CustomFieldList   {
                fieldName= "orderRef4",
                 fieldValue ="ref4 yes"
                },
             new CustomFieldList    {
                fieldName= "orderRef1",
                fieldValue= "Reference number one"
                }
            };
            try
            {
                //// multiple: 
                //  await url.WithHeaders(new { "apiKey"=apikey, Authorization = "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjJXOVpsMmtjR2ZNbExSZnU3dE9ON2ciLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MDI1NjU3MjUsImV4cCI6MTYzNDEyMjY3NywiaXNzIjoiaHR0cHM6Ly9pZGVudGl0eS1zZXJ2ZXIuc2l0LXBhY28uMmMycC5jb20iLCJhdWQiOiJQYUNvQVBJIiwiY2xpZW50X2lkIjoiQXNwTmV0Q29yZUlkZW50aXR5Iiwic3ViIjoiNTFlMzE2MDMtY2M3ZC00MWQ0LWIxYzgtNDAzY2NjM2FkYTUyIiwiYXV0aF90aW1lIjoxNjAyNTY1NzI0LCJpZHAiOiJsb2NhbCIsImNvbXBhbnlJZCI6ImYyOTNiZjM1M2VjMjRlZWFiMzdiOTllYjg0NmZkNjExIiwib3JnYW5pemF0aW9uSWQiOiIyIiwibmFtZSI6Im1yIENvbXBhbnkgQWRtaW4iLCJlbWFpbCI6ImFsZXhhbmRlci5wZXJAMmMycC5jb20iLCJ0ZW5hbnQiOiJtYWIiLCJncm91cElkIjoiNWIyOWFjYmEtYjVmZC00Y2UyLTg1MTYtMzRmNGViZGMxZTY0IiwiZ3JvdXBOYW1lIjoiQ29tcGFueSBBZG1pbnMiLCJsYXN0TG9nZ2VkSW4iOiIxMC8xMy8yMDIwIDA1OjA4OjQ0Iiwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsIlBhQ29BUEkiLCJvZmZsaW5lX2FjY2VzcyJdLCJhbXIiOlsicHdkIl19.CjyoBHCHUBlQ_M6ozfDlCot47peSf5LH2y3MpJaSrv5BW8uCs1qB-Yrh704057LEpM6JsN6f9wSK_HQB_Fao0nUdF4yKKEvVYv5oRTWfeHm520PNqrxgaDf9rQCu0-YTIDqDSpAWcyFPbkNitHq1m-fR0LYAK15Fr2ScU5q0-zzC4MDwI44PmnoPxDru_WM7AQUtisASNkQiBcoZc7UD2EraL-aaQuIPVbp-EseZWcAto4GZ2aPHnnUEKznaR60lWXRtqxv2bL7gYFOtB1b8x7LD1Q6FUV_K3nTPUO7cTXOGtzbk7VQrNKaSYEv-nhJQPJgRD0NLST5N_-eBZL-yvA" }).GetJsonAsync();

                var json = JsonConvert.SerializeObject(payment);
                string main_URL = "demo-paco.2c2p.com";
                var responseJson= await $"https://core.{main_URL}/api/1/Payment/prePaymentUi"
                    .WithHeaders(new { Accept = "*/*", apiKey = apikey, ContentType = "application/json", Connection = "keep-alive" })
         .PostJsonAsync(payment)
         .ReceiveJson<ResultPaymentNonUI>();
                var pageRedirect = responseJson.data.paymentPage.paymentPageURL;
                //  return responseString;
                return await Task.Run(() => Redirect(pageRedirect));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error paymant credit");
                return await Task.Run(() => View());
            }

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
