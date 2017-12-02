namespace TraktApiSharp.Objects.Post.Comments.Responses.Json.Reader
{
    using Basic.Json.Reader;
    using Get.Users.Json.Reader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentPostResponseObjectJsonReader : IObjectJsonReader<ITraktCommentPostResponse>
    {
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
                var userReader = new UserObjectJsonReader();
                var sharingReader = new SharingObjectJsonReader();
                ITraktCommentPostResponse traktCommentPostResponse = new TraktCommentPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.Id = value.Second;

                                break;
                            }
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_PARENT_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.ParentId = value.Second;

                                break;
                            }
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.CreatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_COMMENT:
                            traktCommentPostResponse.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_SPOILER:
                            traktCommentPostResponse.Spoiler = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_REVIEW:
                            traktCommentPostResponse.Review = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_REPLIES:
                            traktCommentPostResponse.Replies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_LIKES:
                            traktCommentPostResponse.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_USER_RATING:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.UserRating = value.Second;

                                break;
                            }
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_USER:
                            traktCommentPostResponse.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.COMMENT_POST_RESPONSE_PROPERTY_NAME_SHARING:
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
