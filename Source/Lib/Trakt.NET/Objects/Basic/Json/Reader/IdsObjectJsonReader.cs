namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class IdsObjectJsonReader : AObjectJsonReader<ITraktIds>
    {
        public override async Task<ITraktIds> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktIds traktIds = new TraktIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TRAKT:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktIds.Trakt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SLUG:
                            traktIds.Slug = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_TVDB:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktIds.Tvdb = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_IMDB:
                            traktIds.Imdb = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_TMDB:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktIds.Tmdb = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TVRAGE:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktIds.TvRage = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktIds;
            }

            return await Task.FromResult(default(ITraktIds));
        }
    }
}
