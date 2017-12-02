namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundEpisodeArrayJsonReader : IArrayJsonReader<ITraktPostResponseNotFoundEpisode>
    {
        public Task<IEnumerable<ITraktPostResponseNotFoundEpisode>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundEpisode>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPostResponseNotFoundEpisode>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundEpisode>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPostResponseNotFoundEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundEpisodeObjectReader = new PostResponseNotFoundEpisodeObjectJsonReader();
                //var postResponseNotFoundEpisodeReadingTasks = new List<Task<ITraktPostResponseNotFoundEpisode>>();
                var postResponseNotFoundEpisodes = new List<ITraktPostResponseNotFoundEpisode>();

                //postResponseNotFoundEpisodeReadingTasks.Add(postResponseNotFoundEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundEpisode postResponseNotFoundEpisode = await postResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundEpisode != null)
                {
                    postResponseNotFoundEpisodes.Add(postResponseNotFoundEpisode);
                    //postResponseNotFoundEpisodeReadingTasks.Add(postResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundEpisode = await postResponseNotFoundEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundEpisodes = await Task.WhenAll(postResponseNotFoundEpisodeReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundEpisode>)readPostResponseNotFoundEpisodes.GetEnumerator();
                return postResponseNotFoundEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundEpisode>));
        }
    }
}
