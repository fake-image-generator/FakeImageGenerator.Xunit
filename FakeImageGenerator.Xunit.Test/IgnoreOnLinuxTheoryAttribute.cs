using System.Runtime.InteropServices;
using Xunit;

namespace FakeImageGenerator.Xunit.Test
{
    public class IgnoreOnLinuxTheoryAttribute : TheoryAttribute
    {
        public IgnoreOnLinuxTheoryAttribute()
        {
            if (IsRunningOnLinux())
            {
                Skip = "Ignored on Linux";
            }
        }

        /// <summary>
        /// Determine if runtime is Linux.
        /// </summary>
        /// <returns>True if being executed in Linux, false otherwise.</returns>
        public static bool IsRunningOnLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }
    }
}
