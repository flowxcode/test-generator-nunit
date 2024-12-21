using NUnit.Framework;

namespace FilterTest
{
    [TestFixture]
    public class YourTestFixture : BaseTestFixture
    {
        [FilterExecutedTest]
        public void Plainasdfn()
        {
            // This should only run the first time
            TestContext.WriteLine("Running Plaiasdf test");
            Assert.Pass();
        }

        [FilterExecutedTest]
        public void Plaiasdf_alt()
        {
            // This should only run the first time
            TestContext.WriteLine("Running Plainasdf_alt test");
            Assert.Pass();
        }

        [FilterExecutedTest]
        public void Hanstests()
        {
            // This should only run the first time
            TestContext.WriteLine("Running Hanstests test");
            Assert.Fail("aaaaaaaaaabbbbbbbbbbbbccccccccccccccccccccc");
        }
    }
}
