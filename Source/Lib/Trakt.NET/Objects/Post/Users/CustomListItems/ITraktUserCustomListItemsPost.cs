namespace TraktNet.Objects.Post.Users.CustomListItems
{
    using Get.People;
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktUserCustomListItemsPost : IRequestBody
    {
        IEnumerable<ITraktUserCustomListItemsPostMovie> Movies { get; set; }

        IEnumerable<ITraktUserCustomListItemsPostShow> Shows { get; set; }

        IEnumerable<ITraktPerson> People { get; set; }
    }
}
