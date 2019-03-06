namespace TraktNet.Objects.Get.Collections
{
    using Basic;
    using Movies;
    using System;

    public interface ITraktCollectionMovie : ITraktMovie
    {
        DateTime? CollectedAt { get; set; }

        DateTime? MovieUpdatedAt { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktMetadata Metadata { get; set; }
    }
}
