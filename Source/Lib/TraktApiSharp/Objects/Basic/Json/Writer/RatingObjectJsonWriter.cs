namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingObjectJsonWriter : AObjectJsonWriter<ITraktRating>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRating obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Distribution?.Count > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RATING_PROPERTY_NAME_DISTRIBUTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

                for (int i = 1; i <= 10; i++)
                {
                    string key = i.ToString();
                    await jsonWriter.WritePropertyNameAsync(key, cancellationToken).ConfigureAwait(false);

                    if (obj.Distribution.TryGetValue(key, out int value))
                    {
                        if (value > 0)
                            await jsonWriter.WriteValueAsync(value, cancellationToken).ConfigureAwait(false);
                        else
                            await jsonWriter.WriteValueAsync(0, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await jsonWriter.WriteValueAsync(0, cancellationToken).ConfigureAwait(false);
                    }
                }

                await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
