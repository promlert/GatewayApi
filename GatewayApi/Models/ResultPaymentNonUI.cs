using System;
using System.Collections.Generic;

namespace GatewayApi.Models
{
    public class ResultPaymentNonUI
    {
        public Data data { get; set; }
        public string version { get; set; }
        public ApiResponse apiResponse { get; set; }
    }

    public class PaymentStatusInfo
    {
        public string paymentStatus { get; set; }
        public string paymentStep { get; set; }
        public DateTime lastUpdatedDateTime { get; set; }
    }

    public class SettlementAmount
    {
        public object amountText { get; set; }
        public object currencyCode { get; set; }
        public int decimalPlaces { get; set; }
        public double amount { get; set; }
    }

    public class PaymentIncompleteResult
    {
        public NotificationURLs notificationURLs { get; set; }
        public object aresACSChallenge { get; set; }
        public object failedReason { get; set; }
        public List<string> availablePaymentTypes { get; set; }
        public object untokenizedStoredCardList { get; set; }
        public object storedCardUniqueID { get; set; }
        public object paymentExpiryDateTime { get; set; }
        public object merchantIdForMcp { get; set; }
        public object mcpDetails { get; set; }
        public DateTime transactionDateTime { get; set; }
        public string orderNo { get; set; }
        public string productDescription { get; set; }
        public object invoiceNo2C2P { get; set; }
        public object pspReferenceNo { get; set; }
        public string controllerInternalID { get; set; }
        public PaymentStatusInfo paymentStatusInfo { get; set; }
        public string paymentType { get; set; }
        public string channelCode { get; set; }
        public string agentCode { get; set; }
        public string mcpFlag { get; set; }
        public TransactionAmount transactionAmount { get; set; }
        public SettlementAmount settlementAmount { get; set; }
        public object customFieldList { get; set; }
        public object clientIp { get; set; }
        public string officeId { get; set; }
    }

    public class PaymentPage
    {
        public string paymentPageURL { get; set; }
        public DateTime validTillDateTime { get; set; }
    }

    public class Data
    {
        public PaymentIncompleteResult paymentIncompleteResult { get; set; }
        public PaymentPage paymentPage { get; set; }
    }

    public class ApiResponse
    {
        public string responseMessageId { get; set; }
        public string responseToRequestMessageId { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public DateTime responseDateTime { get; set; }
        public int responseTime { get; set; }
    }
}
