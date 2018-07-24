using System.Data.Entity;
using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests
{
    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public void Can_generate_schema()
        {
            Database.SetInitializer<SiteObjectContext>(null);
            var ctx = new SiteObjectContext("Test");
            string result = ctx.CreateDatabaseScript();
            result.ShouldNotBeNull();
        }
    }
}
