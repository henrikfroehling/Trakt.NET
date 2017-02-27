namespace TraktApiSharp.Tests.Objects.JsonReader.Basic
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Basic;
    using Xunit;

    [Category("Objects.JsonReader.Basic")]
    public class TraktStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktStatisticsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktStatistics>));
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_COMPLETE);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_10);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_11);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_12);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_13);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_INCOMPLETE_14);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().Be(9274);
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_7);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().Be(129920);
            traktStatistics.Plays.Should().Be(3563853);
            traktStatistics.Collectors.Should().Be(49711);
            traktStatistics.CollectedEpisodes.Should().Be(1310350);
            traktStatistics.Comments.Should().Be(96);
            traktStatistics.Lists.Should().Be(49468);
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(JSON_NOT_VALID_8);

            traktStatistics.Should().NotBeNull();
            traktStatistics.Watchers.Should().BeNull();
            traktStatistics.Plays.Should().BeNull();
            traktStatistics.Collectors.Should().BeNull();
            traktStatistics.CollectedEpisodes.Should().BeNull();
            traktStatistics.Comments.Should().BeNull();
            traktStatistics.Lists.Should().BeNull();
            traktStatistics.Votes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(default(string));
            traktStatistics.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(string.Empty);
            traktStatistics.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().Be(9274);
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().Be(129920);
                traktStatistics.Plays.Should().Be(3563853);
                traktStatistics.Collectors.Should().Be(49711);
                traktStatistics.CollectedEpisodes.Should().Be(1310350);
                traktStatistics.Comments.Should().Be(96);
                traktStatistics.Lists.Should().Be(49468);
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);

                traktStatistics.Should().NotBeNull();
                traktStatistics.Watchers.Should().BeNull();
                traktStatistics.Plays.Should().BeNull();
                traktStatistics.Collectors.Should().BeNull();
                traktStatistics.CollectedEpisodes.Should().BeNull();
                traktStatistics.Comments.Should().BeNull();
                traktStatistics.Lists.Should().BeNull();
                traktStatistics.Votes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktStatisticsObjectJsonReader();

            var traktStatistics = jsonReader.ReadObject(default(JsonTextReader));
            traktStatistics.Should().BeNull();
        }

        [Fact]
        public void Test_TraktStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStatistics = traktJsonReader.ReadObject(jsonReader);
                traktStatistics.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watchers"": 129920,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""votes"": 9274
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""watchers"": 129920
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""plays"": 3563853
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""collectors"": 49711
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""collected_episodes"": 1310350
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""comments"": 96
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""lists"": 49468
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wa"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watchers"": 129920,
                ""pl"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""col"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""colep"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""cm"": 96,
                ""lists"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""li"": 49468,
                ""votes"": 9274
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""watchers"": 129920,
                ""plays"": 3563853,
                ""collectors"": 49711,
                ""collected_episodes"": 1310350,
                ""comments"": 96,
                ""lists"": 49468,
                ""vo"": 9274
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""wa"": 129920,
                ""pl"": 3563853,
                ""col"": 49711,
                ""colep"": 1310350,
                ""cm"": 96,
                ""li"": 49468,
                ""vo"": 9274
              }";
    }
}
