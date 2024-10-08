// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> A Payment on Account. </summary>
    public partial class BillingPaymentOnAccount
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="BillingPaymentOnAccount"/>. </summary>
        internal BillingPaymentOnAccount()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BillingPaymentOnAccount"/>. </summary>
        /// <param name="amount"> Payment on Account amount. </param>
        /// <param name="billingProfileId"> The ID of the billing profile for the payments on account. </param>
        /// <param name="billingProfileDisplayName"> The name of the billing profile for the payments on account. </param>
        /// <param name="invoiceId"> The ID of the invoice for which the payments on account was generated. </param>
        /// <param name="invoiceName"> The name of the invoice for the payments on account. </param>
        /// <param name="on"> The date of the payments on account. </param>
        /// <param name="paymentMethodType"> Payment on Account type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BillingPaymentOnAccount(CreatedSubscriptionReseller amount, ResourceIdentifier billingProfileId, string billingProfileDisplayName, ResourceIdentifier invoiceId, string invoiceName, DateTimeOffset? @on, PaymentMethodFamily? paymentMethodType, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Amount = amount;
            BillingProfileId = billingProfileId;
            BillingProfileDisplayName = billingProfileDisplayName;
            InvoiceId = invoiceId;
            InvoiceName = invoiceName;
            On = @on;
            PaymentMethodType = paymentMethodType;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Payment on Account amount. </summary>
        [WirePath("amount")]
        public CreatedSubscriptionReseller Amount { get; }
        /// <summary> The ID of the billing profile for the payments on account. </summary>
        [WirePath("billingProfileId")]
        public ResourceIdentifier BillingProfileId { get; }
        /// <summary> The name of the billing profile for the payments on account. </summary>
        [WirePath("billingProfileDisplayName")]
        public string BillingProfileDisplayName { get; }
        /// <summary> The ID of the invoice for which the payments on account was generated. </summary>
        [WirePath("invoiceId")]
        public ResourceIdentifier InvoiceId { get; }
        /// <summary> The name of the invoice for the payments on account. </summary>
        [WirePath("invoiceName")]
        public string InvoiceName { get; }
        /// <summary> The date of the payments on account. </summary>
        [WirePath("date")]
        public DateTimeOffset? On { get; }
        /// <summary> Payment on Account type. </summary>
        [WirePath("paymentMethodType")]
        public PaymentMethodFamily? PaymentMethodType { get; }
    }
}
