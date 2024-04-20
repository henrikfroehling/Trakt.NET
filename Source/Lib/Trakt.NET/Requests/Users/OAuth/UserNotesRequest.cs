namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Exceptions;
    using Extensions;
    using Objects.Get.Notes;
    using System.Collections.Generic;

    internal sealed class UserNotesRequest : AUsersPagedGetRequest<ITraktNoteItem>, IHasUsername
    {
        public string Username { get; set; }

        internal TraktNotesObjectType Type { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.OptionalButMightBeRequired;

        public override string UriTemplate => "users/{username}/notes{/type}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktNotesObjectType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");
        }
    }
}
