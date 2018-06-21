namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    using Post.Responses;
    using System.Collections.Generic;

    public class TraktUserHiddenItemsPostResponseNotFoundGroup : ITraktUserHiddenItemsPostResponseNotFoundGroup
    {
        public IEnumerable<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        public IEnumerable<ITraktPostResponseNotFoundShow> Shows { get; set; }

        public IEnumerable<ITraktPostResponseNotFoundSeason> Seasons { get; set; }
    }
}
