using GatewayApi.Models;
using GatewayApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IDapper _dapper;
        public PaymentController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpGet("GetQRCodeImage")]//GET api/terms/programs/name
        [ActionName(nameof(GetQRCodeImage))]
        public QrCodeImage GetQRCodeImage()
        {
            decimal amount = 1.29m;
            //   var result = await Task.FromResult(_dapper.Get<PLCModel>(Id));
            var qrFormat = GetQRCode(amount);
            QrCodeImage qr = new QrCodeImage();
            qr.type = "png";
            qr.contents = RenderQrCode(qrFormat);
            return qr;
        }
        [HttpPost(nameof(CreditNotification))]
        public async Task<QRCreditResponse> CreditNotification(QRCreditNotification data)
        { 
            QRCreditResponse response = null;
            try
            {
               
                string query = "SELECT ID, BankRef, BillerNo, Ref1, Ref2, QRId, Amount, TransDate FROM QR_CODE WHERE QRId = @QRId";
                var result = await _dapper.GetAll<QRCreditNotification>(query, new { QRId = data.QRId});
                if (result != null && result.Count > 0)
                {
                    if(result[0].Amount != data.Amount)
                        response = new QRCreditResponse { BankRef = result[0].BankRef, ResCode = "001", ResDesc = "Invalid Input" };
                    else if(result[0].BillerNo != data.BillerNo)
                                response = new QRCreditResponse { BankRef = result[0].BankRef, ResCode = "003", ResDesc = "Invalid BillerNo" };
                    else
                        response = new QRCreditResponse { BankRef = result[0].BankRef, ResCode = "000", ResDesc = "Success" };
                }
                else
                {
                    response = new QRCreditResponse { BankRef = data.BankRef, ResCode = "002", ResDesc = "Invalid QrID" };
                }
            }
            catch (Exception ex)
            {
                response = new QRCreditResponse { BankRef = data.BankRef, ResCode = "999", ResDesc = "Exception error" };
              
            }
           
            return await Task.Run(() => response); 
        }
        [NonAction]
        private string GetQRCode(decimal amount)
        {
            string ref1 = "A000000677010112";// Customer Reference (depend on merchant business e.g.MobileNo.,Customer ID, InvoiceNo. etc.)A-Z,0-9 only
            string ref2 = "M001002003";// To identify merchant terminal A-Z,0-9 only
            string merchant = "ABC";// Biller Name show QR code max 25
            int QRID = 1;
            string MerchantID = "XXX";
            QRCodeFormat qrCode = new QRCodeFormat();
            qrCode.Indicator = "000201";
            // 1st character :
            // 1 = QR
            //2 = BLE
            //3 = NFC
            //4 - 9:Reserved for future use
            //  2nd character :
            //1 =static,
            //2 = dynamic
            qrCode.Method = "010212";// QR Code Dynamic
            qrCode.Identifier = "3074";
            qrCode.Identifier_AID = "0016" + "A000000677010112"; //FIX
            qrCode.Identifier_BillerID = "0115" + "010753700001716";
            qrCode.Identifier_Ref1 = "02" + ref1.Length.ToString("D2") + ref1;
            qrCode.Identifier_Ref2 = "03" + ref2.Length.ToString("D2") + ref2;
            qrCode.TransactionCurrencyCode = "5303764";
            qrCode.TransactionAmount = "54" + amount.ToString().Length + amount.ToString();
            qrCode.CountryCode = "5802TH";
            qrCode.MerchantName = "59"+ merchant.Length.ToString("D2")+merchant;
            qrCode.DataFieldTemplate = "62240720D"+ MerchantID + DateTime.Now.ToString("yyMMddHHmm")+QRID.ToString("D5");
            qrCode.CRC = "6304"  + CRC16.ComputeChecksum(Encoding.Default.GetBytes("1021"));
            string qrcode = qrCode.Method + qrCode.Identifier + qrCode.Identifier_AID + qrCode.Identifier_BillerID + qrCode.Identifier_Ref1 + qrCode.Identifier_Ref2 + qrCode.TransactionCurrencyCode
                + qrCode.TransactionAmount + qrCode.CountryCode + qrCode.MerchantName + qrCode.DataFieldTemplate + qrCode.CRC;
            return qrcode;
        }
        [NonAction]
        private string RenderQrCode(string qrcode)
        {
            // string level = comboBoxECC.SelectedItem.ToString();
            QRCodeGenerator.ECCLevel eccLevel = QRCodeGenerator.ECCLevel.L;//(QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode, eccLevel))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                //pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20, GetPrimaryColor(), GetBackgroundColor(),
                //    GetIconBitmap(), (int)iconSize.Value);

                //this.pictureBoxQRCode.Size = new System.Drawing.Size(pictureBoxQRCode.Width, pictureBoxQRCode.Height);
                ////Set the SizeMode to center the image.
                //this.pictureBoxQRCode.SizeMode = PictureBoxSizeMode.CenterImage;

                //pictureBoxQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
                var qrStrem = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White,true);
                using (var stream = new MemoryStream())
                {
                    qrStrem.Save(stream, System.Drawing.Imaging.ImageFormat.Png);// type image
                    return Convert.ToBase64String(stream.ToArray());
                }
            }
        }
    }
}
