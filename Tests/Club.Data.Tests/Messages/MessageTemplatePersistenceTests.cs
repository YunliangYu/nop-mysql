using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Messages
{
    [TestFixture]
    public class MessageTemplatePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_messageTemplate()
        {
            var mt = this.GetTestMessageTemplate();

            var fromDb = SaveAndLoadEntity(this.GetTestMessageTemplate());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(mt);
        }
    }
}