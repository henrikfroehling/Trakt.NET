namespace TraktNet.Objects.Post
{
    using System;
    using TraktNet.Objects.Basic;

    public abstract class CollectionEntry<T>
    {
        public T Object { get; }

        public CollectionEntry(T obj)
            => Object = obj ?? throw new ArgumentNullException(nameof(obj));
    }

    public sealed class CollectedEntry<T> : CollectionEntry<T>
    {
        public DateTime CollectedAt { get; }

        public CollectedEntry(T obj, DateTime collectedAt) : base(obj)
            => CollectedAt = collectedAt.ToUniversalTime();
    }

    public class EntryWithMetadata<T> : CollectionEntry<T>
    {
        public ITraktMetadata Metadata { get; }

        public EntryWithMetadata(T obj, ITraktMetadata metadata) : base(obj)
            => Metadata = metadata ?? throw new ArgumentNullException(nameof(metadata));
    }

    public sealed class CollectedEntryWithMetadata<T> : EntryWithMetadata<T>
    {
        public DateTime CollectedAt { get; }

        public CollectedEntryWithMetadata(T obj, ITraktMetadata metadata, DateTime collectedAt)
            : base(obj, metadata)
            => CollectedAt = collectedAt.ToUniversalTime();
    }

    public sealed class CollectionShowAndSeasons<T>
    {
        public T Object { get; }

        public PostCollectionSeasons Seasons { get; }

        public CollectionShowAndSeasons(T obj, PostCollectionSeasons seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }
    }
}
