namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostMovieObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostMovie>
    {
        public override async Task<ITraktUserPersonalListItemsPostMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieIdsObjectJsonReader = new MovieIdsObjectJsonReader();
                ITraktUserPersonalListItemsPostMovie customListItemsPostMovie = new TraktUserPersonalListItemsPostMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            customListItemsPostMovie.Ids = await movieIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostMovie;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostMovie));
        }
    }
}
