namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktMetadata_Tests
    {
        [Fact]
        public void Test_ITraktMetadata_Is_Interface()
        {
            typeof(ITraktMetadata).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMetadata_Has_MediaType_Property()
        {
            var propertyInfo = typeof(ITraktMetadata).GetProperties().FirstOrDefault(p => p.Name == "MediaType");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktMediaType));
        }

        [Fact]
        public void Test_ITraktMetadata_Has_MediaResolution_Property()
        {
            var propertyInfo = typeof(ITraktMetadata).GetProperties().FirstOrDefault(p => p.Name == "MediaResolution");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktMediaResolution));
        }

        [Fact]
        public void Test_ITraktMetadata_Has_Audio_Property()
        {
            var propertyInfo = typeof(ITraktMetadata).GetProperties().FirstOrDefault(p => p.Name == "Audio");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktMediaAudio));
        }

        [Fact]
        public void Test_ITraktMetadata_Has_AudioChannels_Property()
        {
            var propertyInfo = typeof(ITraktMetadata).GetProperties().FirstOrDefault(p => p.Name == "AudioChannels");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktMediaAudioChannel));
        }

        [Fact]
        public void Test_ITraktMetadata_Has_ThreeDimensional_Property()
        {
            var propertyInfo = typeof(ITraktMetadata).GetProperties().FirstOrDefault(p => p.Name == "ThreeDimensional");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }
    }
}
