using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Directory
{
    [TestFixture]
    public class MeasureDimensionPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_measureDimension()
        {
            var measureDimension = this.GetTestMeasureDimension();

            var fromDb = SaveAndLoadEntity(this.GetTestMeasureDimension());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(measureDimension);
        }
    }
}
