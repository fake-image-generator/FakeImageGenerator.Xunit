using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace FakeImageGenerator.Xunit
{
    /// <summary>
    ///     Attribute to generate a fake .png/.jpg image between 1 KB and 2 GB.
    /// </summary>
    public class FakeImageGeneratorDataAttribute : DataAttribute
    {
        private readonly int sizeInBytes;
        private readonly string extension;
        private readonly string outputPath;

        /// <summary>
        ///     Generate fake image for a theory.
        /// </summary>
        /// <param name="sizeInBytes">The size of the image in bytes.</param>
        /// <param name="extension">The image extension. Extensions available are png and jpg.</param>
        /// <param name="oututPath">The image output path.</param>
        public FakeImageGeneratorDataAttribute(int sizeInBytes, string extension, string outputPath)
        {
            this.sizeInBytes = sizeInBytes;
            this.extension = extension;
            this.outputPath = outputPath;
        }

        /// <summary>
        ///     Generate fake image for a theory.
        /// </summary>
        /// <param name="sizeInBytes">The size of the image in bytes.</param>
        /// <param name="extension">The image extension. Extensions available are png and jpg.</param>
        public FakeImageGeneratorDataAttribute(int sizeInBytes, string extension)
        {
            this.sizeInBytes = sizeInBytes;
            this.extension = extension;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            var generator = new Generator();

            if (string.IsNullOrEmpty(outputPath))
            {
                yield return new object[] { generator.Run(sizeInBytes, extension) };
            } 
            else
            {
                generator.Run(sizeInBytes, extension, outputPath);

                yield return new object[] { Path.Combine(outputPath, $"image.{extension.ToLower()}") };
            }
        }
    }
}
