namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingObjectJsonWriter : IObjectJsonWriter<ITraktRating>
    {
        public Task<string> WriteObjectAsync(ITraktRating obj, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteObjectAsync(writer, obj, cancellationToken);
            }
        }

        public async Task<string> WriteObjectAsync(StringWriter writer, ITraktRating obj, CancellationToken cancellationToken = default)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            using (var jsonWriter = new JsonTextWriter(writer))
            {
                await WriteObjectAsync(jsonWriter, obj, cancellationToken);
            }

            return writer.ToString();
        }

        public async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRating obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_RATING, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_VOTES, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken);
            }

            if (obj.Distribution?.Count > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_DISTRIBUTION, cancellationToken);
                await jsonWriter.WriteStartObjectAsync(cancellationToken);

                for (int i = 1; i <= 10; i++)
                {
                    string key = i.ToString();
                    await jsonWriter.WritePropertyNameAsync(key, cancellationToken);

                    if (obj.Distribution.TryGetValue(key, out int value))
                    {
                        if (value > 0)
                            await jsonWriter.WriteValueAsync(value, cancellationToken);
                        else
                            await jsonWriter.WriteValueAsync(0, cancellationToken);
                    }
                    else
                        await jsonWriter.WriteValueAsync(0, cancellationToken);
                }

                await jsonWriter.WriteEndObjectAsync(cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
