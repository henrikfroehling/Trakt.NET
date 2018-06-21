namespace TraktNet.Tests.Modules.TraktPeopleModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Modules;
    using TraktNet.Objects.Get.People;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.People")]
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

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktPersonNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(PERSON_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetPerson_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, PERSON_MINIMAL_JSON);

            Func<Task<TraktResponse<ITraktPerson>>> act = () => client.People.GetPersonAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetPersonAsync("person id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPeopleModule_GetMultiplePersons_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_PERSON_URI, PERSON_MINIMAL_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktPerson>>>> act = () => client.People.GetMultiplePersonsAsync(null);
            act.Should().NotThrow();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = () => client.People.GetMultiplePersonsAsync(new TraktMultipleObjectsQueryParams { { "person id" } });
            act.Should().Throw<ArgumentException>();
        }
    }
}
