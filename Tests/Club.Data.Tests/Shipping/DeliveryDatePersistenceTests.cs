using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Shipping
{
    [TestFixture]
    public class DeliveryDatePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_deliveryDate()
        {
            var deliveryDate = this.GetTestDeliveryDate();

            var fromDb = SaveAndLoadEntity(this.GetTestDeliveryDate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(deliveryDate);
        }
    }
}