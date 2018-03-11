namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedShowArrayJsonReader : AArrayJsonReader<ITraktMostAnticipatedShow>
    {
        public override async Task<IEnumerable<ITraktMostAnticipatedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostAnticipatedShowReader = new MostAnticipatedShowObjectJsonReader();
                //var traktMostAnticipatedShowReadingTasks = new List<Task<ITraktMostAnticipatedShow>>();
                var traktMostAnticipatedShows = new List<ITraktMostAnticipatedShow>();

                //traktMostAnticipatedShowReadingTasks.Add(mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktMostAnticipatedShow traktMostAnticipatedShow = await mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostAnticipatedShow != null)
                {
                    traktMostAnticipatedShows.Add(traktMostAnticipatedShow);
                    //traktMostAnticipatedShowReadingTasks.Add(mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktMostAnticipatedShow = await mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readMostAnticipatedShows = await Task.WhenAll(traktMostAnticipatedShowReadingTasks);
                //return (IEnumerable<ITraktMostAnticipatedShow>)readMostAnticipatedShows.GetEnumerator();
                return traktMostAnticipatedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));
        }
    }
}
