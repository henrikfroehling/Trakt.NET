namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieScrobblePostResponseArrayJsonReader : ArrayJsonReader<ITraktMovieScrobblePostResponse>
    {
        public override async Task<IEnumerable<ITraktMovieScrobblePostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieScrobblePostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieScrobblePostResponseReader = new MovieScrobblePostResponseObjectJsonReader();
                var movieScrobblePostResponses = new List<ITraktMovieScrobblePostResponse>();
                ITraktMovieScrobblePostResponse movieScrobblePostResponse = await movieScrobblePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (movieScrobblePostResponse != null)
                {
                    movieScrobblePostResponses.Add(movieScrobblePostResponse);
                    movieScrobblePostResponse = await movieScrobblePostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return movieScrobblePostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieScrobblePostResponse>));
        }
    }
}
