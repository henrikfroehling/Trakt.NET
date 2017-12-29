namespace TraktApiSharp.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowArrayJsonReader : AArrayJsonReader<ITraktCollectionShow>
    {
        public override async Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowReader = new CollectionShowObjectJsonReader();
                //var collectionShowReadingTasks = new List<Task<ITraktCollectionShow>>();
                var collectionShows = new List<ITraktCollectionShow>();

                //collectionShowReadingTasks.Add(collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionShow collectionShow = await collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShow != null)
                {
                    collectionShows.Add(collectionShow);
                    //collectionShowReadingTasks.Add(collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    collectionShow = await collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionShows = await Task.WhenAll(collectionShowReadingTasks);
                //return (IEnumerable<ITraktCollectionShow>)readCollectionShows.GetEnumerator();
                return collectionShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));
        }
    }
}
