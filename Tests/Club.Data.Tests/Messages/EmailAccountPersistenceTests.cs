using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Messages
{
    [TestFixture]
    public class EmailAccountPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_emailAccount()
        {
            var emailAccount = this.GetTestEmailAccount();

            var fromDb = SaveAndLoadEntity(this.GetTestEmailAccount());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(emailAccount);
        }
    }
}
