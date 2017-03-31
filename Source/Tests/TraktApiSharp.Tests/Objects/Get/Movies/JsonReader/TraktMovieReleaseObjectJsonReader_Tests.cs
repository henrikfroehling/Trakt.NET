namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Movies")]
    public class TraktMovieReleaseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMovieReleaseObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktMovieRelease>));
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_COMPLETE);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_INCOMPLETE_10);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().Be("Los Angeles, California");
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().Be("us");
            traktMovieRelease.Certification.Should().Be("PG-13");
            traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktMovieRelease.Should().NotBeNull();
            traktMovieRelease.CountryCode.Should().BeNull();
            traktMovieRelease.Certification.Should().BeNull();
            traktMovieRelease.ReleaseDate.Should().BeNull();
            traktMovieRelease.ReleaseType.Should().BeNull();
            traktMovieRelease.Note.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(default(string));
            traktMovieRelease.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(string.Empty);
            traktMovieRelease.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().Be("Los Angeles, California");
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().Be("us");
                traktMovieRelease.Certification.Should().Be("PG-13");
                traktMovieRelease.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
                traktMovieRelease.ReleaseType.Should().Be(TraktReleaseType.Premiere);
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);

                traktMovieRelease.Should().NotBeNull();
                traktMovieRelease.CountryCode.Should().BeNull();
                traktMovieRelease.Certification.Should().BeNull();
                traktMovieRelease.ReleaseDate.Should().BeNull();
                traktMovieRelease.ReleaseType.Should().BeNull();
                traktMovieRelease.Note.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktMovieReleaseObjectJsonReader();

            var traktMovieRelease = jsonReader.ReadObject(default(JsonTextReader));
            traktMovieRelease.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMovieReleaseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktMovieReleaseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieRelease = traktJsonReader.ReadObject(jsonReader);
                traktMovieRelease.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""us"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""certification"": ""PG-13""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""release_date"": ""2015-12-14""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""release_type"": ""premiere""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""co"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""country"": ""us"",
                ""cert"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""rd"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""rt"": ""premiere"",
                ""note"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""country"": ""us"",
                ""certification"": ""PG-13"",
                ""release_date"": ""2015-12-14"",
                ""release_type"": ""premiere"",
                ""no"": ""Los Angeles, California""
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""co"": ""us"",
                ""cert"": ""PG-13"",
                ""rd"": ""2015-12-14"",
                ""rt"": ""premiere"",
                ""no"": ""Los Angeles, California""
              }";
    }
}
