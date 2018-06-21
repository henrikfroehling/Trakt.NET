namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktUserHiddenItemsPost : IRequestBody
    {
        IEnumerable<ITraktUserHiddenItemsPostMovie> Movies { get; set; }

        IEnumerable<ITraktUserHiddenItemsPostShow> Shows { get; set; }

        IEnumerable<ITraktUserHiddenItemsPostSeason> Seasons { get; set; }
    }
}
