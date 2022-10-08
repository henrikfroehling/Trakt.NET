namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_ITraktShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(8);

            ITraktSyncCollectionPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncCollectionPostShowEpisode[] episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[5].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[5].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[5].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[5].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[5].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[7].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[7].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[7].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[7].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[7].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[7].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_ITraktShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(8);

            ITraktSyncCollectionPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncCollectionPostShowEpisode[] episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[5].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[5].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[5].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[5].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[5].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[7].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[7].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[7].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[7].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[7].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[7].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_CollectionShowAndSeasons()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(new CollectionShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(8);

            ITraktSyncCollectionPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncCollectionPostShowEpisode[] episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[5].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[5].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[5].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[5].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[5].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[7].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[7].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[7].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[7].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[7].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[7].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_CollectionShowIdsAndSeasons()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(new CollectionShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(8);

            ITraktSyncCollectionPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncCollectionPostShowEpisode[] episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[5].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[5].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[5].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[5].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[5].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[7].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[7].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[7].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[7].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[7].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[7].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndSeasons_CollectionShowAndSeasons()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsAndSeasons(new List<CollectionShowAndSeasons>
                {
                    new CollectionShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1),
                    new CollectionShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_2)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title = TraktPost_Tests_Common_Data.SHOW_1.Title;
            postShow1.Year = TraktPost_Tests_Common_Data.SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.CollectedAt.Should().BeNull();
            postShow1.Audio.Should().BeNull();
            postShow1.AudioChannels.Should().BeNull();
            postShow1.MediaType.Should().BeNull();
            postShow1.MediaResolution.Should().BeNull();
            postShow1.HDR.Should().BeNull();
            postShow1.ThreeDimensional.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(8);

            ITraktSyncCollectionPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncCollectionPostShowEpisode[] episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[5].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[5].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[5].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[5].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[5].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[7].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[7].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[7].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[7].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[7].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[7].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title = TraktPost_Tests_Common_Data.SHOW_2.Title;
            postShow2.Year = TraktPost_Tests_Common_Data.SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.CollectedAt.Should().BeNull();
            postShow2.Audio.Should().BeNull();
            postShow2.AudioChannels.Should().BeNull();
            postShow2.MediaType.Should().BeNull();
            postShow2.MediaResolution.Should().BeNull();
            postShow2.HDR.Should().BeNull();
            postShow2.ThreeDimensional.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(8);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().BeNull();
            postShowSeasons[1].AudioChannels.Should().BeNull();
            postShowSeasons[1].MediaType.Should().BeNull();
            postShowSeasons[1].MediaResolution.Should().BeNull();
            postShowSeasons[1].HDR.Should().BeNull();
            postShowSeasons[1].ThreeDimensional.Should().BeNull();
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().BeNull();
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().BeNull();
            postShowSeasons[3].Audio.Should().BeNull();
            postShowSeasons[3].AudioChannels.Should().BeNull();
            postShowSeasons[3].MediaType.Should().BeNull();
            postShowSeasons[3].MediaResolution.Should().BeNull();
            postShowSeasons[3].HDR.Should().BeNull();
            postShowSeasons[3].ThreeDimensional.Should().BeNull();
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().BeNull();
            episodes[1].AudioChannels.Should().BeNull();
            episodes[1].MediaType.Should().BeNull();
            episodes[1].MediaResolution.Should().BeNull();
            episodes[1].HDR.Should().BeNull();
            episodes[1].ThreeDimensional.Should().BeNull();

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().BeNull();
            postShowSeasons[5].AudioChannels.Should().BeNull();
            postShowSeasons[5].MediaType.Should().BeNull();
            postShowSeasons[5].MediaResolution.Should().BeNull();
            postShowSeasons[5].HDR.Should().BeNull();
            postShowSeasons[5].ThreeDimensional.Should().BeNull();
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().BeNull();
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().BeNull();
            episodes[1].AudioChannels.Should().BeNull();
            episodes[1].MediaType.Should().BeNull();
            episodes[1].MediaResolution.Should().BeNull();
            episodes[1].HDR.Should().BeNull();
            episodes[1].ThreeDimensional.Should().BeNull();

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().BeNull();
            postShowSeasons[7].Audio.Should().BeNull();
            postShowSeasons[7].AudioChannels.Should().BeNull();
            postShowSeasons[7].MediaType.Should().BeNull();
            postShowSeasons[7].MediaResolution.Should().BeNull();
            postShowSeasons[7].HDR.Should().BeNull();
            postShowSeasons[7].ThreeDimensional.Should().BeNull();
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndSeasons_CollectionShowIdsAndSeasons()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsAndSeasons(new List<CollectionShowIdsAndSeasons>
                {
                    new CollectionShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1),
                    new CollectionShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_2)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.CollectedAt.Should().BeNull();
            postShow1.Audio.Should().BeNull();
            postShow1.AudioChannels.Should().BeNull();
            postShow1.MediaType.Should().BeNull();
            postShow1.MediaResolution.Should().BeNull();
            postShow1.HDR.Should().BeNull();
            postShow1.ThreeDimensional.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(8);

            ITraktSyncCollectionPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncCollectionPostShowEpisode[] episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[5].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[5].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[5].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[5].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[5].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postShowSeasons[7].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postShowSeasons[7].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postShowSeasons[7].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postShowSeasons[7].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postShowSeasons[7].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postShowSeasons[7].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(4);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[1].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[1].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[1].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[1].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[1].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            episodes[2].Number.Should().Be(3);
            episodes[2].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[2].Audio.Should().BeNull();
            episodes[2].AudioChannels.Should().BeNull();
            episodes[2].MediaType.Should().BeNull();
            episodes[2].MediaResolution.Should().BeNull();
            episodes[2].HDR.Should().BeNull();
            episodes[2].ThreeDimensional.Should().BeNull();

            episodes[3].Number.Should().Be(4);
            episodes[3].CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            episodes[3].Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            episodes[3].AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            episodes[3].MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            episodes[3].MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            episodes[3].HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            episodes[3].ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.CollectedAt.Should().BeNull();
            postShow2.Audio.Should().BeNull();
            postShow2.AudioChannels.Should().BeNull();
            postShow2.MediaType.Should().BeNull();
            postShow2.MediaResolution.Should().BeNull();
            postShow2.HDR.Should().BeNull();
            postShow2.ThreeDimensional.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(8);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].CollectedAt.Should().BeNull();
            postShowSeasons[0].Audio.Should().BeNull();
            postShowSeasons[0].AudioChannels.Should().BeNull();
            postShowSeasons[0].MediaType.Should().BeNull();
            postShowSeasons[0].MediaResolution.Should().BeNull();
            postShowSeasons[0].HDR.Should().BeNull();
            postShowSeasons[0].ThreeDimensional.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].CollectedAt.Should().BeNull();
            postShowSeasons[1].Audio.Should().BeNull();
            postShowSeasons[1].AudioChannels.Should().BeNull();
            postShowSeasons[1].MediaType.Should().BeNull();
            postShowSeasons[1].MediaResolution.Should().BeNull();
            postShowSeasons[1].HDR.Should().BeNull();
            postShowSeasons[1].ThreeDimensional.Should().BeNull();
            postShowSeasons[1].Episodes.Should().BeNull();

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].CollectedAt.Should().BeNull();
            postShowSeasons[2].Audio.Should().BeNull();
            postShowSeasons[2].AudioChannels.Should().BeNull();
            postShowSeasons[2].MediaType.Should().BeNull();
            postShowSeasons[2].MediaResolution.Should().BeNull();
            postShowSeasons[2].HDR.Should().BeNull();
            postShowSeasons[2].ThreeDimensional.Should().BeNull();
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].CollectedAt.Should().BeNull();
            postShowSeasons[3].Audio.Should().BeNull();
            postShowSeasons[3].AudioChannels.Should().BeNull();
            postShowSeasons[3].MediaType.Should().BeNull();
            postShowSeasons[3].MediaResolution.Should().BeNull();
            postShowSeasons[3].HDR.Should().BeNull();
            postShowSeasons[3].ThreeDimensional.Should().BeNull();
            postShowSeasons[3].Episodes.Should().BeNull();

            postShowSeasons[4].Number.Should().Be(5);
            postShowSeasons[4].CollectedAt.Should().BeNull();
            postShowSeasons[4].Audio.Should().BeNull();
            postShowSeasons[4].AudioChannels.Should().BeNull();
            postShowSeasons[4].MediaType.Should().BeNull();
            postShowSeasons[4].MediaResolution.Should().BeNull();
            postShowSeasons[4].HDR.Should().BeNull();
            postShowSeasons[4].ThreeDimensional.Should().BeNull();
            postShowSeasons[4].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[4].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().BeNull();
            episodes[1].AudioChannels.Should().BeNull();
            episodes[1].MediaType.Should().BeNull();
            episodes[1].MediaResolution.Should().BeNull();
            episodes[1].HDR.Should().BeNull();
            episodes[1].ThreeDimensional.Should().BeNull();

            postShowSeasons[5].Number.Should().Be(6);
            postShowSeasons[5].CollectedAt.Should().BeNull();
            postShowSeasons[5].Audio.Should().BeNull();
            postShowSeasons[5].AudioChannels.Should().BeNull();
            postShowSeasons[5].MediaType.Should().BeNull();
            postShowSeasons[5].MediaResolution.Should().BeNull();
            postShowSeasons[5].HDR.Should().BeNull();
            postShowSeasons[5].ThreeDimensional.Should().BeNull();
            postShowSeasons[5].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[5].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            postShowSeasons[6].Number.Should().Be(7);
            postShowSeasons[6].CollectedAt.Should().BeNull();
            postShowSeasons[6].Audio.Should().BeNull();
            postShowSeasons[6].AudioChannels.Should().BeNull();
            postShowSeasons[6].MediaType.Should().BeNull();
            postShowSeasons[6].MediaResolution.Should().BeNull();
            postShowSeasons[6].HDR.Should().BeNull();
            postShowSeasons[6].ThreeDimensional.Should().BeNull();
            postShowSeasons[6].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[6].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].CollectedAt.Should().BeNull();
            episodes[1].Audio.Should().BeNull();
            episodes[1].AudioChannels.Should().BeNull();
            episodes[1].MediaType.Should().BeNull();
            episodes[1].MediaResolution.Should().BeNull();
            episodes[1].HDR.Should().BeNull();
            episodes[1].ThreeDimensional.Should().BeNull();

            postShowSeasons[7].Number.Should().Be(8);
            postShowSeasons[7].CollectedAt.Should().BeNull();
            postShowSeasons[7].Audio.Should().BeNull();
            postShowSeasons[7].AudioChannels.Should().BeNull();
            postShowSeasons[7].MediaType.Should().BeNull();
            postShowSeasons[7].MediaResolution.Should().BeNull();
            postShowSeasons[7].HDR.Should().BeNull();
            postShowSeasons[7].ThreeDimensional.Should().BeNull();
            postShowSeasons[7].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[7].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].CollectedAt.Should().BeNull();
            episodes[0].Audio.Should().BeNull();
            episodes[0].AudioChannels.Should().BeNull();
            episodes[0].MediaType.Should().BeNull();
            episodes[0].MediaResolution.Should().BeNull();
            episodes[0].HDR.Should().BeNull();
            episodes[0].ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }
    }
}
