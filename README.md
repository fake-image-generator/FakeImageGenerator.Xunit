# FakeImageGenerator.Xunit
[![NuGet](https://img.shields.io/nuget/v/FakeImageGenerator.Xunit)](https://www.nuget.org/packages/FakeImageGenerator.Xunit/) [![Github Actions](https://img.shields.io/github/workflow/status/fake-image-generator/FakeImageGenerator.Xunit/.NET%20Core)](https://github.com/fake-image-generator/FakeImageGenerator.Xunit/actions?query=workflow%3A".NET+Core")



<img align="left" width="100" height="100" src="fake-image-generator.png">

For more details about this project please check the main repository in [FakeImageGenerator](https://github.com/fake-image-generator/FakeImageGenerator).

### Requirements

.NET Core 3.1

### Installation

```
Install-Package FakeImageGenerator.Xunit
```

### Usage

Add the `FakeImageGeneratorDataAttribute` in all `Xunit` theories in which you need fake images like this:

```csharp
[Theory]
[FakeImageGeneratorDataAttribute(10000000, "Png", "C:/")]
public void GenerateFakeImageWithOutputPathShouldBeOk(string path)
{
    var file = new FileInfo(path);

    Assert.Equal(10000000, file.Length);
    Assert.Equal(".png", file.Extension);
}

[Theory]
[FakeImageGeneratorDataAttribute(10000000, "Png")]
public void GenerateFakeImageWithoutOutputPathShouldBeOk(byte[] array)
{
    Assert.Equal(10000000, array.Length);
}
```

