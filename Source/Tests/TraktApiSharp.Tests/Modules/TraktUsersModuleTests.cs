namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Modules;
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetSettingsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserFollowRequests

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowRequests()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserFollowRequestsExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserHiddenItems

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithExtendedOptionAndPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserHiddenItemsWithTypeAndPageExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserLikes

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikes()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserLikesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserProfile

        [TestMethod]
        public void TestTraktUsersModuleGetUserProfile()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserProfileExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserProfileArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserCollectionMovies

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktUsersModuleGetUserCollectionMoviesArgumentExceptions()
        {
            Assert.Fail();
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
