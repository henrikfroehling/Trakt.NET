namespace TraktNet.Requests.Base
{
    using Exceptions;
    using Objects.Post.Basic;
    using System.Collections.Generic;

    internal abstract class AListItemUpdateRequest : APutRequest<ITraktListItemUpdatePost>
    {
        internal uint ListItemId { get; set; }

        public override ITraktListItemUpdatePost RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["list_item_id"] = ListItemId.ToString()
            };

        public override void Validate()
        {
            base.Validate();

            if (ListItemId == 0)
                throw new TraktRequestValidationException(nameof(ListItemId), "list item id must not be 0");
        }
    }
}
