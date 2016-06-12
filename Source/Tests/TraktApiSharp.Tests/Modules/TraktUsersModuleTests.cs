namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Collections;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktUsersModuleTests
    {
        [TestMethod]
        public void TestTraktUsersModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktUsersModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserSettings

        [TestMethod]
        public void TestTraktUsersModuleGetSettings()
        {
            var userSettings = TestUtility.ReadFileContents(@"Objects\Get\Users\UserSettings.json");
            userSettings.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/settings", userSettings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserSettingsAsync().Result;

            response.Should().NotBeNull();
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("justin");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Justin Nemeth");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
            response.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            response.User.Location.Should().Be("San Diego, CA");
            response.User.About.Should().Be("Co-founder of trakt.");
            response.User.Gender.Should().Be("male");
            response.User.Age.Should().Be(32);
            response.User.Images.Should().NotBeNull();
            response.User.Images.Avatar.Should().NotBeNull();
            response.User.Images.Avatar.Full.Should().Be("https://secure.gravatar.com/avatar/30c2f0dfbc39e48656f40498aa871e33?r=pg&s=256");
            response.Account.Should().NotBeNull();
            response.Account.TimeZoneId.Should().Be("America/Los_Angeles");
            response.Account.Time24Hr.Should().BeFalse();
            response.Account.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            response.Connections.Should().NotBeNull();
            response.Connections.Facebook.Should().BeTrue();
            response.Connections.Twitter.Should().BeTrue();
            response.Connections.Google.Should().BeTrue();
            response.Connections.Tumblr.Should().BeFalse();
            response.Connections.Medium.Should().BeFalse();
            response.Connections.Slack.Should().BeFalse();
            response.SharingText.Should().NotBeNull();
            response.SharingText.Watching.Should().Be("I'm watching [item]");
            response.SharingText.Watched.Should().Be("I just watched [item]");
        }

        [TestMethod]
        public void TestTraktUsersModuleGetSettingsExceptions()
        {
            var uri = "users/settings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktUserSettings>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserSettingsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFollowRequests

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowRequests()
        {
            var followRequests = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowRequests.json");
            followRequests.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/requests", followRequests);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserFollowRequestsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowRequestsExceptions()
        {
            var uri = "users/requests";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktUserFollowRequest>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserFollowRequestsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserHiddenItems

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItems()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Calendar;
            var itemCount = 3;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithType()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Recommendations;
            var type = TraktHiddenItemType.Movie;
            var itemCount = 3;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?type={type.AsString()}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndExtendedOption()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.ProgressCollected;
            var type = TraktHiddenItemType.Show;
            var itemCount = 3;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/hidden/{section.AsString()}?type={type.AsString()}&extended={extendedOption.ToString()}",
                hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, type, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPage()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Recommendations;
            var type = TraktHiddenItemType.Movie;
            var itemCount = 3;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?type={type.AsString()}&page={page}",
                                                             hiddenItems, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, type, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndLimit()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Recommendations;
            var type = TraktHiddenItemType.Movie;
            var itemCount = 3;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?type={type.AsString()}&limit={limit}",
                                                             hiddenItems, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, type, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPageAndLimit()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.ProgressCollected;
            var type = TraktHiddenItemType.Season;
            var itemCount = 3;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?type={type.AsString()}&page={page}&limit={limit}",
                                                             hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, type, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOption()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.ProgressWatched;
            var itemCount = 3;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?extended={extendedOption.ToString()}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOptionAndPage()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.ProgressWatched;
            var itemCount = 3;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/hidden/{section.AsString()}?extended={extendedOption.ToString()}&page={page}",
                hiddenItems, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOptionAndLimit()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.ProgressWatched;
            var itemCount = 3;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/hidden/{section.AsString()}?extended={extendedOption.ToString()}&limit={limit}",
                hiddenItems, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOptionAndPageAndLimit()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Calendar;
            var itemCount = 3;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/hidden/{section.AsString()}?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithPage()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Calendar;
            var itemCount = 3;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?page={page}",
                                                             hiddenItems, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithLimit()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Calendar;
            var itemCount = 3;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?limit={limit}",
                                                             hiddenItems, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithPageAndLimit()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Calendar;
            var itemCount = 3;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}?page={page}&limit={limit}",
                                                             hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsComplete()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Calendar;
            var type = TraktHiddenItemType.Season;
            var itemCount = 3;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/hidden/{section.AsString()}?type={type.AsString()}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section, type, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPageExceptions()
        {
            var section = TraktHiddenItemsSection.Calendar;
            var uri = $"users/hidden/{section.AsString()}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPaginationListResult<TraktUserHiddenItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPageArgumentExceptions()
        {
            var hiddenItems = TestUtility.ReadFileContents(@"Objects\Get\Users\UserHiddenItems.json");
            hiddenItems.Should().NotBeNullOrEmpty();

            var section = TraktHiddenItemsSection.Unspecified;
            var itemCount = 3;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.AsString()}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            Func<Task<TraktPaginationListResult<TraktUserHiddenItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserHiddenItemsAsync(section);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserLikes

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikes()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes", userLikes, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithType()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var type = TraktUserLikeType.Comment;
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.AsStringUriParameter()}", userLikes, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithTypeAndPage()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var type = TraktUserLikeType.Comment;
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.AsStringUriParameter()}?page={page}",
                                                             userLikes, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(type, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithTypeAndLimit()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var type = TraktUserLikeType.List;
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.AsStringUriParameter()}?limit={limit}",
                                                             userLikes, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(type, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithPage()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes?page={page}", userLikes, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithLimit()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes?limit={limit}", userLikes, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithPageAndLimit()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes?page={page}&limit={limit}", userLikes, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesComplete()
        {
            var userLikes = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikes.json");
            userLikes.Should().NotBeNullOrEmpty();

            var type = TraktUserLikeType.List;
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.AsStringUriParameter()}?page={page}&limit={limit}",
                                                             userLikes, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(type, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesExceptions()
        {
            var type = TraktUserLikeType.List;
            var uri = $"users/likes/{type.AsStringUriParameter()}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPaginationListResult<TraktUserLikeItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserLikesAsync(type);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserProfile

        [TestMethod]
        public void TestTraktUsersModuleGetUserProfile()
        {
            var userProfile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserProfile.json");
            userProfile.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}", userProfile);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username).Result;

            response.Should().NotBeNull();
            response.Username.Should().Be("sean");
            response.Private.Should().BeFalse();
            response.Name.Should().Be("Sean Rudford");
            response.VIP.Should().BeTrue();
            response.VIP_EP.Should().BeTrue();
            response.JoinedAt.Should().NotHaveValue();
            response.Location.Should().BeNullOrEmpty();
            response.About.Should().BeNullOrEmpty();
            response.Gender.Should().BeNullOrEmpty();
            response.Age.Should().NotHaveValue();
            response.Images.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserProfileExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktUser>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserProfileArgumentExceptions()
        {
            Func<Task<TraktUser>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCollectionMovies

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMovies()
        {
            var moviesCollection = TestUtility.ReadFileContents(@"Objects\Get\Users\UserCollectionMovies.json");
            moviesCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/movies", moviesCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionMoviesAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesWithExtendedOption()
        {
            var moviesCollection = TestUtility.ReadFileContents(@"Objects\Get\Users\UserCollectionMovies.json");
            moviesCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/movies?extended={extendedOption.ToString()}",
                                                      moviesCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionMoviesAsync(username, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/collection/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktUserCollectionMovieItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionMoviesAsync(username);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesArgumentExceptions()
        {
            Func<Task<TraktListResult<TraktUserCollectionMovieItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionMoviesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionMoviesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionMoviesAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCollectionShows

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserComments

        [TestMethod]
        public void TestTraktUsersModuleGetUserComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectTypeAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomLists

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomLists()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomSingleList

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomSingleList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomSingleListExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomSingleListArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomListItems

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region CreateCustomList

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescription()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndScope()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndDisplayNumbers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndDisplayNumbersAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithScope()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithScopeAndDisplayNumbers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithScopeAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithScopeAndDisplayNumbersAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDisplayNumbers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDisplayNumbersAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UpdateCustomList

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescription()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndScope()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndDisplayNumbers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndDisplayNumbersAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithScope()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithScopeAndDisplayNumbers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithScopeAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithScopeAndDisplayNumbersAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDisplayNumbers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDisplayNumbersAndAllowComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DeleteCustomList

        [TestMethod]
        public void TestTraktUsersModuleDeleteCustomList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleDeleteCustomListExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleDeleteCustomListArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddCustomListItems

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItemsWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItemsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveCustomListItems

        [TestMethod]
        public void TestTraktUsersModuleRemoveCustomListItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleRemoveCustomListItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleRemoveCustomListItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomListComments

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithSortOrder()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithSortOrderAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithSortOrderAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region LikeList

        [TestMethod]
        public void TestTraktUsersModuleLikeList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleLikeListExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleLikeListArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UnlikeList

        [TestMethod]
        public void TestTraktUsersModuleUnlikeList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUnlikeListExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUnlikeListArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFollowers

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowersExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowersArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFollowing

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowingExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowingArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFriends

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriends()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriendsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriendsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region FollowUser

        [TestMethod]
        public void TestTraktUsersModuleFollowUser()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleFollowUserExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleFollowUserArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UnfollowUser

        [TestMethod]
        public void TestTraktUsersModuleUnfollowUser()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUnfollowUserExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleUnfollowUserArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ApproveFollower

        [TestMethod]
        public void TestTraktUsersModuleApproveFollower()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleApproveFollowerExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleApproveFollowerArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DenyFollower

        [TestMethod]
        public void TestTraktUsersModuleDenyFollower()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleDenyFollowerExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleDenyFollowerArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchedHistory

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistory()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithIdAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithIdAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithIdAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithIdAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithIdAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserRatings

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithRatingFilter()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithRatingFilterAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchlist

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlist()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatching

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatching()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchingComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchingExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchingArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchedMovies

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMoviesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMoviesArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchedShows

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShows()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShowsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShowsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShowsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserStatistics

        [TestMethod]
        public void TestTraktUsersModuleGetUserStatistics()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserStatisticsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserStatisticsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
