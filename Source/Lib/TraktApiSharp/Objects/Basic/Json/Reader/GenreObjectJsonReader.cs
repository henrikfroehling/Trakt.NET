namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class GenreObjectJsonReader : AObjectJsonReader<ITraktGenre>
    {
        public override async Task<ITraktGenre> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktGenre));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktGenre traktGenre = new TraktGenre();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.GENRE_PROPERTY_NAME_NAME:
                            traktGenre.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.GENRE_PROPERTY_NAME_SLUG:
                            traktGenre.Slug = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktGenre;
            }

            return await Task.FromResult(default(ITraktGenre));
        }
    }
}
