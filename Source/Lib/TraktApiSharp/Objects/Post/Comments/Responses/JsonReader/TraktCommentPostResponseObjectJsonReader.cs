namespace TraktApiSharp.Objects.Post.Comments.Responses.JsonReader
{
    using Basic.JsonReader;
    using Get.Users.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCommentPostResponseObjectJsonReader : IObjectJsonReader<ITraktCommentPostResponse>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_PARENT_ID = "parent_id";
        private const string PROPERTY_NAME_CREATED_AT = "created_at";
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_COMMENT = "comment";
        private const string PROPERTY_NAME_SPOILER = "spoiler";
        private const string PROPERTY_NAME_REVIEW = "review";
        private const string PROPERTY_NAME_REPLIES = "replies";
        private const string PROPERTY_NAME_LIKES = "likes";
        private const string PROPERTY_NAME_USER_RATING = "user_rating";
        private const string PROPERTY_NAME_USER = "user";
        private const string PROPERTY_NAME_SHARING = "sharing";

        public Task<ITraktCommentPostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktCommentPostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktCommentPostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktCommentPostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktCommentPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCommentPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userReader = new TraktUserObjectJsonReader();
                var sharingReader = new TraktSharingObjectJsonReader();
                ITraktCommentPostResponse traktCommentPostResponse = new TraktCommentPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_PARENT_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.ParentId = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.CreatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.UpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_COMMENT:
                            traktCommentPostResponse.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_SPOILER:
                            traktCommentPostResponse.Spoiler = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_REVIEW:
                            traktCommentPostResponse.Review = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_REPLIES:
                            traktCommentPostResponse.Replies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_LIKES:
                            traktCommentPostResponse.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_USER_RATING:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.UserRating = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_USER:
                            traktCommentPostResponse.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHARING:
                            traktCommentPostResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCommentPostResponse;
            }

            return await Task.FromResult(default(ITraktCommentPostResponse));
        }
    }
}
