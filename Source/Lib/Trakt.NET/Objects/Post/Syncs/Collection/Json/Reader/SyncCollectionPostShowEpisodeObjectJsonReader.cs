namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncCollectionPostShowEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostShowEpisode>
    {
        public override async Task<ITraktSyncCollectionPostShowEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCollectionPostShowEpisode traktSyncCollectionPostShowEpisode = new TraktSyncCollectionPostShowEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostShowEpisode.Number = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_COLLECTED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostShowEpisode.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_MEDIA_TYPE:
                            traktSyncCollectionPostShowEpisode.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RESOLUTION:
                            traktSyncCollectionPostShowEpisode.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AUDIO:
                            traktSyncCollectionPostShowEpisode.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AUDIO_CHANNELS:
                            traktSyncCollectionPostShowEpisode.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_3D:
                            traktSyncCollectionPostShowEpisode.ThreeDimensional = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPostShowEpisode;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostShowEpisode));
        }
    }
}
