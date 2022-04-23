namespace TraktNet.Objects.Get.People.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonObjectJsonWriter : AObjectJsonWriter<ITraktPerson>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPerson obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var personIdsObjectJsonWriter = new PersonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await personIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Biography))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_BIOGRAPHY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Biography, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Birthday.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_BIRTHDAY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Birthday.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Death.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DEATH, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Death.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Birthplace))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_BIRTHPLACE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Birthplace, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Homepage))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_HOMEPAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Homepage, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Gender))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_GENDER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Gender, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.KnownForDepartment))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_KNOWN_FOR_DEPARTMENT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.KnownForDepartment, cancellationToken).ConfigureAwait(false);
            }

            if (obj.SocialIds != null)
            {
                var personSocialIdsObjectJsonWriter = new PersonSocialIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SOCIAL_IDS, cancellationToken).ConfigureAwait(false);
                await personSocialIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.SocialIds, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
