namespace TraktNet.Objects.Get.Tests.Shows.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonWriter")]
    public partial class ShowCertificationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ShowCertificationObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new ShowCertificationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowCertificationObjectJsonWriter_WriteObject_Only_Certification_Property()
        {
            ITraktShowCertification traktShowCertification = new TraktShowCertification
            {
                Certification = "TV-MA"
            };

            var traktJsonWriter = new ShowCertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowCertification);
            json.Should().Be(@"{""certification"":""TV-MA""}");
        }

        [Fact]
        public async Task Test_ShowCertificationObjectJsonWriter_WriteObject_Only_CountryCode_Property()
        {
            ITraktShowCertification traktShowCertification = new TraktShowCertification
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new ShowCertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowCertification);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_ShowCertificationObjectJsonWriter_WriteObject_Complete()
        {
            ITraktShowCertification traktShowCertification = new TraktShowCertification
            {
                Certification = "TV-MA",
                CountryCode = "us"
            };

            var traktJsonWriter = new ShowCertificationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowCertification);
            json.Should().Be(@"{""certification"":""TV-MA"",""country"":""us""}");
        }
    }
}
