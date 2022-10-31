namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPerson_ITraktPerson_ArgumentExceptions()
        {
            ITraktPerson person = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPerson(person)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPerson_ITraktPersonIds_ArgumentExceptions()
        {
            ITraktPersonIds personIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPerson(personIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_ITraktPerson_ArgumentExceptions()
        {
            ITraktPerson person = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(person, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_ITraktPersonIds_ArgumentExceptions()
        {
            ITraktPersonIds personIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_PersonWithNotes_ArgumentExceptions()
        {
            PersonWithNotes personWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personWithNotes = new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personWithNotes = new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonWithNotes_PersonIdsWithNotes_ArgumentExceptions()
        {
            PersonIdsWithNotes personIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personIdsWithNotes = new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personIdsWithNotes = new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonWithNotes(personIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersons_ITraktPerson_ArgumentExceptions()
        {
            List<ITraktPerson> persons = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersons(persons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersons_ITraktPersonIds_ArgumentExceptions()
        {
            List<ITraktPersonIds> personIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersons(personIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonsWithNotes_PersonWithNotes_ArgumentExceptions()
        {
            List<PersonWithNotes> personsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(personsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personsWithNotes = new List<PersonWithNotes>
            {
                new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, TraktPost_Tests_Common_Data.NOTES),
                new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(personsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personsWithNotes = new List<PersonWithNotes>
            {
                new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_1, TraktPost_Tests_Common_Data.NOTES),
                new PersonWithNotes(TraktPost_Tests_Common_Data.PERSON_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(personsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersonsWithNotes_PersonIdsWithNotes_ArgumentExceptions()
        {
            List<PersonIdsWithNotes> personIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(personIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personIdsWithNotes = new List<PersonIdsWithNotes>
            {
                new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(personIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            personIdsWithNotes = new List<PersonIdsWithNotes>
            {
                new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new PersonIdsWithNotes(TraktPost_Tests_Common_Data.PERSON_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithPersonsWithNotes(personIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
