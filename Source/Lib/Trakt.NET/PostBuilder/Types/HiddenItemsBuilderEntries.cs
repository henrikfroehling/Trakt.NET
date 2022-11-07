namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Shows;

    public abstract class HiddenItemsEntryWithSeasons<T>
    {
        public T Object { get; }

        public IEnumerable<int> Seasons { get; }

        protected HiddenItemsEntryWithSeasons(T obj, IEnumerable<int> seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
        }

        protected HiddenItemsEntryWithSeasons(T obj, int season, params int[] seasons)
        {
            Object = obj ?? throw new ArgumentNullException(nameof(obj));
            Seasons = new List<int>();
            (Seasons as List<int>).Add(season);

            if (seasons?.Length > 0)
                (Seasons as List<int>).AddRange(seasons);
        }
    }

    /// <summary>Represents a <see cref="ITraktShow"/> with a seasons collection.</summary>
    public sealed class HiddenShowWithSeasons : HiddenItemsEntryWithSeasons<ITraktShow>
    {
        /// <summary>Initializes a new instance of the <see cref="HiddenShowWithSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="seasons">The seasons collection for the <paramref name="show"/>.</param>
        public HiddenShowWithSeasons(ITraktShow show, IEnumerable<int> seasons)
            : base(show, seasons)
        { }

        /// <summary>Initializes a new instance of the <see cref="HiddenShowWithSeasons" /> class.</summary>
        /// <param name="show">A <see cref="ITraktShow"/>.</param>
        /// <param name="season">A season number.</param>
        /// <param name="seasons">An optional list of season numbers.</param>
        public HiddenShowWithSeasons(ITraktShow show, int season, params int[] seasons)
            : base(show, season, seasons)
        { }
    }

    /// <summary>Represents a <see cref="ITraktShowIds"/> with a seasons collection.</summary>
    public sealed class HiddenShowIdsWithSeasons : HiddenItemsEntryWithSeasons<ITraktShowIds>
    {
        /// <summary>Initializes a new instance of the <see cref="HiddenShowIdsWithSeasons" /> class.</summary>
        /// <param name="showIds">A <see cref="ITraktShowIds"/>.</param>
        /// <param name="seasons">The seasons collection for the <paramref name="showIds"/>.</param>
        public HiddenShowIdsWithSeasons(ITraktShowIds showIds, IEnumerable<int> seasons)
            : base(showIds, seasons)
        { }

        /// <summary>Initializes a new instance of the <see cref="HiddenShowIdsWithSeasons" /> class.</summary>
        /// <param name="showIds">A <see cref="ITraktShowIds"/>.</param>
        /// <param name="season">A season number.</param>
        /// <param name="seasons">An optional list of season numbers.</param>
        public HiddenShowIdsWithSeasons(ITraktShowIds showIds, int season, params int[] seasons)
            : base(showIds, season, seasons)
        { }
    }
}
