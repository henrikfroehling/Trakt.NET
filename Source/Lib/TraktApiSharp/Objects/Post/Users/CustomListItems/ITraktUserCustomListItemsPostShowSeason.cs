namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using System.Collections.Generic;

    public interface ITraktUserCustomListItemsPostShowSeason
    {
        int Number { get; set; }

        IEnumerable<ITraktUserCustomListItemsPostShowEpisode> Episodes { get; set; }
    }
}
