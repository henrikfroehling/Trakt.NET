namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Enums;
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncCollectionPostSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostSeason>
    {
        public override async Task<ITraktSyncCollectionPostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCollectionPostSeason traktSyncCollectionPostSeason = new TraktSyncCollectionPostSeason();
                var seasonIdsObjectJsonReader = new SeasonIdsObjectJsonReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COLLECTED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostSeason.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_IDS:
                            traktSyncCollectionPostSeason.Ids = await seasonIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MEDIA_TYPE:
                            traktSyncCollectionPostSeason.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RESOLUTION:
                            traktSyncCollectionPostSeason.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AUDIO:
                            traktSyncCollectionPostSeason.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AUDIO_CHANNELS:
                            traktSyncCollectionPostSeason.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_3D:
                            traktSyncCollectionPostSeason.ThreeDimensional = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPostSeason;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostSeason));
        }
    }
}
