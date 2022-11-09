namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPerson_ITraktPerson()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPerson(TraktPost_Tests_Common_Data.PERSON_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPerson_ITraktPersonIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPerson(TraktPost_Tests_Common_Data.PERSON_IDS_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_ITraktPerson()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_ITraktPersonIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_PersonWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_PersonIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersons_ITraktPerson()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersons(TraktPost_Tests_Common_Data.PERSONS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostPerson postPerson1 = userPersonalListItemsPost.People.ToArray()[0];
            postPerson1.Ids.Should().NotBeNull();
            postPerson1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostPerson postPerson2 = userPersonalListItemsPost.People.ToArray()[1];
            postPerson2.Ids.Should().NotBeNull();
            postPerson2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Trakt);
            postPerson2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Imdb);
            postPerson2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.TvRage);
            postPerson2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Tmdb);
            postPerson2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersons_ITraktPersonIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersons(TraktPost_Tests_Common_Data.PERSON_IDS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostPerson postPerson1 = userPersonalListItemsPost.People.ToArray()[0];
            postPerson1.Ids.Should().NotBeNull();
            postPerson1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostPerson postPerson2 = userPersonalListItemsPost.People.ToArray()[1];
            postPerson2.Ids.Should().NotBeNull();
            postPerson2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Trakt);
            postPerson2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Imdb);
            postPerson2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.TvRage);
            postPerson2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Tmdb);
            postPerson2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonsWithNotes_PersonWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(new List<PersonWithNotes>
                {
                    new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, TraktPost_Tests_Common_Data.NOTES),
                    new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostPerson postPerson1 = userPersonalListItemsPost.People.ToArray()[0];
            postPerson1.Ids.Should().NotBeNull();
            postPerson1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Trakt);
            postPerson1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Imdb);
            postPerson1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.TvRage);
            postPerson1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_1.Ids.Tmdb);
            postPerson1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostPerson postPerson2 = userPersonalListItemsPost.People.ToArray()[1];
            postPerson2.Ids.Should().NotBeNull();
            postPerson2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Trakt);
            postPerson2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Imdb);
            postPerson2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.TvRage);
            postPerson2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_2.Ids.Tmdb);
            postPerson2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonsWithNotes_PersonIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(new List<PersonIdsWithNotes>
                {
                    new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostPerson postPerson1 = userPersonalListItemsPost.People.ToArray()[0];
            postPerson1.Ids.Should().NotBeNull();
            postPerson1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Trakt);
            postPerson1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Imdb);
            postPerson1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.TvRage);
            postPerson1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_1.Tmdb);
            postPerson1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostPerson postPerson2 = userPersonalListItemsPost.People.ToArray()[1];
            postPerson2.Ids.Should().NotBeNull();
            postPerson2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Trakt);
            postPerson2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Imdb);
            postPerson2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.TvRage);
            postPerson2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.PERSON_IDS_2.Tmdb);
            postPerson2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
        }
    }
}
