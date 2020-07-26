namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostMovieArrayJsonReader : ArrayJsonReader<ITraktUserCustomListItemsPostMovie>
    {
        public override async Task<IEnumerable<ITraktUserCustomListItemsPostMovie>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostMovie>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCustomListItemsPostMovieReader = new UserCustomListItemsPostMovieObjectJsonReader();
                var userCustomListItemsPostMovies = new List<ITraktUserCustomListItemsPostMovie>();
                ITraktUserCustomListItemsPostMovie userCustomListItemsPostMovie = await userCustomListItemsPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userCustomListItemsPostMovie != null)
                {
                    userCustomListItemsPostMovies.Add(userCustomListItemsPostMovie);
                    userCustomListItemsPostMovie = await userCustomListItemsPostMovieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userCustomListItemsPostMovies;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserCustomListItemsPostMovie>));
        }
    }
}
