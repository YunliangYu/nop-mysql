using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Club.Admin.Validators.Customers;
using Club.Core.Domain.Catalog;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    [Validator(typeof(CustomerValidator))]
    public partial class CustomerModel : BaseSiteEntityModel
    {
        public CustomerModel()
        {
            this.AvailableTimeZones = new List<SelectListItem>();
            this.SendEmail = new SendEmailModel() { SendImmediately = true };
            this.SendPm = new SendPmModel();

            this.SelectedCustomerRoleIds= new List<int>();
            this.AvailableCustomerRoles = new List<SelectListItem>();

            this.AssociatedExternalAuthRecords = new List<AssociatedExternalAuthModel>();
            this.AvailableCountries = new List<SelectListItem>();
            this.AvailableStates = new List<SelectListItem>();
            this.AvailableVendors = new List<SelectListItem>();
            this.CustomerAttributes = new List<CustomerAttributeModel>();
            this.AvailableNewsletterSubscriptionStores = new List<StoreModel>();
            this.RewardPointsAvailableStores = new List<SelectListItem>();
        }
       
        public bool UsernamesEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Username")]
        [AllowHtml]
        public string Username { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Password")]
        [AllowHtml]
        [DataType(DataType.Password)]
        [NoTrim]
        public string Password { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Vendor")]
        public int VendorId { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }

        //form fields & properties
        public bool GenderEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Gender")]
        public string Gender { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.FirstName")]
        [AllowHtml]
        public string FirstName { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.LastName")]
        [AllowHtml]
        public string LastName { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.FullName")]
        public string FullName { get; set; }
        
        public bool DateOfBirthEnabled { get; set; }
        [UIHint("DateNullable")]
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        public bool CompanyEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Company")]
        [AllowHtml]
        public string Company { get; set; }

        public bool StreetAddressEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.StreetAddress")]
        [AllowHtml]
        public string StreetAddress { get; set; }

        public bool StreetAddress2Enabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.StreetAddress2")]
        [AllowHtml]
        public string StreetAddress2 { get; set; }

        public bool ZipPostalCodeEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.ZipPostalCode")]
        [AllowHtml]
        public string ZipPostalCode { get; set; }

        public bool CityEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.City")]
        [AllowHtml]
        public string City { get; set; }

        public bool CountryEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Country")]
        public int CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }

        public bool StateProvinceEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.StateProvince")]
        public int StateProvinceId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

        public bool PhoneEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Phone")]
        [AllowHtml]
        public string Phone { get; set; }

        public bool FaxEnabled { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Fax")]
        [AllowHtml]
        public string Fax { get; set; }

        public List<CustomerAttributeModel> CustomerAttributes { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.RegisteredInStore")]
        public string RegisteredInStore { get; set; }



        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.AdminComment")]
        [AllowHtml]
        public string AdminComment { get; set; }
        
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Active")]
        public bool Active { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Affiliate")]
        public int AffiliateId { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Affiliate")]
        public string AffiliateName { get; set; }




        //time zone
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.TimeZoneId")]
        [AllowHtml]
        public string TimeZoneId { get; set; }

        public bool AllowCustomersToSetTimeZone { get; set; }

        public IList<SelectListItem> AvailableTimeZones { get; set; }





        //EU VAT
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.VatNumber")]
        [AllowHtml]
        public string VatNumber { get; set; }

        public string VatNumberStatusNote { get; set; }

        public bool DisplayVatNumber { get; set; }





        //registration date
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.LastActivityDate")]
        public DateTime LastActivityDate { get; set; }

        //IP adderss
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.IPAddress")]
        public string LastIpAddress { get; set; }


        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.LastVisitedPage")]
        public string LastVisitedPage { get; set; }


        //customer roles
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.CustomerRoles")]
        public string CustomerRoleNames { get; set; }
        public List<SelectListItem> AvailableCustomerRoles { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.CustomerRoles")]
        [UIHint("MultiSelect")]
        public IList<int> SelectedCustomerRoleIds { get; set; }


        //newsletter subscriptions (per store)
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Newsletter")]
        public List<StoreModel> AvailableNewsletterSubscriptionStores { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.Fields.Newsletter")]
        public int[] SelectedNewsletterSubscriptionStoreIds { get; set; }



        //reward points history
        public bool DisplayRewardPointsHistory { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.AddRewardPointsValue")]
        public int AddRewardPointsValue { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.AddRewardPointsMessage")]
        [AllowHtml]
        public string AddRewardPointsMessage { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.AddRewardPointsStore")]
        public int AddRewardPointsStoreId { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.AddRewardPointsStore")]
        public IList<SelectListItem> RewardPointsAvailableStores { get; set; }



        //send email model
        public SendEmailModel SendEmail { get; set; }
        //send PM model
        public SendPmModel SendPm { get; set; }
        //send the welcome message
        public bool AllowSendingOfWelcomeMessage { get; set; }
        //re-send the activation message
        public bool AllowReSendingOfActivationMessage { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth")]
        public IList<AssociatedExternalAuthModel> AssociatedExternalAuthRecords { get; set; }


        #region Nested classes

        public partial class StoreModel : BaseSiteEntityModel
        {
            public string Name { get; set; }
        }

        public partial class AssociatedExternalAuthModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth.Fields.Email")]
            public string Email { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth.Fields.ExternalIdentifier")]
            public string ExternalIdentifier { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth.Fields.AuthMethodName")]
            public string AuthMethodName { get; set; }
        }

        public partial class RewardPointsHistoryModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.Store")]
            public string StoreName { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.Points")]
            public int Points { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.PointsBalance")]
            public string PointsBalance { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.Message")]
            [AllowHtml]
            public string Message { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.RewardPoints.Fields.Date")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class SendEmailModel : BaseSiteModel
        {
            [SiteResourceDisplayName("Admin.Customers.Customers.SendEmail.Subject")]
            [AllowHtml]
            public string Subject { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.SendEmail.Body")]
            [AllowHtml]
            public string Body { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.SendEmail.SendImmediately")]
            public bool SendImmediately { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.SendEmail.DontSendBeforeDate")]
            [UIHint("DateTimeNullable")]
            public DateTime? DontSendBeforeDate { get; set; }
        }

        public partial class SendPmModel : BaseSiteModel
        {
            [SiteResourceDisplayName("Admin.Customers.Customers.SendPM.Subject")]
            public string Subject { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.SendPM.Message")]
            public string Message { get; set; }
        }

        public partial class OrderModel : BaseSiteEntityModel
        {
            public override int Id { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.CustomOrderNumber")]
            public string CustomOrderNumber { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.OrderStatus")]
            public string OrderStatus { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.OrderStatus")]
            public int OrderStatusId { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.PaymentStatus")]
            public string PaymentStatus { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.ShippingStatus")]
            public string ShippingStatus { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.OrderTotal")]
            public string OrderTotal { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.Store")]
            public string StoreName { get; set; }

            [SiteResourceDisplayName("Admin.Customers.Customers.Orders.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class ActivityLogModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Customers.Customers.ActivityLog.ActivityLogType")]
            public string ActivityLogTypeName { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.ActivityLog.Comment")]
            public string Comment { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.ActivityLog.CreatedOn")]
            public DateTime CreatedOn { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.ActivityLog.IpAddress")]
            public string IpAddress { get; set; }
        }

        public partial class BackInStockSubscriptionModel : BaseSiteEntityModel
        {
            [SiteResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Store")]
            public string StoreName { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Product")]
            public int ProductId { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Product")]
            public string ProductName { get; set; }
            [SiteResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.CreatedOn")]
            public DateTime CreatedOn { get; set; }
        }

        public partial class CustomerAttributeModel : BaseSiteEntityModel
        {
            public CustomerAttributeModel()
            {
                Values = new List<CustomerAttributeValueModel>();
            }

            public string Name { get; set; }

            public bool IsRequired { get; set; }

            /// <summary>
            /// Default value for textboxes
            /// </summary>
            public string DefaultValue { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<CustomerAttributeValueModel> Values { get; set; }

        }

        public partial class CustomerAttributeValueModel : BaseSiteEntityModel
        {
            public string Name { get; set; }

            public bool IsPreSelected { get; set; }
        }

        #endregion
    }
}