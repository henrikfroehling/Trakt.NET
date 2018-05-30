namespace TraktApiSharp.Tests.Core
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Authentication;
    using Xunit;

    [Category("Core")]
    public class TraktClient_Tests
    {
        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";

        [Fact]
        public void Test_TraktClient_Default_Constructor()
        {
            var client = new TraktClient();

            client.ClientId.Should().BeNull();
            client.ClientSecret.Should().BeNull();
            client.Authorization.Should().NotBeNull();
            client.Authorization.IsExpired.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktClient_Parameter_Constructor()
        {
            var client1 = new TraktClient(CLIENT_ID);

            client1.ClientId.Should().Be(CLIENT_ID);
            client1.ClientSecret.Should().BeNull();
            client1.Authorization.Should().NotBeNull();
            client1.Authorization.IsExpired.Should().BeTrue();

            var client2 = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client2.ClientId.Should().Be(CLIENT_ID);
            client2.ClientSecret.Should().Be(CLIENT_SECRET);
            client2.Authorization.Should().NotBeNull();
            client2.Authorization.IsExpired.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktClient_Is_Valid_For_Use_Without_Authorization()
        {
            var client = new TraktClient();
            client.IsValidForUseWithoutAuthorization.Should().BeFalse();

            client.ClientId = "client id";
            client.IsValidForUseWithoutAuthorization.Should().BeFalse();

            client.ClientId = CLIENT_ID;
            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktClient_Is_Valid_For_Authentication_Process()
        {
            var client = new TraktClient();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.ClientId = "client id";
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.ClientId = CLIENT_ID;
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.ClientSecret = "client secret";
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.ClientSecret = CLIENT_SECRET;
            client.IsValidForAuthenticationProcess.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktClient_Is_Valid_For_Use_With_Authorization()
        {
            var client = new TraktClient();
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.ClientId = "client id";
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.ClientId = CLIENT_ID;
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.Authorization = TraktAuthorization.CreateWith("access token");
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.Authorization = TraktAuthorization.CreateWith("accessToken");
            client.IsValidForUseWithAuthorization.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktClient_Get_Configuration()
        {
            var client = new TraktClient();

            client.Configuration.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_Authentication()
        {
            var client = new TraktClient();

            client.Authentication.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_CalendarModule()
        {
            var client = new TraktClient();

            client.Calendar.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_CertificationsModule()
        {
            var client = new TraktClient();

            client.Certifications.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_CheckinsModule()
        {
            var client = new TraktClient();

            client.Checkins.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_CommentsModule()
        {
            var client = new TraktClient();

            client.Comments.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_EpisodesModule()
        {
            var client = new TraktClient();

            client.Episodes.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_GenresModule()
        {
            var client = new TraktClient();

            client.Genres.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_ListsModule()
        {
            var client = new TraktClient();

            client.Lists.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_MoviesModule()
        {
            var client = new TraktClient();

            client.Movies.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_NetworksModule()
        {
            var client = new TraktClient();

            client.Networks.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_PeopleModule()
        {
            var client = new TraktClient();

            client.People.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_RecommendationsModule()
        {
            var client = new TraktClient();

            client.Recommendations.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_ScrobbleModule()
        {
            var client = new TraktClient();

            client.Scrobble.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_SearchModule()
        {
            var client = new TraktClient();

            client.Search.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_SeasonsModule()
        {
            var client = new TraktClient();

            client.Seasons.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_ShowsModule()
        {
            var client = new TraktClient();

            client.Shows.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_SyncModule()
        {
            var client = new TraktClient();

            client.Sync.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktClient_Get_UsersModule()
        {
            var client = new TraktClient();

            client.Users.Should().NotBeNull();
        }
    }
}
