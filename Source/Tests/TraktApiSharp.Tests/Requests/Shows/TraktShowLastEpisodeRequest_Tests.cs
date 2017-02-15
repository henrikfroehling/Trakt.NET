namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowLastEpisodeRequest_Tests
    {
        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Is_Not_Abstract()
        {
            typeof(TraktShowLastEpisodeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Is_Sealed()
        {
            typeof(TraktShowLastEpisodeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowLastEpisodeRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktEpisode>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktShowLastEpisodeRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowLastEpisodeRequest();
            request.UriTemplate.Should().Be("shows/{id}/last_episode{?extended}");
        }

        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktShowLastEpisodeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktShowLastEpisodeRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktShowLastEpisodeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowLastEpisodeRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowLastEpisodeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowLastEpisodeRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
