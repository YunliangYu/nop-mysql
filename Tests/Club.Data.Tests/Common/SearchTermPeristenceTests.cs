using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Common
{
    [TestFixture]
    public class SearchTermPeristenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_searchTerm()
        {
            var searchTerm = this.GetTestSearchTerm();

            var fromDb = SaveAndLoadEntity(this.GetTestSearchTerm());
            fromDb.ShouldNotBeNull();

            fromDb.PropertiesShouldEqual(searchTerm);
        }
    }
}
