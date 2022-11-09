namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Post.Syncs.History;

    public interface ITraktSyncHistoryRemovePostBuilder : ITraktRemovePostBuilder<ITraktSyncHistoryRemovePostBuilder, ITraktSyncHistoryRemovePost>
    {
        /// <summary>Adds the given <paramref name="historyId"/> to the builder.</summary>
        /// <param name="historyId">The history id which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        ITraktSyncHistoryRemovePostBuilder WithHistoryId(ulong historyId);

        /// <summary>Adds the given <paramref name="historyIds"/> collection to the builder.</summary>
        /// <param name="historyIds">A collection of history ids which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="historyIds"/> is null.</exception>
        ITraktSyncHistoryRemovePostBuilder WithHistoryIds(IEnumerable<ulong> historyIds);

        /// <summary>Adds the given <paramref name="historyId"/> and <paramref name="historyIds"/> collection to the builder.</summary>
        /// <param name="historyId">The history id which will be added.</param>
        /// <param name="historyIds">A collection of history ids which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncHistoryRemovePostBuilder"/>.</returns>
        ITraktSyncHistoryRemovePostBuilder WithHistoryIds(ulong historyId, params ulong[] historyIds);
    }
}
