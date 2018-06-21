namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowArrayJsonReader : AArrayJsonReader<ITraktMostPWCShow>
    {
        public override async Task<IEnumerable<ITraktMostPWCShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostPWCShowReader = new MostPWCShowObjectJsonReader();
                //var traktMostPWCShowReadingTasks = new List<Task<ITraktMostPWCShow>>();
                var traktMostPWCShows = new List<ITraktMostPWCShow>();

                //traktMostPWCShowReadingTasks.Add(mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostPWCShow traktMostPWCShow = await mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostPWCShow != null)
                {
                    traktMostPWCShows.Add(traktMostPWCShow);
                    //traktMostPWCShowReadingTasks.Add(mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostPWCShow = await mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostPWCShows = await Task.WhenAll(traktMostPWCShowReadingTasks);
                //return (IEnumerable<ITraktMostPWCShow>)readMostPWCShows.GetEnumerator();
                return traktMostPWCShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));
        }
    }
}
