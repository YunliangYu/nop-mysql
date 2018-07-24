using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Club.Web.Framework;
using Club.Web.Framework.Mvc;

namespace Club.Admin.Models.Customers
{
    public partial class CustomerListModel : BaseSiteModel
    {
        public CustomerListModel()
        {
            SearchCustomerRoleIds = new List<int>();
            AvailableCustomerRoles = new List<SelectListItem>();
        }

        [UIHint("MultiSelect")]
        [SiteResourceDisplayName("Admin.Customers.Customers.List.CustomerRoles")]
        public IList<int> SearchCustomerRoleIds { get; set; }
        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchEmail")]
        [AllowHtml]
        public string SearchEmail { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchUsername")]
        [AllowHtml]
        public string SearchUsername { get; set; }
        public bool UsernamesEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchFirstName")]
        [AllowHtml]
        public string SearchFirstName { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchLastName")]
        [AllowHtml]
        public string SearchLastName { get; set; }


        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchDateOfBirth")]
        [AllowHtml]
        public string SearchDayOfBirth { get; set; }
        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchDateOfBirth")]
        [AllowHtml]
        public string SearchMonthOfBirth { get; set; }
        public bool DateOfBirthEnabled { get; set; }



        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchCompany")]
        [AllowHtml]
        public string SearchCompany { get; set; }
        public bool CompanyEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchPhone")]
        [AllowHtml]
        public string SearchPhone { get; set; }
        public bool PhoneEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchZipCode")]
        [AllowHtml]
        public string SearchZipPostalCode { get; set; }
        public bool ZipPostalCodeEnabled { get; set; }

        [SiteResourceDisplayName("Admin.Customers.Customers.List.SearchIpAddress")]
        public string SearchIpAddress { get; set; }
    }
}