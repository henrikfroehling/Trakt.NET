namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowNextEpisodeRequest_Tests
    {
        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Is_Not_Abstract()
        {
            typeof(TraktShowNextEpisodeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Is_Sealed()
        {
            typeof(TraktShowNextEpisodeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowNextEpisodeRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktEpisode>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktShowNextEpisodeRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowNextEpisodeRequest();
            request.UriTemplate.Should().Be("shows/{id}/next_episode{?extended}");
        }

        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktShowNextEpisodeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktShowNextEpisodeRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktShowNextEpisodeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowNextEpisodeRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowNextEpisodeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowNextEpisodeRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}
