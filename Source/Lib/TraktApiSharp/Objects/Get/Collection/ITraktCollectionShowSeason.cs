namespace TraktApiSharp.Objects.Get.Collection
{
    using System.Collections.Generic;

    public interface ITraktCollectionShowSeason
    {
        int? Number { get; set; }

        IEnumerable<ITraktCollectionShowEpisode> Episodes { get; set; }
    }
}
