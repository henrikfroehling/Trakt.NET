namespace TraktApiSharp.Objects.Post.Responses.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktPostResponseNotFoundSeasonArrayJsonReader : IArrayJsonReader<ITraktPostResponseNotFoundSeason>
    {
        public Task<IEnumerable<ITraktPostResponseNotFoundSeason>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPostResponseNotFoundSeason>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPostResponseNotFoundSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundSeasonObjectReader = new TraktPostResponseNotFoundSeasonObjectJsonReader();
                //var postResponseNotFoundSeasonReadingTasks = new List<Task<ITraktPostResponseNotFoundSeason>>();
                var postResponseNotFoundSeasons = new List<ITraktPostResponseNotFoundSeason>();

                //postResponseNotFoundSeasonReadingTasks.Add(postResponseNotFoundSeasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundSeason postResponseNotFoundSeason = await postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundSeason != null)
                {
                    postResponseNotFoundSeasons.Add(postResponseNotFoundSeason);
                    //postResponseNotFoundSeasonReadingTasks.Add(postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundSeason = await postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundSeasons = await Task.WhenAll(postResponseNotFoundSeasonReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundSeason>)readPostResponseNotFoundSeasons.GetEnumerator();
                return postResponseNotFoundSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));
        }
    }
}
