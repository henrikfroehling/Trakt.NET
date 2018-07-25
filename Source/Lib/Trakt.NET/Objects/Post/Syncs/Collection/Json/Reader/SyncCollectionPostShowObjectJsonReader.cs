namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Enums;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncCollectionPostShowObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostShow>
    {
        public override async Task<ITraktSyncCollectionPostShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncCollectionPostShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCollectionPostShow traktSyncCollectionPostShow = new TraktSyncCollectionPostShow();
                var showIdsObjectJsonReader = new ShowIdsObjectJsonReader();
                var syncCollectionPostShowSeasonArrayJsonReader = new SyncCollectionPostShowSeasonArrayReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_COLLECTED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostShow.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_TITLE:
                            traktSyncCollectionPostShow.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_YEAR:
                            traktSyncCollectionPostShow.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_IDS:
                            traktSyncCollectionPostShow.Ids = await showIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_SEASONS:
                            traktSyncCollectionPostShow.Seasons = await syncCollectionPostShowSeasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_MEDIA_TYPE:
                            traktSyncCollectionPostShow.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_RESOLUTION:
                            traktSyncCollectionPostShow.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_AUDIO:
                            traktSyncCollectionPostShow.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_AUDIO_CHANNELS:
                            traktSyncCollectionPostShow.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_3D:
                            traktSyncCollectionPostShow.ThreeDimensional = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPostShow;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostShow));
        }
    }
}
