namespace TraktApiSharp.Objects.Basic.Json.Reader
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
                //var genreReadingTasks = new List<Task<ITraktGenre>>();
                var genres = new List<ITraktGenre>();

                //genreReadingTasks.Add(genreReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktGenre genre = await genreReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (genre != null)
                {
                    genres.Add(genre);
                    //genreReadingTasks.Add(genreReader.ReadObjectAsync(jsonReader, cancellationToken));
                    genre = await genreReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readGenres = await Task.WhenAll(genreReadingTasks);
                //return (IEnumerable<ITraktGenre>)readGenres.GetEnumerator();
                return genres;
            }

            return await Task.FromResult(default(IEnumerable<ITraktGenre>));
        }
    }
}
