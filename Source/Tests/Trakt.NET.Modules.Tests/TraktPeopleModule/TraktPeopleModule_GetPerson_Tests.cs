namespace TraktNet.Modules.Tests.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Modules;
    using TraktNet.Objects.Get.People;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        private readonly string GET_PERSON_URI = $"people/{PERSON_ID}";

        [Fact]
        public async Task Test_TraktPeopleModule_GetPerson()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, PERSON_MINIMAL_JSON);
            TraktResponse<ITraktPerson> response = await client.People.GetPersonAsync(PERSON_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktPerson responseValue = response.Value;

            responseValue.Name.Should().Be("Bryan Cranston");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(297737U);
            responseValue.Ids.Slug.Should().Be("bryan-cranston");
            responseValue.Ids.Imdb.Should().Be("nm0186505");
            responseValue.Ids.Tmdb.Should().Be(17419U);
            responseValue.Ids.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPerson_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSON_URI}?extended={EXTENDED_INFO}", PERSON_FULL_JSON);
            TraktResponse<ITraktPerson> response = await client.People.GetPersonAsync(PERSON_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktPerson responseValue = response.Value;

            responseValue.Name.Should().Be("Bryan Cranston");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(297737U);
            responseValue.Ids.Slug.Should().Be("bryan-cranston");
            responseValue.Ids.Imdb.Should().Be("nm0186505");
            responseValue.Ids.Tmdb.Should().Be(17419U);
            responseValue.Ids.TvRage.Should().Be(1797U);
            responseValue.Biography.Should().Be("Bryan Lee Cranston (born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy \"Malcolm in the Middle\", and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            responseValue.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            responseValue.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            responseValue.Age.Should().Be(60);
            responseValue.Birthplace.Should().Be("San Fernando Valley, California, USA");
            responseValue.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktPersonNotFoundException))]
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
        public async Task Test_TraktPeopleModule_GetPerson_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, statusCode);

            try
            {
                await client.People.GetPersonAsync(PERSON_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPerson_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, PERSON_MINIMAL_JSON);

            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.People.GetPersonAsync("person id");
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetMultiplePersons_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, PERSON_MINIMAL_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktPerson>>>> act = () => client.People.GetMultiplePersonsAsync(null);
            await act.Should().NotThrowAsync();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams());
            await act.Should().NotThrowAsync();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams { { null } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams { { string.Empty } });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams { { "person id" } });
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
