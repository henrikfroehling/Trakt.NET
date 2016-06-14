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
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
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
            var showsCollection = TestUtility.ReadFileContents(@"Objects\Get\Users\UserCollectionShows.json");
            showsCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/shows", showsCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionShowsAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsWithExtendedOption()
        {
            var showsCollection = TestUtility.ReadFileContents(@"Objects\Get\Users\UserCollectionShows.json");
            showsCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/shows?extended={extendedOption.ToString()}",
                                                      showsCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionShowsAsync(username, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/collection/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktUserCollectionShowItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionShowsAsync(username);
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
        public void TestTraktUsersModuleGetUserCollectionShowsArgumentExceptions()
        {
            Func<Task<TraktListResult<TraktUserCollectionShowItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionShowsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionShowsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCollectionShowsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserComments

        [TestMethod]
        public void TestTraktUsersModuleGetUserComments()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments", userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentType()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.All;
            var itemCount = 5;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{commentType.AsStringUriParameter()}",
                                                                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectType()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var objectType = TraktObjectType.All;
            var itemCount = 5;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}/{objectType.AsStringUriParameter()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, objectType).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectTypeAndExtendedOption()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Shout;
            var objectType = TraktObjectType.Episode;
            var itemCount = 5;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}/{objectType.AsStringUriParameter()}" +
                $"?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, objectType, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectTypeAndPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Shout;
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}/{objectType.AsStringUriParameter()}?page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, objectType, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectTypeAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Shout;
            var objectType = TraktObjectType.Movie;
            var itemCount = 5;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}/{objectType.AsStringUriParameter()}?limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, objectType, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndObjectTypeAndPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.All;
            var objectType = TraktObjectType.Season;
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}/{objectType.AsStringUriParameter()}?page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, objectType, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndExtendedOption()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndExtendedOptionAndPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}" +
                $"?extended={extendedOption.ToString()}&page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndExtendedOptionAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}" +
                $"?extended={extendedOption.ToString()}&limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndExtendedOptionAndPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}" +
                $"?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}?page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}?limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithCommentTypeAndPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.Review;
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}?page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectType()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndExtendedOption()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndExtendedOptionAndPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}?extended={extendedOption.ToString()}&page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndExtendedOptionAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}?extended={extendedOption.ToString()}&limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndExtendedOptionAndPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}" +
                $"?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}?page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}?limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithObjectTypeAndPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var objectType = TraktObjectType.List;
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{objectType.AsStringUriParameter()}?page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, objectType, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOption()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOptionAndPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments?extended={extendedOption.ToString()}&page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOptionAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments?extended={extendedOption.ToString()}&limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithExtendedOptionAndPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithPage()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments?page={page}",
                                                                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments?limit={limit}",
                                                                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithPageAndLimit()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments?page={page}&limit={limit}",
                                                                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsComplete()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var commentType = TraktCommentType.All;
            var objectType = TraktObjectType.Season;
            var itemCount = 5;
            var page = 2;
            var limit = 6;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/comments/{commentType.AsStringUriParameter()}/{objectType.AsStringUriParameter()}" +
                $"?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username, commentType, objectType,
                                                                                   extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktPaginationListResult<TraktUserComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(username);
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
        public void TestTraktUsersModuleGetUserCommentsArgumentExceptions()
        {
            Func<Task<TraktPaginationListResult<TraktUserComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCommentsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomLists

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomLists()
        {
            var customLists = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\CustomLists.json");
            customLists.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/lists", customLists);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListsAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListsAsync(username);
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
        public void TestTraktUsersModuleGetUserCustomListsArgumentExceptions()
        {
            Func<Task<TraktListResult<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomSingleList

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomSingleList()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/lists/{listId}", customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(username, listId).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomSingleListExceptions()
        {
            var username = "sean";
            var listId = "55";
            var uri = $"users/{username}/lists/{listId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(username, listId);
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
        public void TestTraktUsersModuleGetUserCustomSingleListArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomSingleListAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomListItems

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItems()
        {
            var customListItems = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");
            customListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/lists/{listId}/items", customListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, listId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsWithType()
        {
            var customListItems = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");
            customListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var type = TraktListItemType.Episode;

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/lists/{listId}/items/{type.AsStringUriParameter()}",
                                                      customListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, listId, type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsWithExtendedOption()
        {
            var customListItems = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");
            customListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/lists/{listId}/items?extended={extendedOption.ToString()}",
                                                      customListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, listId, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsComplete()
        {
            var customListItems = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");
            customListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var type = TraktListItemType.Season;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth(
                $"users/{username}/lists/{listId}/items/{type.AsStringUriParameter()}?extended={extendedOption.ToString()}",
                customListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, listId, type, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsExceptions()
        {
            var username = "sean";
            var listId = "55";
            var uri = $"users/{username}/lists/{listId}/items";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktListItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, listId);
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
        public void TestTraktUsersModuleGetUserCustomListItemsArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task<TraktListResult<TraktListItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserCustomListItemsAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region CreateCustomList

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomList()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescription()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndPrivacy()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var privacy = TraktAccessScope.Public;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, privacy).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndPrivacyAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var privacy = TraktAccessScope.Public;
            var displayNumbers = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, privacy,
                                                                                    displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndPrivacyAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var privacy = TraktAccessScope.Public;
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, privacy,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var displayNumbers = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, null, displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, null,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDescriptionAndDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var displayNumbers = true;
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, null,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithPrivacy()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var privacy = TraktAccessScope.Public;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Privacy = privacy
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, privacy).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithPrivacyAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var privacy = TraktAccessScope.Public;
            var displayNumbers = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Privacy = privacy,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, privacy, displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithPrivacyAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var privacy = TraktAccessScope.Public;
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Privacy = privacy,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, privacy, null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithPrivacyAndDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = true;
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, privacy,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var displayNumbers = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, null, displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, null,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListWithDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var displayNumbers = true;
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, null, null,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListComplete()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listName = "new list";
            var description = "list description";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = true;
            var allowComments = true;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName, description, privacy,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleCreateCustomListExceptions()
        {
            var username = "sean";
            var listName = "new list";

            var uri = $"users/{username}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, listName);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

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
        public void TestTraktUsersModuleCreateCustomListArgumentExceptions()
        {
            var username = "sean";
            var listName = "new list";

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(null, listName);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(string.Empty, listName);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync("user name", listName);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.CreateCustomListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UpdateCustomList

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithName()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescription()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescriptionAndPrivacy()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, privacy).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescriptionAndPrivacyAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = false;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, privacy,
                                                                                    displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescriptionAndPrivacyAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, privacy,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescriptionAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var displayNumbers = false;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, null,
                                                                                    displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescriptionAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, null,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithNameAndDescriptionAndDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var displayNumbers = false;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, null,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescription()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";

            var createListPost = new TraktUserCustomListPost
            {
                Description = description
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndPrivacy()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description,
                Privacy = privacy
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description, privacy).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndPrivacyAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = false;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description, privacy,
                                                                                    displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndPrivacyAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description,
                Privacy = privacy,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description, privacy,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";
            var displayNumbers = false;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description, null,
                                                                                    displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description, null,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDescriptionAndDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var description = "new list description";
            var displayNumbers = false;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description, null,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithPrivacy()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var privacy = TraktAccessScope.Private;

            var createListPost = new TraktUserCustomListPost
            {
                Privacy = privacy
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, privacy).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithPrivacyAndDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = false;

            var createListPost = new TraktUserCustomListPost
            {
                Privacy = privacy,
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, privacy, displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithPrivacyAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var privacy = TraktAccessScope.Private;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Privacy = privacy,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, privacy,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithPrivacyAndDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = false;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, privacy,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDisplayNumbers()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var displayNumbers = false;

            var createListPost = new TraktUserCustomListPost
            {
                DisplayNumbers = displayNumbers
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, null, displayNumbers).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, null,
                                                                                    null, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListWithDisplayNumbersAndAllowComments()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var displayNumbers = false;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null, null,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListComplete()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var listName = "new list name";
            var description = "new list description";
            var privacy = TraktAccessScope.Private;
            var displayNumbers = false;
            var allowComments = false;

            var createListPost = new TraktUserCustomListPost
            {
                Name = listName,
                Description = description,
                Privacy = privacy,
                DisplayNumbers = displayNumbers,
                AllowComments = allowComments
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName, description, privacy,
                                                                                    displayNumbers, allowComments).Result;

            response.Should().NotBeNull();
            response.Name.Should().Be("Star Wars in machete order");
            response.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            response.Privacy.Should().Be(TraktAccessScope.Public);
            response.DisplayNumbers.Should().BeTrue();
            response.AllowComments.Should().BeFalse();
            response.SortBy.Should().Be("rank");
            response.SortHow.Should().Be("asc");
            response.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            response.ItemCount.Should().Be(5);
            response.CommentCount.Should().Be(1);
            response.Likes.Should().Be(2);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(55);
            response.Ids.Slug.Should().Be("star-wars-in-machete-order");
            response.User.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleUpdateCustomListExceptions()
        {
            var username = "sean";
            var listId = "55";

            var uri = $"users/{username}/lists/{listId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

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
        public void TestTraktUsersModuleUpdateCustomListArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var description = string.Empty;

            var createListPost = new TraktUserCustomListPost
            {
                Description = description
            };

            var postJson = TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", postJson, customList);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, description);
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, null, null,
                                                                                             TraktAccessScope.Unspecified);
            act.ShouldThrow<ArgumentException>();
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
