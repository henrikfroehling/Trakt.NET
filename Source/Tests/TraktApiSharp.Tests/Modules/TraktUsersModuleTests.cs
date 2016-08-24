namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Collection;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Requests.Params;
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetSettingsAsync().Result;

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
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetSettingsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowRequestsAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowRequestsWithExtendedOption()
        {
            var followRequests = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowRequests.json");
            followRequests.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"users/requests?extended={extendedOption.ToString()}", followRequests);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowRequestsAsync(extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowRequestsExceptions()
        {
            var uri = "users/requests";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktUserFollowRequest>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowRequestsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?type={type.UriName}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, type).Result;

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
                $"users/hidden/{section.UriName}?type={type.UriName}&extended={extendedOption.ToString()}",
                hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, type, extendedOption).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?type={type.UriName}&page={page}",
                                                             hiddenItems, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, type, null, page).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?type={type.UriName}&limit={limit}",
                                                             hiddenItems, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, type, null, null, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?type={type.UriName}&page={page}&limit={limit}",
                                                             hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, type, null, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?extended={extendedOption.ToString()}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, extendedOption).Result;

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
                $"users/hidden/{section.UriName}?extended={extendedOption.ToString()}&page={page}",
                hiddenItems, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, extendedOption, page).Result;

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
                $"users/hidden/{section.UriName}?extended={extendedOption.ToString()}&limit={limit}",
                hiddenItems, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, extendedOption, null, limit).Result;

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
                $"users/hidden/{section.UriName}?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, extendedOption, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?page={page}",
                                                             hiddenItems, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, null, page).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?limit={limit}",
                                                             hiddenItems, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, null, null, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}?page={page}&limit={limit}",
                                                             hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, null, null, page, limit).Result;

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
                $"users/hidden/{section.UriName}?type={type.UriName}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                hiddenItems, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section, type, extendedOption, page, limit).Result;

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
            var uri = $"users/hidden/{section.UriName}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPaginationListResult<TraktUserHiddenItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/hidden/{section.UriName}",
                                                             hiddenItems, 1, 10, 1, itemCount);

            Func<Task<TraktPaginationListResult<TraktUserHiddenItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetHiddenItemsAsync(section);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync().Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.UriName}", userLikes, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(type).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.UriName}?page={page}",
                                                             userLikes, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(type, page).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.UriName}?limit={limit}",
                                                             userLikes, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(type, null, limit).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(null, page).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(null, null, limit).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(null, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/likes/{type.UriName}?page={page}&limit={limit}",
                                                             userLikes, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(type, page, limit).Result;

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
            var uri = $"users/likes/{type.UriName}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPaginationListResult<TraktUserLikeItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetLikesAsync(type);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserProfileWithExtendedOption()
        {
            var userProfile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserProfile.json");
            userProfile.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}?extended={extendedOption.ToString()}", userProfile);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username, extendedOption).Result;

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
        public void TestTraktUsersModuleGetUserProfileWithOAuthEnforced()
        {
            var userProfile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserProfile.json");
            userProfile.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}", userProfile);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktUser>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            var moviesCollection = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMovies.json");
            moviesCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/movies", moviesCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesWithOAuthEnforced()
        {
            var moviesCollection = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMovies.json");
            moviesCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/collection/movies", moviesCollection);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesWithExtendedOption()
        {
            var moviesCollection = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMovies.json");
            moviesCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/movies?extended={extendedOption.ToString()}",
                                                      moviesCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/collection/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktCollectionMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            Func<Task<IEnumerable<TraktCollectionMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionMoviesAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCollectionShows

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShows()
        {
            var showsCollection = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShows.json");
            showsCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/shows", showsCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsWithOAuthEnforced()
        {
            var showsCollection = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShows.json");
            showsCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/collection/shows", showsCollection);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsWithExtendedOption()
        {
            var showsCollection = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShows.json");
            showsCollection.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/collection/shows?extended={extendedOption.ToString()}",
                                                      showsCollection);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionShowsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/collection/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktCollectionShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            Func<Task<IEnumerable<TraktCollectionShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCollectionShowsAsync("user name");
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCommentsWithOAuthEnforced()
        {
            var userComments = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");
            userComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 5;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/{username}/comments", userComments, 1, 10, 1, itemCount);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{commentType.UriName}",
                                                                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType).Result;

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
                $"users/{username}/comments/{commentType.UriName}/{objectType.UriName}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, objectType).Result;

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
                $"users/{username}/comments/{commentType.UriName}/{objectType.UriName}" +
                $"?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, objectType, extendedOption).Result;

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
                $"users/{username}/comments/{commentType.UriName}/{objectType.UriName}?page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, objectType, null, page).Result;

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
                $"users/{username}/comments/{commentType.UriName}/{objectType.UriName}?limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, objectType, null, null, limit).Result;

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
                $"users/{username}/comments/{commentType.UriName}/{objectType.UriName}?page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, objectType, null, page, limit).Result;

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
                $"users/{username}/comments/{commentType.UriName}?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, extendedOption).Result;

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
                $"users/{username}/comments/{commentType.UriName}?extended={extendedOption.ToString()}&page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, extendedOption, page).Result;

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
                $"users/{username}/comments/{commentType.UriName}?extended={extendedOption.ToString()}&limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, extendedOption, null, limit).Result;

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
                $"users/{username}/comments/{commentType.UriName}?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, extendedOption, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{commentType.UriName}?page={page}",
                                                                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, null, page).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{commentType.UriName}?limit={limit}",
                                                                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, null, null, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{commentType.UriName}?page={page}&limit={limit}",
                                                                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, null, null, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{objectType.UriName}",
                                                                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType).Result;

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
                $"users/{username}/comments/{objectType.UriName}?extended={extendedOption.ToString()}",
                userComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, extendedOption).Result;

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
                $"users/{username}/comments/{objectType.UriName}?extended={extendedOption.ToString()}&page={page}",
                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, extendedOption, page).Result;

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
                $"users/{username}/comments/{objectType.UriName}?extended={extendedOption.ToString()}&limit={limit}",
                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, extendedOption, null, limit).Result;

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
                $"users/{username}/comments/{objectType.UriName}?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, extendedOption, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{objectType.UriName}?page={page}",
                                                                userComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, null, page).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{objectType.UriName}?limit={limit}",
                                                                userComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, null, null, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{objectType.UriName}?page={page}&limit={limit}",
                                                                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, objectType, null, page, limit).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, extendedOption).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, extendedOption, page).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, extendedOption, null, limit).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, extendedOption, page, limit).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, null, page).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, null, null, limit).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, null, null, null, page, limit).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/comments/{commentType.UriName}/{objectType.UriName}" +
                                                                $"?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                                                                userComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username, commentType, objectType,
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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktUserComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCommentsAsync("user name");
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListsWithOAuthEnfored()
        {
            var customLists = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\CustomLists.json");
            customLists.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists", customLists);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            Func<Task<IEnumerable<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListsAsync("user name");
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(username, listId).Result;

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
        public void TestTraktUsersModuleGetUserCustomSingleListWithOAuthEnforced()
        {
            var customList = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\List.json");
            customList.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", customList);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(username, listId).Result;

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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(username, listId);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomSingleListAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserMultipleCustomLists

        [TestMethod]
        public void TestTraktUsersModuleGetMultipleCustomListsArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task<IEnumerable<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(null);
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams());
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams { { null, listId } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams { { string.Empty, listId } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams { { "user name", listId } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams { { username, null } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams { { username, string.Empty } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetMultipleCustomListsAsync(
                new TraktMultipleUserListsQueryParams { { username, "list id" } });
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, listId).Result;

            response.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsWithOAuthEnforced()
        {
            var customListItems = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");
            customListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}/items", customListItems);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, listId).Result;

            response.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsWithType()
        {
            var customListItems = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListItems.json");
            customListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var type = TraktListItemType.Episode;

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/lists/{listId}/items/{type.UriName}",
                                                      customListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, listId, type).Result;

            response.Should().NotBeNull().And.HaveCount(5);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, listId, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(5);
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
                $"users/{username}/lists/{listId}/items/{type.UriName}?extended={extendedOption.ToString()}",
                customListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, listId, type, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(5);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListItemsExceptions()
        {
            var username = "sean";
            var listId = "55";
            var uri = $"users/{username}/lists/{listId}/items";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktListItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, listId);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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

            Func<Task<IEnumerable<TraktListItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetCustomListItemsAsync(username, "list id");
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
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            var listName = "new list name";

            var uri = $"users/{username}/lists/{listId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktList>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.UpdateCustomListAsync(username, listId, listName);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(username, listId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktUsersModuleDeleteCustomListExceptions()
        {
            var username = "sean";
            var listId = "55";

            var uri = $"users/{username}/lists/{listId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(username, listId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleDeleteCustomListArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DeleteCustomListAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddCustomListItems

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItems()
        {
            var addedCustomListItems = TestUtility.ReadFileContents(@"Objects\Post\Users\CustomListItems\Responses\UserCustomListItemsPostResponse.json");
            addedCustomListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(customListItems);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}/items", postJson, addedCustomListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, listId, customListItems).Result;

            response.Should().NotBeNull();

            response.Added.Should().NotBeNull();
            response.Added.Movies.Should().Be(1);
            response.Added.Shows.Should().Be(1);
            response.Added.Seasons.Should().Be(1);
            response.Added.Episodes.Should().Be(2);
            response.Added.People.Should().Be(1);

            response.Existing.Should().NotBeNull();
            response.Existing.Movies.Should().Be(0);
            response.Existing.Shows.Should().Be(0);
            response.Existing.Seasons.Should().Be(0);
            response.Existing.Episodes.Should().Be(0);
            response.Existing.People.Should().Be(0);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
            response.NotFound.People.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItemsWithType()
        {
            var addedCustomListItems = TestUtility.ReadFileContents(@"Objects\Post\Users\CustomListItems\Responses\UserCustomListItemsPostResponse.json");
            addedCustomListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var type = TraktListItemType.Movie;

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(customListItems);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}/items/{type.UriName}",
                                                   postJson, addedCustomListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, listId, customListItems, type).Result;

            response.Should().NotBeNull();

            response.Added.Should().NotBeNull();
            response.Added.Movies.Should().Be(1);
            response.Added.Shows.Should().Be(1);
            response.Added.Seasons.Should().Be(1);
            response.Added.Episodes.Should().Be(2);
            response.Added.People.Should().Be(1);

            response.Existing.Should().NotBeNull();
            response.Existing.Movies.Should().Be(0);
            response.Existing.Shows.Should().Be(0);
            response.Existing.Seasons.Should().Be(0);
            response.Existing.Episodes.Should().Be(0);
            response.Existing.People.Should().Be(0);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
            response.NotFound.People.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktUsersModuleAddCustomListItemsExceptions()
        {
            var username = "sean";
            var listId = "55";

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            var uri = $"users/{username}/lists/{listId}/items";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktUserCustomListItemsPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, listId, customListItems);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleAddCustomListItemsArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            Func<Task<TraktUserCustomListItemsPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(null, listId, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(string.Empty, listId, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync("user name", listId, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, null, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, string.Empty, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, "list id", customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, listId, null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, listId, new TraktUserCustomListItemsPost());
            act.ShouldThrow<ArgumentException>();

            customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>(),
                Shows = new List<TraktUserCustomListItemsPostShow>(),
                People = new List<TraktPerson>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.AddCustomListItemsAsync(username, listId, customListItems);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveCustomListItems

        [TestMethod]
        public void TestTraktUsersModuleRemoveCustomListItems()
        {
            var removedCustomListItems = TestUtility.ReadFileContents(@"Objects\Post\Users\CustomListItems\Responses\UserCustomListItemsRemovePostResponse.json");
            removedCustomListItems.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(customListItems);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}/items/remove", postJson, removedCustomListItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, listId, customListItems).Result;

            response.Should().NotBeNull();

            response.Deleted.Should().NotBeNull();
            response.Deleted.Movies.Should().Be(1);
            response.Deleted.Shows.Should().Be(1);
            response.Deleted.Seasons.Should().Be(1);
            response.Deleted.Episodes.Should().Be(2);
            response.Deleted.People.Should().Be(1);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
            response.NotFound.People.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktUsersModuleRemoveCustomListItemsExceptions()
        {
            var username = "sean";
            var listId = "55";

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    },
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Imdb = "tt0000111" }
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 2 }
                    },
                    new TraktUserCustomListItemsPostShow
                    {
                        Seasons = new List<TraktUserCustomListItemsPostShowSeason>()
                        {
                            new TraktUserCustomListItemsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktUserCustomListItemsPostShowEpisode>()
                                {
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktUserCustomListItemsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        },
                        Ids = new TraktShowIds { Trakt = 3 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            var uri = $"users/{username}/lists/{listId}/items/remove";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktUserCustomListItemsRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, listId, customListItems);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleRemoveCustomListItemsArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            var customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>()
                {
                    new TraktUserCustomListItemsPostMovie
                    {
                        Ids = new TraktMovieIds { Trakt = 1 },
                    }
                },
                Shows = new List<TraktUserCustomListItemsPostShow>()
                {
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = new TraktShowIds { Trakt = 1 }
                    }
                },
                People = new List<TraktPerson>()
                {
                    new TraktPerson
                    {
                        Name = "Jeff Bridges",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 2,
                            Slug = "jeff-bridges",
                            Imdb = "nm0000313",
                            Tmdb = 1229,
                            TvRage = 59067
                        }
                    }
                }
            };

            Func<Task<TraktUserCustomListItemsRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(null, listId, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(string.Empty, listId, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync("user name", listId, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, null, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, string.Empty, customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, "list id", customListItems);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, listId, null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, listId, new TraktUserCustomListItemsPost());
            act.ShouldThrow<ArgumentException>();

            customListItems = new TraktUserCustomListItemsPost
            {
                Movies = new List<TraktUserCustomListItemsPostMovie>(),
                Shows = new List<TraktUserCustomListItemsPostShow>(),
                People = new List<TraktPerson>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.RemoveCustomListItemsAsync(username, listId, customListItems);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCustomListComments

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommments()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/lists/{listId}/comments",
                                                                listComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithSortOrder()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var sortOrder = TraktCommentSortOrder.Likes;
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/lists/{listId}/comments/{sortOrder.UriName}",
                                                                listComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, sortOrder).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithPage()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/lists/{listId}/comments?page={page}",
                                                                listComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithSortOrderAndPage()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var sortOrder = TraktCommentSortOrder.Newest;
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/lists/{listId}/comments/{sortOrder.UriName}?page={page}",
                listComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithLimit()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/lists/{listId}/comments?limit={limit}",
                                                                listComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithSortOrderAndLimit()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var sortOrder = TraktCommentSortOrder.Oldest;
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/lists/{listId}/comments/{sortOrder.UriName}?limit={limit}",
                listComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsWithPageAndLimit()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/lists/{listId}/comments?page={page}&limit={limit}",
                listComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsComplete()
        {
            var listComments = TestUtility.ReadFileContents(@"Objects\Get\Users\Lists\ListComments.json");
            listComments.Should().NotBeNullOrEmpty();

            var username = "sean";
            var listId = "55";
            var sortOrder = TraktCommentSortOrder.Replies;
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/lists/{listId}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                listComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCustomListCommmentsExceptions()
        {
            var username = "sean";
            var listId = "55";
            var uri = $"users/{username}/lists/{listId}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, listId);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserCustomListCommmentsArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task<TraktPaginationListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetListCommentsAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region LikeList

        [TestMethod]
        public void TestTraktUsersModuleLikeList()
        {
            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}/like", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(username, listId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktUsersModuleLikeListExceptions()
        {
            var username = "sean";
            var listId = "55";

            var uri = $"users/{username}/lists/{listId}/like";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(username, listId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleLikeListArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.LikeListAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UnlikeList

        [TestMethod]
        public void TestTraktUsersModuleUnlikeList()
        {
            var username = "sean";
            var listId = "55";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/lists/{listId}/like", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(username, listId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktUsersModuleUnlikeListExceptions()
        {
            var username = "sean";
            var listId = "55";

            var uri = $"users/{username}/lists/{listId}/like";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(username, listId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktListNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleUnlikeListArgumentExceptions()
        {
            var username = "sean";
            var listId = "55";

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(null, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(string.Empty, listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync("user name", listId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(username, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(username, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnlikeListAsync(username, "list id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFollowers

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowers()
        {
            var userFollowers = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowers.json");
            userFollowers.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/followers", userFollowers);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowersWithExtendedOption()
        {
            var userFollowers = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowers.json");
            userFollowers.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/followers?extended={extendedOption.ToString()}",
                                                      userFollowers);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowersWithOAuthEnforced()
        {
            var userFollowers = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowers.json");
            userFollowers.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/followers", userFollowers);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowersExceptions()
        {
            var username = "sean";

            var uri = $"users/{username}/followers";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktUserFollower>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserFollowersArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktUserFollower>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowersAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFollowing

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowing()
        {
            var userFollowing = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowers.json");
            userFollowing.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/following", userFollowing);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowingWithExtendedOption()
        {
            var userFollowing = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowers.json");
            userFollowing.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/following?extended={extendedOption.ToString()}",
                                                      userFollowing);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowingWithOAuthEnforced()
        {
            var userFollowing = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowers.json");
            userFollowing.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/following", userFollowing);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowingExceptions()
        {
            var username = "sean";

            var uri = $"users/{username}/following";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktUserFollower>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserFollowingArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktUserFollower>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFollowingAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFriends

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriends()
        {
            var userFriends = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFriends.json");
            userFriends.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/friends", userFriends);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriendsWithExtendedOption()
        {
            var userFriends = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFriends.json");
            userFriends.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/friends?extended={extendedOption.ToString()}",
                                                      userFriends);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriendsWithOAuthEnforced()
        {
            var userFriends = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFriends.json");
            userFriends.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/friends", userFriends);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFriendsExceptions()
        {
            var username = "sean";

            var uri = $"users/{username}/friends";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktUserFriend>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserFriendsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktUserFriend>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetFriendsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region FollowUser

        [TestMethod]
        public void TestTraktUsersModuleFollowUser()
        {
            var followedUser = TestUtility.ReadFileContents(@"Objects\Post\Users\Responses\FollowUserPostResponse.json");
            followedUser.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/follow", followedUser);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.FollowUserAsync(username).Result;

            response.Should().NotBeNull();
            response.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktUsersModuleFollowUserExceptions()
        {
            var username = "sean";

            var uri = $"users/{username}/follow";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktUserFollowUserPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.FollowUserAsync(username);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleFollowUserArgumentExceptions()
        {
            Func<Task<TraktUserFollowUserPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.FollowUserAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.FollowUserAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.FollowUserAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UnfollowUser

        [TestMethod]
        public void TestTraktUsersModuleUnfollowUser()
        {
            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/follow", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnfollowUserAsync(username);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktUsersModuleUnfollowUserExceptions()
        {
            var username = "sean";

            var uri = $"users/{username}/follow";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnfollowUserAsync(username);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleUnfollowUserArgumentExceptions()
        {
            Func<Task> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnfollowUserAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnfollowUserAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.UnfollowUserAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ApproveFollower

        [TestMethod]
        public void TestTraktUsersModuleApproveFollower()
        {
            var approvedUser = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollower.json");
            approvedUser.Should().NotBeNullOrEmpty();

            var requestId = 3U;

            TestUtility.SetupMockResponseWithOAuth($"users/requests/{requestId}", approvedUser);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.ApproveFollowRequestAsync(requestId).Result;

            response.Should().NotBeNull();
            response.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            response.User.Should().NotBeNull();
            response.User.Username.Should().Be("sean");
            response.User.Private.Should().BeFalse();
            response.User.Name.Should().Be("Sean Rudford");
            response.User.VIP.Should().BeTrue();
            response.User.VIP_EP.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktUsersModuleApproveFollowerExceptions()
        {
            var requestId = 3U;

            var uri = $"users/requests/{requestId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktUserFollower>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.ApproveFollowRequestAsync(requestId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktObjectNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleApproveFollowerArgumentExceptions()
        {
            Func<Task<TraktUserFollower>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.ApproveFollowRequestAsync(0);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DenyFollower

        [TestMethod]
        public void TestTraktUsersModuleDenyFollower()
        {
            var requestId = 3U;

            TestUtility.SetupMockResponseWithOAuth($"users/requests/{requestId}", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DenyFollowRequestAsync(requestId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktUsersModuleDenyFollowerExceptions()
        {
            var requestId = 3U;

            var uri = $"users/requests/{requestId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.DenyFollowRequestAsync(requestId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktObjectNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleDenyFollowerArgumentExceptions()
        {
            Func<Task> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.DenyFollowRequestAsync(0);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchedHistory

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistory()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history", userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithOAuthEnforced()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/{username}/history", userHistory, 1, 10, 1, itemCount);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithType()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}",
                                                                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndId()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}/{itemId}",
                                                                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Season;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndEndDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}" +
                $"&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndStartDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndIdAndEndDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemId = 4UL;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}" +
                $"&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}",
                                                                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                                                                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                                                                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                                                                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndStartDateAndEndDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}",
                                                                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                                                                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                                                                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndEndDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                                                                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}?extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}?extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}?extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                                                                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}?page={page}",
                                                                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}?limit={limit}",
                                                                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithTypeAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Show;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}?page={page}&limit={limit}",
                                                                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndEndDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithStartDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDate()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithEndDateAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOption()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedOption.ToString()}",
                userHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOptionAndPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedOption.ToString()}&page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOptionAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedOption.ToString()}&limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithExtendedOptionAndPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithPage()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?page={page}",
                userHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?limit={limit}",
                userHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryWithPageAndLimit()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryComplete()
        {
            var userHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            userHistory.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktSyncItemType.Movie;
            var itemId = 4UL;
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedHistoryExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/history";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username);
            act.ShouldThrow<TraktObjectNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserWatchedHistoryArgumentExceptions()
        {
            Func<Task<TraktPaginationListResult<TraktHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserRatings

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatings()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithOAuthEnforced()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/ratings", userRatings);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithType()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktRatingsItemType.Movie;

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Show;
            var ratingsFilter = new int[] { 1, 2, 3 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Season;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Episode;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.All;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithRatingsFilter()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings", userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, null, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithTypeAndExtendedOption()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";
            var type = TraktRatingsItemType.Movie;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}?extended={extendedOption.ToString()}",
                                                      userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsWithExtendedOption()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings?extended={extendedOption.ToString()}",
                                                      userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, null, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsComplete()
        {
            var userRatings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            userRatings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth(
                $"users/{username}/ratings/{type.UriName}/{ratingsFilterString}?extended={extendedOption.ToString()}",
                userRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserRatingsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktRatingsItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserRatingsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktRatingsItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchlist

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlist()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist", userWatchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistWithOAuthEnforced()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/{username}/watchlist", userWatchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistWithType()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var type = TraktSyncItemType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}",
                userWatchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithTypeAndExtendedOption()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var type = TraktSyncItemType.Movie;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}?extended={extendedOption.ToString()}",
                userWatchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithTypeAndExtendedOptionAndPage()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}?extended={extendedOption.ToString()}&page={page}",
                userWatchlist, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedOption,
                                                                                page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithTypeAndExtendedOptionAndLimit()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}?extended={extendedOption.ToString()}&limit={limit}",
                userWatchlist, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedOption,
                                                                                null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistWithExtendedOption()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedOption.ToString()}",
                userWatchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithExtendedOptionAndPage()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedOption.ToString()}&page={page}",
                userWatchlist, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedOption,
                                                                                page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithExtendedOptionAndLimit()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedOption.ToString()}&limit={limit}",
                userWatchlist, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedOption,
                                                                                null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithExtendedOptionAndPageAndLimit()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userWatchlist, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedOption,
                                                                                page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithPage()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?page={page}",
                userWatchlist, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithLimit()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?limit={limit}",
                userWatchlist, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, null,
                                                                                null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetWatchlistWithPageAndLimit()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?page={page}&limit={limit}",
                userWatchlist, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, null,
                                                                                page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistComplete()
        {
            var userWatchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            userWatchlist.Should().NotBeNullOrEmpty();

            var username = "sean";
            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}" +
                $"?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                userWatchlist, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedOption,
                                                                                page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchlistExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/watchlist";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktWatchlistItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserWatchlistArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktWatchlistItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatching

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatching()
        {
            var userWatching = TestUtility.ReadFileContents(@"Objects\Get\Users\Watching\UserWatchingItemMovie.json");
            userWatching.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watching", userWatching);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username).Result;

            response.Should().NotBeNull();
            response.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            response.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            response.Action.Should().Be(TraktHistoryActionType.Checkin);
            response.Type.Should().Be(TraktSyncType.Movie);
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Super 8");
            response.Movie.Year.Should().Be(2011);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(2U);
            response.Movie.Ids.Slug.Should().Be("super-8-2011");
            response.Movie.Ids.Imdb.Should().Be("tt1650062");
            response.Movie.Ids.Tmdb.Should().Be(37686U);
            response.Show.Should().BeNull();
            response.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchingWithOAuthEnforced()
        {
            var userWatching = TestUtility.ReadFileContents(@"Objects\Get\Users\Watching\UserWatchingItemMovie.json");
            userWatching.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/watching", userWatching);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username).Result;

            response.Should().NotBeNull();
            response.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            response.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            response.Action.Should().Be(TraktHistoryActionType.Checkin);
            response.Type.Should().Be(TraktSyncType.Movie);
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Super 8");
            response.Movie.Year.Should().Be(2011);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(2U);
            response.Movie.Ids.Slug.Should().Be("super-8-2011");
            response.Movie.Ids.Imdb.Should().Be("tt1650062");
            response.Movie.Ids.Tmdb.Should().Be(37686U);
            response.Show.Should().BeNull();
            response.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchingComplete()
        {
            var userWatching = TestUtility.ReadFileContents(@"Objects\Get\Users\Watching\UserWatchingItemMovie.json");
            userWatching.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watching?extended={extendedOption.ToString()}", userWatching);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username, extendedOption).Result;

            response.Should().NotBeNull();
            response.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            response.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            response.Action.Should().Be(TraktHistoryActionType.Checkin);
            response.Type.Should().Be(TraktSyncType.Movie);
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Super 8");
            response.Movie.Year.Should().Be(2011);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(2U);
            response.Movie.Ids.Slug.Should().Be("super-8-2011");
            response.Movie.Ids.Imdb.Should().Be("tt1650062");
            response.Movie.Ids.Tmdb.Should().Be(37686U);
            response.Show.Should().BeNull();
            response.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchingExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktUserWatchingItem>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserWatchingArgumentExceptions()
        {
            Func<Task<TraktUserWatchingItem>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchedMovies

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMovies()
        {
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watched/movies", watchedMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMoviesWithOAuthEnforced()
        {
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/watched/movies", watchedMovies);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMoviesComplete()
        {
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watched/movies?extended={extendedOption.ToString()}", watchedMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedMoviesExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/watched/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktWatchedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserWatchedMoviesArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktWatchedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedMoviesAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserWatchedShows

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShows()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watched/shows", watchedShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShowsWithOAuthEnforced()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/watched/shows", watchedShows);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync(username).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShowsComplete()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            var username = "sean";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watched/shows?extended={extendedOption.ToString()}", watchedShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync(username, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserWatchedShowsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/watched/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktWatchedShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserWatchedShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktWatchedShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedShowsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserStatistics

        [TestMethod]
        public void TestTraktUsersModuleGetUserStatistics()
        {
            var userStatistics = TestUtility.ReadFileContents(@"Objects\Get\Users\UserStatistics.json");
            userStatistics.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/stats", userStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(username).Result;

            response.Should().NotBeNull();

            response.Movies.Should().NotBeNull();
            response.Movies.Plays.Should().Be(155);
            response.Movies.Watched.Should().Be(114);
            response.Movies.Minutes.Should().Be(15650);
            response.Movies.Collected.Should().Be(933);
            response.Movies.Ratings.Should().Be(256);
            response.Movies.Comments.Should().Be(28);

            response.Shows.Should().NotBeNull();
            response.Shows.Watched.Should().Be(16);
            response.Shows.Collected.Should().Be(7);
            response.Shows.Ratings.Should().Be(63);
            response.Shows.Comments.Should().Be(20);

            response.Seasons.Should().NotBeNull();
            response.Seasons.Ratings.Should().Be(6);
            response.Seasons.Comments.Should().Be(1);

            response.Episodes.Should().NotBeNull();
            response.Episodes.Plays.Should().Be(552);
            response.Episodes.Watched.Should().Be(534);
            response.Episodes.Minutes.Should().Be(17330);
            response.Episodes.Collected.Should().Be(117);
            response.Episodes.Ratings.Should().Be(64);
            response.Episodes.Comments.Should().Be(14);

            response.Network.Should().NotBeNull();
            response.Network.Friends.Should().Be(1);
            response.Network.Followers.Should().Be(4);
            response.Network.Following.Should().Be(11);

            response.Ratings.Should().NotBeNull();
            response.Ratings.Total.Should().Be(389);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            response.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserStatisticsWithOAuthEnforced()
        {
            var userStatistics = TestUtility.ReadFileContents(@"Objects\Get\Users\UserStatistics.json");
            userStatistics.Should().NotBeNullOrEmpty();

            var username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/stats", userStatistics);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(username).Result;

            response.Should().NotBeNull();

            response.Movies.Should().NotBeNull();
            response.Movies.Plays.Should().Be(155);
            response.Movies.Watched.Should().Be(114);
            response.Movies.Minutes.Should().Be(15650);
            response.Movies.Collected.Should().Be(933);
            response.Movies.Ratings.Should().Be(256);
            response.Movies.Comments.Should().Be(28);

            response.Shows.Should().NotBeNull();
            response.Shows.Watched.Should().Be(16);
            response.Shows.Collected.Should().Be(7);
            response.Shows.Ratings.Should().Be(63);
            response.Shows.Comments.Should().Be(20);

            response.Seasons.Should().NotBeNull();
            response.Seasons.Ratings.Should().Be(6);
            response.Seasons.Comments.Should().Be(1);

            response.Episodes.Should().NotBeNull();
            response.Episodes.Plays.Should().Be(552);
            response.Episodes.Watched.Should().Be(534);
            response.Episodes.Minutes.Should().Be(17330);
            response.Episodes.Collected.Should().Be(117);
            response.Episodes.Ratings.Should().Be(64);
            response.Episodes.Comments.Should().Be(14);

            response.Network.Should().NotBeNull();
            response.Network.Friends.Should().Be(1);
            response.Network.Followers.Should().Be(4);
            response.Network.Following.Should().Be(11);

            response.Ratings.Should().NotBeNull();
            response.Ratings.Total.Should().Be(389);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            response.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserStatisticsExceptions()
        {
            var username = "sean";
            var uri = $"users/{username}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktUserStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(username);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktUsersModuleGetUserStatisticsArgumentExceptions()
        {
            Func<Task<TraktUserStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
