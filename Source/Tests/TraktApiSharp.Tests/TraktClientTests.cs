namespace TraktApiSharp.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktClientTests
    {
        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";
        private const string ACCESS_TOKEN = "ACCESS_TOKEN";

        [TestMethod]
        public void TestTraktClientDefaultConstructor()
        {
            var client = new TraktClient();

            client.ClientId.Should().BeNull();
            client.ClientSecret.Should().BeNull();
            client.AccessToken.Should().BeNullOrEmpty();
            client.Authorization.Should().NotBeNull();
            client.Authorization.IsExpired.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktClientParameterConstructor()
        {
            var client1 = new TraktClient(CLIENT_ID);

            client1.ClientId.Should().Be(CLIENT_ID);
            client1.ClientSecret.Should().BeNull();
            client1.AccessToken.Should().BeNullOrEmpty();
            client1.Authorization.Should().NotBeNull();
            client1.Authorization.IsExpired.Should().BeTrue();

            var client2 = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client2.ClientId.Should().Be(CLIENT_ID);
            client2.ClientSecret.Should().Be(CLIENT_SECRET);
            client2.AccessToken.Should().BeNullOrEmpty();
            client2.Authorization.Should().NotBeNull();
            client2.Authorization.IsExpired.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktClientIsValidForUseWithoutAuthorization()
        {
            var client = new TraktClient();
            client.IsValidForUseWithoutAuthorization.Should().BeFalse();

            client.ClientId = "client id";
            client.IsValidForUseWithoutAuthorization.Should().BeFalse();

            client.ClientId = CLIENT_ID;
            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktClientIsValidForAuthenticationProcess()
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

        [TestMethod]
        public void TestTraktClientIsValidForUseWithAuthorization()
        {
            var client = new TraktClient();
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.ClientId = "client id";
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.ClientId = CLIENT_ID;
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.AccessToken = "access token";
            client.IsValidForUseWithAuthorization.Should().BeFalse();

            client.AccessToken = ACCESS_TOKEN;
            client.IsValidForUseWithAuthorization.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktClientGetConfiguration()
        {
            var client = new TraktClient();

            client.Configuration.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetAuthentication()
        {
            var client = new TraktClient();

            client.Authentication.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetOAuth()
        {
            var client = new TraktClient();

            client.OAuth.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetDeviceAuth()
        {
            var client = new TraktClient();

            client.DeviceAuth.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetShowsModule()
        {
            var client = new TraktClient();

            client.Shows.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetSeasonsModule()
        {
            var client = new TraktClient();

            client.Seasons.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetEpisodesModule()
        {
            var client = new TraktClient();

            client.Episodes.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetMoviesModule()
        {
            var client = new TraktClient();

            client.Movies.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetCalendarModule()
        {
            var client = new TraktClient();

            client.Calendar.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetCommentsModule()
        {
            var client = new TraktClient();

            client.Comments.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetPeopleModule()
        {
            var client = new TraktClient();

            client.People.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetGenresModule()
        {
            var client = new TraktClient();

            client.Genres.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetSearchModule()
        {
            var client = new TraktClient();

            client.Search.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetRecommendationsModule()
        {
            var client = new TraktClient();

            client.Recommendations.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetSyncModule()
        {
            var client = new TraktClient();

            client.Sync.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetUsersModule()
        {
            var client = new TraktClient();

            client.Users.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetCheckinsModule()
        {
            var client = new TraktClient();

            client.Checkins.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktClientGetScrobbleModule()
        {
            var client = new TraktClient();

            client.Scrobble.Should().NotBeNull();
        }
    }
}
