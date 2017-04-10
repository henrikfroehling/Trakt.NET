namespace TraktApiSharp.Objects.Get.Collections
{
    using Basic;
    using System;

    public interface ITraktCollectionShowEpisode
    {
        int? Number { get; set; }

        DateTime? CollectedAt { get; set; }

        ITraktMetadata Metadata { get; set; }
    }
}
