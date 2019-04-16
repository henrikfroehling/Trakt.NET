﻿namespace TraktNet.Objects.Tests.Get.People.Credits.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            movieCreditsCastItem.Should().NotBeNull();
            movieCreditsCastItem.Character.Should().Be("Joe Brody");
            movieCreditsCastItem.Movie.Should().NotBeNull();
            movieCreditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieCreditsCastItem.Movie.Year.Should().Be(2015);
            movieCreditsCastItem.Movie.Ids.Should().NotBeNull();
            movieCreditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
            movieCreditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieCreditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieCreditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            movieCreditsCastItem.Should().NotBeNull();
            movieCreditsCastItem.Character.Should().BeNull();
            movieCreditsCastItem.Movie.Should().NotBeNull();
            movieCreditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieCreditsCastItem.Movie.Year.Should().Be(2015);
            movieCreditsCastItem.Movie.Ids.Should().NotBeNull();
            movieCreditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
            movieCreditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieCreditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieCreditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            movieCreditsCastItem.Should().NotBeNull();
            movieCreditsCastItem.Character.Should().Be("Joe Brody");
            movieCreditsCastItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            movieCreditsCastItem.Should().NotBeNull();
            movieCreditsCastItem.Character.Should().BeNull();
            movieCreditsCastItem.Movie.Should().NotBeNull();
            movieCreditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieCreditsCastItem.Movie.Year.Should().Be(2015);
            movieCreditsCastItem.Movie.Ids.Should().NotBeNull();
            movieCreditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
            movieCreditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieCreditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieCreditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            movieCreditsCastItem.Should().NotBeNull();
            movieCreditsCastItem.Character.Should().Be("Joe Brody");
            movieCreditsCastItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            movieCreditsCastItem.Should().NotBeNull();
            movieCreditsCastItem.Character.Should().BeNull();
            movieCreditsCastItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(default(string));
            movieCreditsCastItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(string.Empty);
            movieCreditsCastItem.Should().BeNull();
        }
    }
}
