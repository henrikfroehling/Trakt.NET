namespace TraktApiSharp.Objects.Get.Collection
{
    using Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktCollectionShow : ITraktShow
    {
        DateTime? LastCollectedAt { get; set; }

        ITraktShow Show { get; set; }

        IEnumerable<TraktCollectionShowSeason> CollectionSeasons { get; set; }
    }
}
