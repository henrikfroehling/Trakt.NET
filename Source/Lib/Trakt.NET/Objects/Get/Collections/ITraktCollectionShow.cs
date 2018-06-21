namespace TraktNet.Objects.Get.Collections
{
    using Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktCollectionShow : ITraktShow
    {
        DateTime? LastCollectedAt { get; set; }

        ITraktShow Show { get; set; }

        IEnumerable<ITraktCollectionShowSeason> CollectionSeasons { get; set; }
    }
}
