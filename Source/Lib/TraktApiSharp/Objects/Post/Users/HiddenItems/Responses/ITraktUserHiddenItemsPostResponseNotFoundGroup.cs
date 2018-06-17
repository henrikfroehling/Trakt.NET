namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses
{
    using Post.Responses;
    using System.Collections.Generic;

    public interface ITraktUserHiddenItemsPostResponseNotFoundGroup
    {
        IEnumerable<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        IEnumerable<ITraktPostResponseNotFoundShow> Shows { get; set; }

        IEnumerable<ITraktPostResponseNotFoundSeason> Seasons { get; set; }
    }
}
