namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        public void Test_IdsArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
            IEnumerable<ITraktIds> traktIds = new List<TraktIds>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktIds);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_IdsArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktIds> traktIds = new List<TraktIds>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"[{""trakt"":1231,""slug"":""ids slug 1"",""tvdb"":4561," +
                                                    @"""imdb"":""ids imdb 1"",""tmdb"":7891,""tvrage"":1011}]");
            }
        }

        [Fact]
        public async Task Test_IdsArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktIds>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"[{""trakt"":1231,""slug"":""ids slug 1"",""tvdb"":4561," +
                                                    @"""imdb"":""ids imdb 1"",""tmdb"":7891,""tvrage"":1011}," +
                                                    @"{""trakt"":1232,""slug"":""ids slug 2"",""tvdb"":4562," +
                                                    @"""imdb"":""ids imdb 2"",""tmdb"":7892,""tvrage"":1012}]");
            }
        }
    }
}
