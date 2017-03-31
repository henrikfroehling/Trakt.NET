namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Basic")]
    public class TraktMetadataObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMetadataObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMetadataObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktMetadata>));
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_COMPLETE);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_INCOMPLETE_10);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(default(string));
            traktMetadata.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(string.Empty);
            traktMetadata.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktMetadataObjectJsonReader();

            var traktMetadata = jsonReader.ReadObject(default(JsonTextReader));
            traktMetadata.Should().BeNull();
        }

        [Fact]
        public void Test_TraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktMetadataObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = traktJsonReader.ReadObject(jsonReader);
                traktMetadata.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""media_type"": ""digital"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""3d"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""media_type"": ""digital""
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""resolution"": ""hd_720p""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""audio"": ""aac""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""audio_channels"": ""5.1""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""mt"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""media_type"": ""digital"",
                ""res"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""aud"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""ac"": ""5.1"",
                ""3d"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""d"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""mt"": ""digital"",
                ""res"": ""hd_720p"",
                ""aud"": ""aac"",
                ""ac"": ""5.1"",
                ""d"": true
              }";
    }
}
