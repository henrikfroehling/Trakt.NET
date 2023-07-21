namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Enums;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class FavoriteObjectJsonReader : AObjectJsonReader<ITraktFavorite>
    {
        public override async Task<ITraktFavorite> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktFavorite traktFavorite = new TraktFavorite();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktFavorite.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RANK:
                            traktFavorite.Rank = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                                if (value.First)
                                    traktFavorite.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktFavorite.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktFavoriteObjectType>(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            traktFavorite.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            {
                                var movieObjectReader = new MovieObjectJsonReader();
                                traktFavorite.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            {
                                var showObjectReader = new ShowObjectJsonReader();
                                traktFavorite.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktFavorite;
            }

            return await Task.FromResult(default(ITraktFavorite));
        }
    }
}
