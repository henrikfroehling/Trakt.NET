namespace TraktApiSharp.Objects.Get.Collection
{
    using Basic;
    using Movies;
    using System;

    public interface ITraktCollectionMovie : ITraktMovie
    {
        DateTime? CollectedAt { get; set; }

        ITraktMovie Movie { get; set; }

        TraktMetadata Metadata { get; set; }
    }
}
