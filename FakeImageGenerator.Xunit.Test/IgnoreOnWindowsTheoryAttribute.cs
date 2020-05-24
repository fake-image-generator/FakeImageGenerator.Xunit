using System.Runtime.InteropServices;
using Xunit;

namespace FakeImageGenerator.Xunit.Test
{
    public class IgnoreOnWindowsTheoryAttribute : TheoryAttribute
    {
        public IgnoreOnWindowsTheoryAttribute()
        {
            if (IsRunningOnWindows())
            {
                Skip = "Ignored on Windows";
            }
        }

        /// <summary>
        /// Determine if runtime is Windows.
        /// </summary>
        /// <returns>True if being executed in Windows, false otherwise.</returns>
        public static bool IsRunningOnWindows()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }
    }
}
