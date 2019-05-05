namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class IdsArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_IdsArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
            IEnumerable<ITraktIds> traktIds = new List<TraktIds>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktIds);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_IdsArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktIds> traktIds = new List<TraktIds>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktIds);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktIds> traktIds = new List<ITraktIds>
            {
                new TraktIds
                {
                    Trakt = 1231,
                    Slug = "ids slug 1",
                    Tvdb = 4561,
                    Imdb = "ids imdb 1",
                    Tmdb = 7891,
                    TvRage = 1011
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktIds);
                json.Should().Be(@"[{""trakt"":1231,""slug"":""ids slug 1"",""tvdb"":4561," +
                                 @"""imdb"":""ids imdb 1"",""tmdb"":7891,""tvrage"":1011}]");
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktIds> traktIds = new List<ITraktIds>
            {
                new TraktIds
                {
                    Trakt = 1231,
                    Slug = "ids slug 1",
                    Tvdb = 4561,
                    Imdb = "ids imdb 1",
                    Tmdb = 7891,
                    TvRage = 1011
                },
                new TraktIds
                {
                    Trakt = 1232,
                    Slug = "ids slug 2",
                    Tvdb = 4562,
                    Imdb = "ids imdb 2",
                    Tmdb = 7892,
                    TvRage = 1012
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktIds);
                json.Should().Be(@"[{""trakt"":1231,""slug"":""ids slug 1"",""tvdb"":4561," +
                                 @"""imdb"":""ids imdb 1"",""tmdb"":7891,""tvrage"":1011}," +
                                 @"{""trakt"":1232,""slug"":""ids slug 2"",""tvdb"":4562," +
                                 @"""imdb"":""ids imdb 2"",""tmdb"":7892,""tvrage"":1012}]");
            }
        }
    }
}
