namespace TraktNet.Objects.Post.Checkins.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCheckinPostResponseArrayJsonReader : AArrayJsonReader<ITraktMovieCheckinPostResponse>
    {
        public override async Task<IEnumerable<ITraktMovieCheckinPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMovieCheckinPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieCheckinPostResponseReader = new MovieCheckinPostResponseObjectJsonReader();
                var movieCheckinPostResponses = new List<ITraktMovieCheckinPostResponse>();
                ITraktMovieCheckinPostResponse movieCheckinPostResponse = await movieCheckinPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (movieCheckinPostResponse != null)
                {
                    movieCheckinPostResponses.Add(movieCheckinPostResponse);
                    movieCheckinPostResponse = await movieCheckinPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return movieCheckinPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMovieCheckinPostResponse>));
        }
    }
}
