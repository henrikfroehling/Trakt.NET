namespace TraktNet.Objects.Get.Users.Notes.Json.Writer
{
    using Extensions;
    using Get.Users.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserNoteObjectJsonWriter : AObjectJsonWriter<ITraktUserNote>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserNote obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Notes))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Notes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Privacy != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PRIVACY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Privacy.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Spoiler.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SPOILER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Spoiler.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CreatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CREATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CreatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.User != null)
            {
                var userObjectWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectWriter.WriteObjectAsync(obj.User, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
