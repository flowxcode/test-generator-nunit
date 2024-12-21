using NUnit.Framework;

namespace FilterTest
{
    public abstract class BaseTestFixture
    {
        [TearDown]
        public void BaseTearDown()
        {
            var testName = TestContext.CurrentContext.Test.FullName;

            // Log it to verify what name is recorded
            TestContext.WriteLine("TearDown: " + TestContext.CurrentContext.Test.FullName);
            ExecutedTestsTracker.MarkAsExecuted(testName);
        }
    }
}
