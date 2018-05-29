namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string UPDATE_CUSTOM_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}";

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description_And_Privacy()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION, NEW_PRIVACY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description_And_Privacy_And_DisplayNumbers()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY,
                DisplayNumbers = NEW_DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION,
                                                         NEW_PRIVACY, NEW_DISPLAY_NUMBERS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description_And_Privacy_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION, NEW_PRIVACY,
                                                         null, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description_And_DisplayNumbers()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                DisplayNumbers = NEW_DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION,
                                                         null, NEW_DISPLAY_NUMBERS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION,
                                                         null, null, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Name_And_Description_And_DisplayNumbers_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                DisplayNumbers = NEW_DISPLAY_NUMBERS,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION, null,
                                                         NEW_DISPLAY_NUMBERS, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description_And_Privacy()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION, NEW_PRIVACY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description_And_Privacy_And_DisplayNumbers()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY,
                DisplayNumbers = NEW_DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION,
                                                         NEW_PRIVACY, NEW_DISPLAY_NUMBERS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description_And_Privacy_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION,
                                                         NEW_PRIVACY, null, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description_And_DisplayNumbers()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION,
                DisplayNumbers = NEW_DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION,
                                                         null, NEW_DISPLAY_NUMBERS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION,
                                                         null, null, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Description_And_DisplayNumbers_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Description = NEW_DESCRIPTION,
                DisplayNumbers = NEW_DISPLAY_NUMBERS,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, NEW_DESCRIPTION, null,
                                                         NEW_DISPLAY_NUMBERS, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Privacy()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Privacy = NEW_PRIVACY
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, NEW_PRIVACY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Privacy_And_DisplayNumbers()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Privacy = NEW_PRIVACY,
                DisplayNumbers = NEW_DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null,
                                                         NEW_PRIVACY, NEW_DISPLAY_NUMBERS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Privacy_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Privacy = NEW_PRIVACY,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, NEW_PRIVACY,
                                                         null, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_Privacy_And_DisplayNumbers_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Privacy = NEW_PRIVACY,
                DisplayNumbers = NEW_DISPLAY_NUMBERS,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, NEW_PRIVACY,
                                                         NEW_DISPLAY_NUMBERS, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_DisplayNumbers()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                DisplayNumbers = NEW_DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, null, NEW_DISPLAY_NUMBERS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, null,
                                                         null, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_With_DisplayNumbers_And_AllowComments()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                DisplayNumbers = NEW_DISPLAY_NUMBERS,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, null,
                                                         NEW_DISPLAY_NUMBERS, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_Complete()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME,
                Description = NEW_DESCRIPTION,
                Privacy = NEW_PRIVACY,
                DisplayNumbers = NEW_DISPLAY_NUMBERS,
                AllowComments = NEW_ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME, NEW_DESCRIPTION,
                                                         NEW_PRIVACY, NEW_DISPLAY_NUMBERS, NEW_ALLOW_COMMENTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktList responseValue = response.Value;

            responseValue.Name.Should().Be("Star Wars in machete order");
            responseValue.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            responseValue.Privacy.Should().Be(TraktAccessScope.Public);
            responseValue.DisplayNumbers.Should().BeTrue();
            responseValue.AllowComments.Should().BeFalse();
            responseValue.SortBy.Should().Be("rank");
            responseValue.SortHow.Should().Be("asc");
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            responseValue.ItemCount.Should().Be(5);
            responseValue.CommentCount.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(55);
            responseValue.Ids.Slug.Should().Be("star-wars-in-machete-order");
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_UpdateCustomList_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktUsersModule_UpdateCustomList_ArgumentExceptions()
        {
            ITraktUserCustomListPost createListPost = new TraktUserCustomListPost
            {
                Name = NEW_LIST_NAME
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.UpdateCustomListAsync(null, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.UpdateCustomListAsync(string.Empty, LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UpdateCustomListAsync("user name", LIST_ID, NEW_LIST_NAME);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, null, NEW_LIST_NAME);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, string.Empty, NEW_LIST_NAME);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, "list id", NEW_LIST_NAME);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, string.Empty);
            act.Should().Throw<ArgumentException>();

            string description = string.Empty;

            createListPost = new TraktUserCustomListPost
            {
                Description = description
            };

            postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            client = TestUtility.GetOAuthMockClient(UPDATE_CUSTOM_LIST_URI, postJson, LIST_JSON);

            act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, description);
            act.Should().NotThrow();

            act = () => client.Users.UpdateCustomListAsync(USERNAME, LIST_ID, null, null, TraktAccessScope.Unspecified);
            act.Should().Throw<ArgumentException>();
        }
    }
}
