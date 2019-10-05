namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Modules;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_URI = $"shows/{SHOW_ID}";

        [Fact]
        public async Task Test_TraktShowsModule_GetShow()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_URI, SHOW_JSON);
            TraktResponse<ITraktShow> response = await client.Shows.GetShowAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShow responseValue = response.Value;

            responseValue.Title.Should().Be("Game of Thrones");
            responseValue.Year.Should().Be(2011);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(1390U);
            responseValue.Ids.Slug.Should().Be("game-of-thrones");
            responseValue.Ids.Tvdb.Should().Be(121361U);
            responseValue.Ids.Imdb.Should().Be("tt0944947");
            responseValue.Ids.Tmdb.Should().Be(1399U);
            responseValue.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShow_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SHOW_URI}?extended={EXTENDED_INFO}", SHOW_JSON);
            TraktResponse<ITraktShow> response = await client.Shows.GetShowAsync(SHOW_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShow responseValue = response.Value;

            responseValue.Title.Should().Be("Game of Thrones");
            responseValue.Year.Should().Be(2011);
            responseValue.Airs.Should().NotBeNull();
            responseValue.Airs.Day.Should().Be("Sunday");
            responseValue.Airs.Time.Should().Be("21:00");
            responseValue.Airs.TimeZoneId.Should().Be("America/New_York");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(1390U);
            responseValue.Ids.Slug.Should().Be("game-of-thrones");
            responseValue.Ids.Tvdb.Should().Be(121361U);
            responseValue.Ids.Imdb.Should().Be("tt0944947");
            responseValue.Ids.Tmdb.Should().Be(1399U);
            responseValue.Ids.TvRage.Should().Be(24493U);
            responseValue.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            responseValue.Seasons.Should().BeNull();
            responseValue.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            responseValue.Runtime.Should().Be(60);
            responseValue.Certification.Should().Be("TV-MA");
            responseValue.Network.Should().Be("HBO");
            responseValue.CountryCode.Should().Be("us");
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            responseValue.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            responseValue.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            responseValue.Status.Should().Be(TraktShowStatus.ReturningSeries);
            responseValue.Rating.Should().Be(9.38327f);
            responseValue.Votes.Should().Be(44773);
            responseValue.LanguageCode.Should().Be("en");
            responseValue.AiredEpisodes.Should().Be(50);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktShowsModule_GetShow_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_URI, statusCode);

            try
            {
                await client.Shows.GetShowAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktShowsModule_GetShow_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_URI, SHOW_JSON);

            Func<Task<TraktResponse<ITraktShow>>> act = () => client.Shows.GetShowAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetMultipleShows_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_URI, SHOW_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktShow>>>> act = () => client.Shows.GetMultipleShowsAsync(null);
            act.Should().NotThrow();

            act = () => client.Shows.GetMultipleShowsAsync(new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = () => client.Shows.GetMultipleShowsAsync(new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetMultipleShowsAsync(new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetMultipleShowsAsync(new TraktMultipleObjectsQueryParams { { "show id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
