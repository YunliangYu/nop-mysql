using Club.Tests;
using NUnit.Framework;

namespace Club.Data.Tests.Orders
{
    [TestFixture]
    public class RewardPointHistoryTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_rewardPointHistory()
        {
            var rph = this.GetTestRewardPointsHistory();

            var fromDb = SaveAndLoadEntity(this.GetTestRewardPointsHistory());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(rph);
        }
    }
}
