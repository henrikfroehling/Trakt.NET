namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Enums;
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncCollectionPostMovieObjectJsonReader : AObjectJsonReader<ITraktSyncCollectionPostMovie>
    {
        public override async Task<ITraktSyncCollectionPostMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncCollectionPostMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncCollectionPostMovie traktSyncCollectionPostMovie = new TraktSyncCollectionPostMovie();
                var movieIdsObjectJsonReader = new MovieIdsObjectJsonReader();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_COLLECTED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSyncCollectionPostMovie.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_TITLE:
                            traktSyncCollectionPostMovie.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_YEAR:
                            traktSyncCollectionPostMovie.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_IDS:
                            traktSyncCollectionPostMovie.Ids = await movieIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_MEDIA_TYPE:
                            traktSyncCollectionPostMovie.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_RESOLUTION:
                            traktSyncCollectionPostMovie.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_AUDIO:
                            traktSyncCollectionPostMovie.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_AUDIO_CHANNELS:
                            traktSyncCollectionPostMovie.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_3D:
                            traktSyncCollectionPostMovie.ThreeDimensional = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPostMovie;
            }

            return await Task.FromResult(default(ITraktSyncCollectionPostMovie));
        }
    }
}
