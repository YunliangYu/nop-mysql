﻿using System.Web.Routing;
using Club.Web.Infrastructure;
using NUnit.Framework;

namespace Club.Web.MVC.Tests.Public.Infrastructure
{
    [TestFixture]
    public abstract class RoutesTestsBase
    {
        [SetUp]
        public void Setup()
        {
            //var typeFinder = new WebAppTypeFinder();
            //var routePublisher = new RoutePublisher(typeFinder);
            //routePublisher.RegisterRoutes(RouteTable.Routes);

            new RouteProvider().RegisterRoutes(RouteTable.Routes);
        }

        [TearDown]
        public void TearDown()
        {
            RouteTable.Routes.Clear();
        }
    }
}