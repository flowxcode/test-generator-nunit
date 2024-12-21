using System;
using System.Collections.Generic;
using System.IO;

namespace FilterTest
{
    public static class ExecutedTestsTracker
    {
        private static readonly string ExecutedTestsFilePath = Path.Combine("C:\\git\\snahResults", "ExecutedTests_minimal.txt");
        private static readonly HashSet<string> ExecutedTests = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly object FileLock = new object();
        private static bool initialized = false;

        private static void Initialize()
        {
            if (!initialized)
            {
                lock (FileLock)
                {
                    if (!initialized)
                    {
                        if (File.Exists(ExecutedTestsFilePath))
                        {
                            foreach (var line in File.ReadAllLines(ExecutedTestsFilePath))
                            {
                                var trimmed = line.Trim();
                                if (!string.IsNullOrEmpty(trimmed))
                                    ExecutedTests.Add(trimmed);
                            }
                        }
                        initialized = true;
                    }
                }
            }
        }

        public static bool IsExecuted(string testName)
        {
            Initialize();
            return ExecutedTests.Contains(testName);
        }

        public static void MarkAsExecuted(string testName)
        {
            Initialize();
            if (ExecutedTests.Add(testName))
            {
                lock (FileLock)
                {
                    File.AppendAllText(ExecutedTestsFilePath, testName + Environment.NewLine);
                }
            }
        }
    }
}
