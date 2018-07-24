using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Catalog
{
    [TestFixture]
    public class ManufacturerPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_manufacturer()
        {
            var manufacturer = this.GetTestManufacturer();

            var fromDb = SaveAndLoadEntity(this.GetTestManufacturer());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(manufacturer);
        }        
    }
}
