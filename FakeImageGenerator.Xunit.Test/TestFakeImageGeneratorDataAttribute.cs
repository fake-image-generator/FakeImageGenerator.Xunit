using System;
using System.IO;
using Xunit;

namespace FakeImageGenerator.Xunit.Test
{
    public class TestFakeImageGeneratorDataAttribute
    {
        [IgnoreOnLinuxTheory]
        [FakeImageGeneratorData(10000000, "Png", "C:/")]
        public void GenerateFakeImageWithOutputPathShouldBeOk(string path)
        {
            var file = new FileInfo(path);

            Assert.Equal(10000000, file.Length);
            Assert.Equal(".png", file.Extension);
        }

        [IgnoreOnWindowsTheory]
        [FakeImageGeneratorData(10000000, "Png", "/home")]
        public void GenerateFakeImageWithOutputPathInLinuxShouldBeOk(string path)
        {
            var file = new FileInfo(path);

            Assert.Equal(10000000, file.Length);
            Assert.Equal(".png", file.Extension);
        }

        [Theory]
        [FakeImageGeneratorData(10000000, "Png")]
        public void GenerateFakeImageWithoutOutputPathShouldBeOk(byte[] array)
        {
            Assert.Equal(10000000, array.Length);
        }
    }
}
