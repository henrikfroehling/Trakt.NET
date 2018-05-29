namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowIdsObjectJsonReader : AObjectJsonReader<ITraktShowIds>
    {
        public override async Task<ITraktShowIds> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowIds));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktShowIds traktShowIds = new TraktShowIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHOW_IDS_PROPERTY_NAME_TRAKT:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowIds.Trakt = value.Second;

                                break;
                            }
                        case JsonProperties.SHOW_IDS_PROPERTY_NAME_SLUG:
                            traktShowIds.Slug = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_IDS_PROPERTY_NAME_TVDB:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowIds.Tvdb = value.Second;

                                break;
                            }
                        case JsonProperties.SHOW_IDS_PROPERTY_NAME_IMDB:
                            traktShowIds.Imdb = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_IDS_PROPERTY_NAME_TMDB:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowIds.Tmdb = value.Second;

                                break;
                            }
                        case JsonProperties.SHOW_IDS_PROPERTY_NAME_TVRAGE:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowIds.TvRage = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowIds;
            }

            return await Task.FromResult(default(ITraktShowIds));
        }
    }
}
