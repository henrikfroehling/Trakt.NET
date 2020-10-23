namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Enums;
    using Get.Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncCollectionPostEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostEpisode>
    {
        public override async Task<ITraktSyncCollectionPostEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCollectionPostEpisode traktSyncCollectionPostEpisode = new TraktSyncCollectionPostEpisode();
                var episodeIdsObjectJsonReader = new EpisodeIdsObjectJsonReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COLLECTED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostEpisode.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_IDS:
                            traktSyncCollectionPostEpisode.Ids = await episodeIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MEDIA_TYPE:
                            traktSyncCollectionPostEpisode.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RESOLUTION:
                            traktSyncCollectionPostEpisode.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AUDIO:
                            traktSyncCollectionPostEpisode.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AUDIO_CHANNELS:
                            traktSyncCollectionPostEpisode.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_3D:
                            traktSyncCollectionPostEpisode.ThreeDimensional = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPostEpisode;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostEpisode));
        }
    }
}
