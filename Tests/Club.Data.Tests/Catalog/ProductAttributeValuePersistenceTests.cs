using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Catalog
{
    [TestFixture]
    public class ProductAttributeValuePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_productAttributeValue()
        {
            var pav = this.GetTestProductAttributeValue();

            var fromDb = SaveAndLoadEntity(this.GetTestProductAttributeValue());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(pav);

            fromDb.ProductAttributeMapping.ShouldNotBeNull();
            fromDb.ProductAttributeMapping.PropertiesShouldEqual(pav.ProductAttributeMapping);
        }        
    }
}
