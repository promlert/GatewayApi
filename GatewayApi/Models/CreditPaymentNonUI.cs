using System.Collections.Generic;

namespace GatewayApi.Models
{
    public class CreditPaymentNonUI
    {
        public ApiRequest apiRequest { get; set; }
        public string officeId { get; set; }
        public string orderNo { get; set; }
        public string productDescription { get; set; }
        public string paymentCategory { get; set; }
        public string paymentType { get; set; }
        public List<string> preferredPaymentTypes { get; set; }
        public string channelCode { get; set; }
        public string agentCode { get; set; }
        public string mcpFlag { get; set; }
        public string request3dsFlag { get; set; }
        public TransactionAmount transactionAmount { get; set; }
        public NotificationURLs notificationURLs { get; set; }
        public int autoRedirectDelayTimer { get; set; }
        public GeneralPayerDetails generalPayerDetails { get; set; }
        public BillingAddress billingAddress { get; set; }
        public DeviceDetails deviceDetails { get; set; }
        public List<PurchaseItem> purchaseItems { get; set; }
        public List<CustomFieldList> customFieldList { get; set; }
    }

    public class ApiRequest
    {
        public string requestMessageID { get; set; }
        public string requestDateTime { get; set; }
        public string language { get; set; }
    }

    public class TransactionAmount
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
        public double amount { get; set; }
    }

    public class NotificationURLs
    {
        public string confirmationURL { get; set; }
        public string failedURL { get; set; }
        public string cancellationURL { get; set; }
        public string backendURL { get; set; }
    }

    public class PersonName
    {
        public string fullName { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
    }

    public class GeneralPayerDetails
    {
        public string personType { get; set; }
        public int seqNo { get; set; }
        public PersonName personName { get; set; }
        public string email { get; set; }
        public string mobilePhone { get; set; }
        public string businessPhone { get; set; }
    }

    public class BillingAddress
    {
        public string billAddrCity { get; set; }
        public string billAddrCountry { get; set; }
        public string billAddrLine1 { get; set; }
        public string billAddrLine2 { get; set; }
        public string billAddrLine3 { get; set; }
        public string billAddrPostCode { get; set; }
        public string billAddrState { get; set; }
        public string addrMatch { get; set; }
    }

    public class DeviceDetails
    {
        public string browser { get; set; }
        public string browserAcceptHeader { get; set; }
        public string browserIP { get; set; }
        public string browserJavaEnabled { get; set; }
        public string browserLanguage { get; set; }
        public string browserColorDepth { get; set; }
        public string browserScreenHeight { get; set; }
        public string browserScreenWidth { get; set; }
        public string browserTZ { get; set; }
        public string browserUserAgent { get; set; }
        public string mobileDeviceFlag { get; set; }
    }

    public class PurchaseItemPrice
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
        public double amount { get; set; }
    }

    public class PurchaseItem
    {
        public string purchaseItemType { get; set; }
        public string referenceNo { get; set; }
        public string purchaseItemDescription { get; set; }
        public PurchaseItemPrice purchaseItemPrice { get; set; }
        public string subMerchantID { get; set; }
        public int passengerSeqNo { get; set; }
    }

    public class CustomFieldList
    {
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
    }
}
