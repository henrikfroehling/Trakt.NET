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
    using TraktNet.Objects.Get.People;
    using TraktNet.Responses;
    using TraktNet.Extensions;
    using Xunit;

    [TestCategory("Modules.People")]
    public partial class TraktPeopleModule_Tests
    {
        private readonly string GET_PERSONS_STREAM_URI = $"people/{PERSON_ID}";

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonStreamAsync()
        {
            TraktMultipleObjectsQueryParams parameters = new TraktMultipleObjectsQueryParams
            {
                { PERSON_ID },
                { PERSON_ID }
            };
            int totalPersons = parameters.Count;
            TraktClient client = TestUtility.GetMockClientForMultipleCalls(GET_PERSONS_STREAM_URI, PERSON_MINIMAL_JSON, totalPersons);
            IAsyncEnumerable<TraktResponse<ITraktPerson>> responses = client.People.GetPersonsStreamAsync(parameters);

            int returnedPersons = 0;
            await foreach (TraktResponse<ITraktPerson> response in responses.ConfigureAwait(false))
            {
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
                returnedPersons++;
            }

            returnedPersons.Should().Be(totalPersons);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonStreamAsync_With_ExtendedInfo()
        {
            TraktMultipleObjectsQueryParams parameters = new TraktMultipleObjectsQueryParams
            {
                { PERSON_ID, EXTENDED_INFO },
                { PERSON_ID, EXTENDED_INFO }
            };
            int totalPersons = parameters.Count;
            TraktClient client = TestUtility.GetMockClientForMultipleCalls($"{GET_PERSONS_STREAM_URI}?extended={EXTENDED_INFO}", PERSON_FULL_JSON, totalPersons);
            IAsyncEnumerable<TraktResponse<ITraktPerson>> responses = client.People.GetPersonsStreamAsync(parameters);

            int returnedPersons = 0;
            await foreach (TraktResponse<ITraktPerson> response in responses.ConfigureAwait(false))
            {
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
                returnedPersons++;
            }
            returnedPersons.Should().Be(totalPersons);
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonStreamAsync_WithNullParameters()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSONS_STREAM_URI}?extended={EXTENDED_INFO}", PERSON_FULL_JSON);
            IAsyncEnumerable<TraktResponse<ITraktPerson>> responses = client.People.GetPersonsStreamAsync(null);

            (await responses.ToListAsync().ConfigureAwait(false)).Should().BeEmpty();
        }

        [Fact]
        public async Task Test_TraktPeopleModule_GetPersonStreamAsync_With_EmptyParameters()
        {
            TraktMultipleObjectsQueryParams parameters = new TraktMultipleObjectsQueryParams();
            int totalPersons = parameters.Count;
            TraktClient client = TestUtility.GetMockClient($"{GET_PERSONS_STREAM_URI}?extended={EXTENDED_INFO}", PERSON_FULL_JSON);
            IAsyncEnumerable<TraktResponse<ITraktPerson>> responses = client.People.GetPersonsStreamAsync(parameters);

            (await responses.ToListAsync().ConfigureAwait(false)).Should().BeEmpty();
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
        public async Task Test_TraktPeopleModule_GetPersonStreamAsync_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktMultipleObjectsQueryParams parameters = new TraktMultipleObjectsQueryParams
            {
                { PERSON_ID, EXTENDED_INFO },
                { PERSON_ID, EXTENDED_INFO }
            };
            TraktClient client = TestUtility.GetMockClient(GET_PERSONS_STREAM_URI, statusCode);

            try
            {
                IAsyncEnumerable<TraktResponse<ITraktPerson>> responses = client.People.GetPersonsStreamAsync(parameters);
                (await responses.ToListAsync().ConfigureAwait(false)).Should().NotBeNull();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}