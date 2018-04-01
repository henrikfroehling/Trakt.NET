namespace TraktApiSharp.Tests.Modules.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodesArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;

            Func<Task<IEnumerable<TraktResponse<ITraktEpisode>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(null);
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams());
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { null, seasonNr, episodeNr } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { string.Empty, seasonNr, episodeNr } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { "show id", seasonNr, episodeNr } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { showId, seasonNr, 0 } });
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
