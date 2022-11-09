namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader
{
    using Enums;
    using Get.Episodes.Json.Reader;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeScrobblePostResponseObjectJsonReader : AObjectJsonReader<ITraktEpisodeScrobblePostResponse>
    {
        public override async Task<ITraktEpisodeScrobblePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new ConnectionsObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                ITraktEpisodeScrobblePostResponse episodeScrobbleResponse = new TraktEpisodeScrobblePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodeScrobbleResponse.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_ACTION:
                            episodeScrobbleResponse.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktScrobbleActionType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PROGRESS:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodeScrobbleResponse.Progress = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            episodeScrobbleResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            episodeScrobbleResponse.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            episodeScrobbleResponse.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return episodeScrobbleResponse;
            }

            return await Task.FromResult(default(ITraktEpisodeScrobblePostResponse));
        }
    }
}
