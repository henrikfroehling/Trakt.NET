namespace TraktApiSharp.Tests.Modules
{
    using Core;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RichardSzalay.MockHttp;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using TraktApiSharp.Modules;
    using Utils;

    [TestClass]
    public class TraktCalendarModuleTests
    {
        private static MockHttpMessageHandler MOCK_HTTP;
        private static string BASE_URL;

        [TestMethod]
        public void TestTraktCalendarModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktCalendarModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            BASE_URL = new TraktClient().Configuration.BaseUrl;
            MOCK_HTTP = new MockHttpMessageHandler();

            TraktConfiguration.HTTP_CLIENT = new HttpClient(MOCK_HTTP);

            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Add("trakt-api-key", "trakt client id");
            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Add("trakt-api-version", "2");

            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TraktConfiguration.HTTP_CLIENT = null;
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            MOCK_HTTP.Clear();
        }

        private void SetupMockRequestWithoutOAuth(string uri, string responseContent)
        {
            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond("application/json", responseContent);
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShows()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            SetupMockRequestWithoutOAuth("calendars/all/shows", calendarShowsJson);

            var response = new TraktClient().Calendar.GetAllShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/{today.ToString("yyyy-MM-dd")}", calendarShowsJson);

            var response = new TraktClient().Calendar.GetAllShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/{days}", calendarShowsJson);

            var response = new TraktClient().Calendar.GetAllShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/{today.ToString("yyyy-MM-dd")}/{days}", calendarShowsJson);

            var response = new TraktClient().Calendar.GetAllShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShows()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            SetupMockRequestWithoutOAuth("calendars/all/shows/new", calendarNewShowsJson);

            var response = new TraktClient().Calendar.GetAllNewShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDate()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/new/{today.ToString("yyyy-MM-dd")}", calendarNewShowsJson);

            var response = new TraktClient().Calendar.GetAllNewShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/new/{days}", calendarNewShowsJson);

            var response = new TraktClient().Calendar.GetAllNewShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDateAndDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/new/{today.ToString("yyyy-MM-dd")}/{days}", calendarNewShowsJson);

            var response = new TraktClient().Calendar.GetAllNewShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieres()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            SetupMockRequestWithoutOAuth("calendars/all/shows/premieres", calendarSeasonPremieresJson);

            var response = new TraktClient().Calendar.GetAllSeasonPremieresAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/premieres/{today.ToString("yyyy-MM-dd")}", calendarSeasonPremieresJson);

            var response = new TraktClient().Calendar.GetAllSeasonPremieresAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/premieres/{days}", calendarSeasonPremieresJson);

            var response = new TraktClient().Calendar.GetAllSeasonPremieresAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/shows/premieres/{today.ToString("yyyy-MM-dd")}/{days}", calendarSeasonPremieresJson);

            var response = new TraktClient().Calendar.GetAllSeasonPremieresAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMovies()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            SetupMockRequestWithoutOAuth("calendars/all/movies", calendarMoviesJson);

            var response = new TraktClient().Calendar.GetAllMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            SetupMockRequestWithoutOAuth($"calendars/all/movies/{today.ToString("yyyy-MM-dd")}", calendarMoviesJson);

            var response = new TraktClient().Calendar.GetAllMoviesAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/movies/{days}", calendarMoviesJson);

            var response = new TraktClient().Calendar.GetAllMoviesAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            SetupMockRequestWithoutOAuth($"calendars/all/movies/{today.ToString("yyyy-MM-dd")}/{days}", calendarMoviesJson);

            var response = new TraktClient().Calendar.GetAllMoviesAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShows()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDate()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithDays()
        {

        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShows()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDate()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithDays()
        {

        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieres()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDate()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithDays()
        {

        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMovies()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDate()
        {

        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithDays()
        {

        }
    }
}
