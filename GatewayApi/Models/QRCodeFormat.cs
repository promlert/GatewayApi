using System;

namespace GatewayApi.Models
{
    public class QRCodeFormat
    {
       public string Indicator { set; get; }
        // 1 = QR
        //2 = BLE
        //3 = NFC
        //4-9:Reserved for future use
        //2nd character :
        //1=static,
        //2=dynamic
        //3-9:Reserved for future use
        public string Method { set; get; }
       
        /// <summary>
        ///  Identifier Max Length 99
        /// </summary>
        public string Identifier { set; get; }
        public string Identifier_AID { set; get; }
        public string Identifier_BillerID { set; get; }
        public string Identifier_Ref1 { set; get; }
        public string Identifier_Ref2 { set; get; }
        public string TransactionCurrencyCode { set; get; }
        public string TransactionAmount { set; get; }
        public string CountryCode { set; get; }
        public string MerchantName { set; get; }
        public string DataFieldTemplate { set; get; }
        public string CRC { set; get; }
    }
}
