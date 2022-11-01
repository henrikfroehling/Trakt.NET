namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string CREATE_PERSONAL_LIST_URI = $"users/{USERNAME}/lists";

        [Fact]
        public async Task Test_TraktUsersModule_CreatePersonalList()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);
            TraktResponse<ITraktList> response = await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description_And_Privacy()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                Privacy = PRIVACY
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, PRIVACY);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description_And_Privacy_And_DisplayNumbers()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                Privacy = PRIVACY,
                DisplayNumbers = DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, PRIVACY, DISPLAY_NUMBERS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description_And_Privacy_And_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                Privacy = PRIVACY,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, PRIVACY,
                                                         null, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description_And_DisplayNumbers()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                DisplayNumbers = DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, null, DISPLAY_NUMBERS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description_And_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, null,
                                                         null, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Description_And_DisplayNumbers_And_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                DisplayNumbers = DISPLAY_NUMBERS,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, null,
                                                         DISPLAY_NUMBERS, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Privacy()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Privacy = PRIVACY
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, PRIVACY);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Privacy_And_DisplayNumbers()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Privacy = PRIVACY,
                DisplayNumbers = DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, PRIVACY, DISPLAY_NUMBERS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Privacy_And_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Privacy = PRIVACY,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, PRIVACY, null, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_Privacy_And_DisplayNumbers_And_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Privacy = PRIVACY,
                DisplayNumbers = DISPLAY_NUMBERS,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, PRIVACY,
                                                         DISPLAY_NUMBERS, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_DisplayNumbers()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                DisplayNumbers = DISPLAY_NUMBERS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, null, DISPLAY_NUMBERS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, null, null, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_With_DisplayNumbers_And_AllowComments()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                DisplayNumbers = DISPLAY_NUMBERS,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, null, null,
                                                         DISPLAY_NUMBERS, ALLOW_COMMENTS);

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
        public async Task Test_TraktUsersModule_CreatePersonalList_Complete()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME,
                Description = DESCRIPTION,
                Privacy = PRIVACY,
                DisplayNumbers = DISPLAY_NUMBERS,
                AllowComments = ALLOW_COMMENTS
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            TraktResponse<ITraktList> response =
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME, DESCRIPTION, PRIVACY,
                                                         DISPLAY_NUMBERS, ALLOW_COMMENTS);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktUsersModule_CreatePersonalList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, statusCode);

            try
            {
                await client.Users.CreatePersonalListAsync(USERNAME, LIST_NAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_CreatePersonalList_Exceptions()
        {
            ITraktUserPersonalListPost createListPost = new TraktUserPersonalListPost
            {
                Name = LIST_NAME
            };

            string postJson = await TestUtility.SerializeObject(createListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(CREATE_PERSONAL_LIST_URI, postJson, LIST_JSON);

            Func<Task<TraktResponse<ITraktList>>> act = () => client.Users.CreatePersonalListAsync(null, LIST_NAME);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreatePersonalListAsync(string.Empty, LIST_NAME);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreatePersonalListAsync("user name", LIST_NAME);
            await act.Should().ThrowAsync<TraktRequestValidationException>();

            act = () => client.Users.CreatePersonalListAsync(USERNAME, null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.CreatePersonalListAsync(USERNAME, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
