using System;
using System.Collections.Generic;
using AutoMapper;
using Club.Admin.Infrastructure.Mapper;
using Club.Core.Infrastructure.Mapper;
using NUnit.Framework;

namespace Club.Web.MVC.Tests.Admin.Infrastructure
{
    [TestFixture]
    public class AutoMapperConfigurationTest
    {
        [Test]
        public void Configuration_is_valid()
        {
            var configurationActions = new List<Action<IMapperConfigurationExpression>>();
            var adminMapper = new AdminMapperConfiguration();
            configurationActions.Add(adminMapper.GetConfiguration());
            AutoMapperConfiguration.Init(configurationActions);
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
        }
    }
}
