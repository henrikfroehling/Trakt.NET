namespace TraktApiSharp.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraktClientTests
    {
        private const string CLIENT_ID = "CLIENT_ID";
        private const string CLIENT_SECRET = "CLIENT_SECRET";

        [TestMethod]
        public void TestTraktClientDefaultConstructor()
        {
            var client = new TraktClient();

            client.ClientId.Should().BeNull();
            client.ClientSecret.Should().BeNull();

            client.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktClientParameterConstructor()
        {
            var client1 = new TraktClient(CLIENT_ID);

            client1.ClientId.Should().Be(CLIENT_ID);
            client1.ClientSecret.Should().BeNull();

            client1.IsValid.Should().BeFalse();
            client1.IsValidForUseWithoutAuthorization.Should().BeTrue();

            var client2 = new TraktClient(CLIENT_ID, CLIENT_SECRET);

            client2.ClientId.Should().Be(CLIENT_ID);
            client2.ClientSecret.Should().Be(CLIENT_SECRET);

            client2.IsValid.Should().BeTrue();
            client2.IsValidForUseWithoutAuthorization.Should().BeTrue();
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
    }
}
