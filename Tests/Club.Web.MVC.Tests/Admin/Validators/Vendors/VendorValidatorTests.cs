﻿using FluentValidation.TestHelper;
using Club.Admin.Models.Vendors;
using Club.Admin.Validators.Vendors;
using Club.Web.MVC.Tests.Public.Validators;
using NUnit.Framework;

namespace Club.Web.MVC.Tests.Admin.Validators.Vendors
{
    [TestFixture]
    public class VendorValidatorTests : BaseValidatorTests
    {
        private VendorValidator _validator;

        [SetUp]
        public new void Setup()
        {
            _validator = new VendorValidator(_localizationService, null);
        }

        [Test]
        public void Should_have_error_when_pageSizeOptions_has_duplicate_items()
        {
            var model = new VendorModel();
            model.PageSizeOptions = "1, 2, 3, 5, 2";
            _validator.ShouldHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }

        [Test]
        public void Should_not_have_error_when_pageSizeOptions_has_not_duplicate_items()
        {
            var model = new VendorModel();
            model.PageSizeOptions = "1, 2, 3, 5, 9";
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }

        [Test]
        public void Should_not_have_error_when_pageSizeOptions_is_null_or_empty()
        {
            var model = new VendorModel();
            model.PageSizeOptions = null;
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
            model.PageSizeOptions = "";
            _validator.ShouldNotHaveValidationErrorFor(x => x.PageSizeOptions, model);
        }
    }
}