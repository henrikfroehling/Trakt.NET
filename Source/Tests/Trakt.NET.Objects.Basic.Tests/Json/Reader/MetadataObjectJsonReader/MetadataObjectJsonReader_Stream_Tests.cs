﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class MetadataObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MetadataObjectJsonReader();
            Func<Task<ITraktMetadata>> traktMetadata = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktMetadata.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(stream);
                traktMetadata.Should().BeNull();
            }
        }
    }
}
