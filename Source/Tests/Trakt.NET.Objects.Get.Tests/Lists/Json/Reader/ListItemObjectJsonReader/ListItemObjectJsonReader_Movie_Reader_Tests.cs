﻿namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Movie_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().NotBeNull();
            traktListItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktListItem.Movie.Year.Should().Be(2015);
            traktListItem.Movie.Ids.Should().NotBeNull();
            traktListItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktListItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktListItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktListItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Movie);
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Movie_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_MOVIE_JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Movie.Should().BeNull();

            traktListItem.Show.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }
    }
}
