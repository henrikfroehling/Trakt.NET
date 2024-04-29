﻿namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class FavoriteObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().BeNull();
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().BeNull();
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().BeNull();
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().BeNull();
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().BeNull();
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().BeNull();
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().BeNull();
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().BeNull();
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().BeNull();
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().BeNull();
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().BeNull();
            traktFavorite.Show.Should().NotBeNull();
            traktFavorite.Show.Title.Should().Be("The Walking Dead");
            traktFavorite.Show.Year.Should().Be(2010);
            traktFavorite.Show.Ids.Should().NotBeNull();
            traktFavorite.Show.Ids.Trakt.Should().Be(2U);
            traktFavorite.Show.Ids.Slug.Should().Be("the-walking-dead");
            traktFavorite.Show.Ids.Tvdb.Should().Be(153021U);
            traktFavorite.Show.Ids.Imdb.Should().Be("tt1520211");
            traktFavorite.Show.Ids.Tmdb.Should().Be(1402U);
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().Be(102);
            traktFavorite.Rank.Should().Be(1);
            traktFavorite.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktFavorite.Type.Should().Be(TraktFavoriteObjectType.Show);
            traktFavorite.Notes.Should().Be("Atmospheric for days.");
            traktFavorite.Show.Should().BeNull();
            traktFavorite.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_FavoriteObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new FavoriteObjectJsonReader();

            using var reader = new StringReader(JSON_SHOW_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);

            ITraktFavorite traktFavorite = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktFavorite.Should().NotBeNull();
            traktFavorite.Id.Should().BeNull();
            traktFavorite.Rank.Should().BeNull();
            traktFavorite.ListedAt.Should().BeNull();
            traktFavorite.Type.Should().BeNull();
            traktFavorite.Notes.Should().BeNull();
            traktFavorite.Show.Should().BeNull();
            traktFavorite.Movie.Should().BeNull();
        }
    }
}
