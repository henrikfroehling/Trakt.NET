namespace TraktApiSharp.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionMovieArrayJsonReader : AArrayJsonReader<ITraktCollectionMovie>
    {
        public override async Task<IEnumerable<ITraktCollectionMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionMovieReader = new CollectionMovieObjectJsonReader();
                //var collectionMovieReadingTasks = new List<Task<ITraktCollectionMovie>>();
                var collectionMovies = new List<ITraktCollectionMovie>();

                //collectionMovieReadingTasks.Add(collectionMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionMovie collectionMovie = await collectionMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionMovie != null)
                {
                    collectionMovies.Add(collectionMovie);
                    //collectionMovieReadingTasks.Add(collectionMovieReader.ReadObjectAsync(jsonReader, cancellationToken));
                    collectionMovie = await collectionMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionMovies = await Task.WhenAll(collectionMovieReadingTasks);
                //return (IEnumerable<ITraktCollectionMovie>)readCollectionMovies.GetEnumerator();
                return collectionMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionMovie>));
        }
    }
}
