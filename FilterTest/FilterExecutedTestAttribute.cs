using FilterTest;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;
using System.Collections.Generic;

public class FilterExecutedTestAttribute : Attribute, ITestBuilder
{
    public IEnumerable<TestMethod> BuildFrom(IMethodInfo method, Test suite)
    {
        string testName = $"{method.TypeInfo.FullName}.{method.Name}";

        // Optional: Log for debugging
        TestContext.WriteLine("FilterExecutedTestAttribute checking: " + testName);
        TestContext.WriteLine("IsExecuted? " + ExecutedTestsTracker.IsExecuted(testName));

        if (!ExecutedTestsTracker.IsExecuted(testName))
        {
            var testCase = new NUnitTestCaseBuilder().BuildTestMethod(method, suite, null);
            testCase.Name = method.Name; // naming the displayed test name, does not affect FullName
            yield return testCase;
        }
        else
        {
            /*var testCase = new NUnitTestCaseBuilder().BuildTestMethod(method, suite, null);
            testCase.RunState = RunState.NotRunnable;
            yield break;*/

            /*var testCase = new NUnitTestCaseBuilder().BuildTestMethod(method, suite, null);
            testCase.RunState = RunState.Ignored; // or RunState.Skipped
            testCase.Properties.Set(PropertyNames.SkipReason, "Already executed");
            yield return testCase;*/

            yield break;
        }
    }
}
