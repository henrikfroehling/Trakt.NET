namespace TraktApiSharp.Objects.Get.Collections.Json.Writer
{
    using Basic.Json.Writer;
    using Extensions;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionMovieObjectJsonWriter : AObjectJsonWriter<ITraktCollectionMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCollectionMovie obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.CollectedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_MOVIE_PROPERTY_NAME_COLLECTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_MOVIE_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Metadata != null)
            {
                var metadataObjectJsonWriter = new MetadataObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.COLLECTION_MOVIE_PROPERTY_NAME_METADATA, cancellationToken).ConfigureAwait(false);
                await metadataObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Metadata, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
