namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Post.Responses;
    using System.Collections.Generic;

    public interface ITraktUserCustomListItemsPostResponseNotFoundGroup
    {
        IEnumerable<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        IEnumerable<ITraktPostResponseNotFoundShow> Shows { get; set; }

        IEnumerable<ITraktPostResponseNotFoundSeason> Seasons { get; set; }

        IEnumerable<ITraktPostResponseNotFoundEpisode> Episodes { get; set; }

        IEnumerable<ITraktPostResponseNotFoundPerson> People { get; set; }
    }
}
