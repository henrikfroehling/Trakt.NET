namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundEpisodeArrayJsonReader : AArrayJsonReader<ITraktPostResponseNotFoundEpisode>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
