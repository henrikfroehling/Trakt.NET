namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostMovieArrayJsonReader : AArrayJsonReader<ITraktUserHiddenItemsPostMovie>
    {
        public override async Task<IEnumerable<ITraktUserHiddenItemsPostMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userHiddenItemsPostMovieReader = new UserHiddenItemsPostMovieObjectJsonReader();
                var userHiddenItemsPostMovies = new List<ITraktUserHiddenItemsPostMovie>();
                ITraktUserHiddenItemsPostMovie userHiddenItemsPostMovie = await userHiddenItemsPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userHiddenItemsPostMovie != null)
                {
                    userHiddenItemsPostMovies.Add(userHiddenItemsPostMovie);
                    userHiddenItemsPostMovie = await userHiddenItemsPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userHiddenItemsPostMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserHiddenItemsPostMovie>));
        }
    }
}
