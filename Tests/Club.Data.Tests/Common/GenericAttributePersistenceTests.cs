using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Common
{
    [TestFixture]
    public class GenericAttributePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_genericAttribute()
        {
            var genericAttribute = this.GetTestGenericAttribute();

            var fromDb = SaveAndLoadEntity(this.GetTestGenericAttribute());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(genericAttribute);
        }
    }
}