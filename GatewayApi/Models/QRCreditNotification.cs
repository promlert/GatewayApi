using Dapper.Contrib.Extensions;

namespace GatewayApi.Models
{
    [Table("QR_CODE")]
    public class QRCreditNotification
    {
        [Key]
        public long ID { set; get; }
        public string BankRef { get; set; }
        public string BillerNo { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string QRId { get; set; }
        public string Amount { get; set; }
        public string ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public string TransDate { get; set; }
    }
}
