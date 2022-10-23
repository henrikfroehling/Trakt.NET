namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithPerson_ITraktPerson()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithPerson(TraktPost_Tests_Common_Data.PERSON_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsRemovePost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithPerson_ITraktPersonIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithPerson(TraktPost_Tests_Common_Data.PERSON_IDS_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsRemovePost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithPersons_ITraktPerson()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithPersons(TraktPost_Tests_Common_Data.PERSONS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostPerson postPerson1 = userPersonalListItemsRemovePost.People.ToArray()[0];
            postPerson1.Ids.Should().NotBeNull();
            postPerson1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostPerson postPerson2 = userPersonalListItemsRemovePost.People.ToArray()[1];
            postPerson2.Ids.Should().NotBeNull();
            postPerson2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Trakt);
            postPerson2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Imdb);
            postPerson2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.TvRage);
            postPerson2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Tmdb);
            postPerson2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithPersons_ITraktPersonIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithPersons(TraktPost_Tests_Common_Data.PERSON_IDS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostPerson postPerson1 = userPersonalListItemsRemovePost.People.ToArray()[0];
            postPerson1.Ids.Should().NotBeNull();
            postPerson1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostPerson postPerson2 = userPersonalListItemsRemovePost.People.ToArray()[1];
            postPerson2.Ids.Should().NotBeNull();
            postPerson2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Trakt);
            postPerson2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Imdb);
            postPerson2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.TvRage);
            postPerson2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Tmdb);
            postPerson2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
        }
    }
}
