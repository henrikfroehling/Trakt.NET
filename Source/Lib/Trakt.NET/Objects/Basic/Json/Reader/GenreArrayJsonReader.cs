namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class GenreArrayJsonReader : AArrayJsonReader<ITraktGenre>
    {
        public override async Task<IEnumerable<ITraktGenre>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktGenre>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var genreReader = new GenreObjectJsonReader();
                var genres = new List<ITraktGenre>();
                ITraktGenre genre = await genreReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (genre != null)
                {
                    genres.Add(genre);
                    genre = await genreReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return genres;
            }

            return await Task.FromResult(default(IEnumerable<ITraktGenre>));
        }
    }
}
