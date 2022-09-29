namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;

    /// <summary>
    /// Post builder for <see cref="ITraktSyncCollectionPost" />s.
    /// <para>Provides methods for adding movies, shows, seasons and episodes.</para>
    /// </summary>
    public interface ITraktSyncCollectionPostBuilder
    {
        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovie(ITraktMovie movie);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovie(ITraktMovieIds movieIds);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movie"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieCollectedAt(ITraktMovie movie, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="movieCollectedAt"/> to the builder.</summary>
        /// <param name="movieCollectedAt">The <see cref="CollectedEntry{ITraktMovie}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieCollectedAt(CollectedEntry<ITraktMovie> movieCollectedAt);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movieIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieCollectedAt(ITraktMovieIds movieIds, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="movieIdsCollectedAt"/> to the builder.</summary>
        /// <param name="movieIdsCollectedAt">The <see cref="CollectedEntry{ITraktMovieIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieCollectedAt(CollectedEntry<ITraktMovieIds> movieIdsCollectedAt);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="movie"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadata(ITraktMovie movie, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="movieWithMetadata"/> to the builder.</summary>
        /// <param name="movieWithMetadata">The <see cref="EntryWithMetadata{ITraktMovie}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadata(EntryWithMetadata<ITraktMovie> movieWithMetadata);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="movieIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadata(ITraktMovieIds movieIds, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="movieIdsWithMetadata"/> to the builder.</summary>
        /// <param name="movieIdsWithMetadata">The <see cref="EntryWithMetadata{ITraktMovieIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadata(EntryWithMetadata<ITraktMovieIds> movieIdsWithMetadata);

        /// <summary>Adds the given <paramref name="movie"/> to the builder.</summary>
        /// <param name="movie">The <see cref="ITraktMovie"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="movie"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movie"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(ITraktMovie movie, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="movieWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="movieWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktMovie}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktMovie> movieWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="movieIds"/> to the builder.</summary>
        /// <param name="movieIds">The <see cref="ITraktMovieIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="movieIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="movieIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(ITraktMovieIds movieIds, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="movieIdsWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="movieIdsWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktMovieIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovieWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktMovieIds> movieIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="movies"/> collection to the builder.</summary>
        /// <param name="movies">A collection of <see cref="ITraktMovie"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movies"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovie> movies);

        /// <summary>Adds the given <paramref name="movieIds"/> collection to the builder.</summary>
        /// <param name="movieIds">A collection of <see cref="ITraktMovieIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds);

        /// <summary>Adds the given <paramref name="moviesCollectedAt"/> collection to the builder.</summary>
        /// <param name="moviesCollectedAt">A collection of <see cref="CollectedEntry{ITraktMovie}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMoviesCollectedAt(IEnumerable<CollectedEntry<ITraktMovie>> moviesCollectedAt);

        /// <summary>Adds the given <paramref name="movieIdsCollectedAt"/> collection to the builder.</summary>
        /// <param name="movieIdsCollectedAt">A collection of <see cref="CollectedEntry{ITraktMovieIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMoviesCollectedAt(IEnumerable<CollectedEntry<ITraktMovieIds>> movieIdsCollectedAt);

        /// <summary>Adds the given <paramref name="moviesWithMetadata"/> collection to the builder.</summary>
        /// <param name="moviesWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktMovie}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMoviesWithMetadata(IEnumerable<EntryWithMetadata<ITraktMovie>> moviesWithMetadata);

        /// <summary>Adds the given <paramref name="movieIdsWithMetadata"/> collection to the builder.</summary>
        /// <param name="movieIdsWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktMovieIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMoviesWithMetadata(IEnumerable<EntryWithMetadata<ITraktMovieIds>> movieIdsWithMetadata);

        /// <summary>Adds the given <paramref name="moviesWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="moviesWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktMovie}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="moviesWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMoviesWithMetadataCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktMovie>> moviesWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="movieIdsWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="movieIdsWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktMovieIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithMoviesWithMetadataCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktMovieIds>> movieIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShow(ITraktShow show);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShow(ITraktShowIds showIds);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="show"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowCollectedAt(ITraktShow show, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="showCollectedAt"/> to the builder.</summary>
        /// <param name="showCollectedAt">The <see cref="CollectedEntry{ITraktShow}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowCollectedAt(CollectedEntry<ITraktShow> showCollectedAt);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="showIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowCollectedAt(ITraktShowIds showIds, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="showIdsCollectedAt"/> to the builder.</summary>
        /// <param name="showIdsCollectedAt">The <see cref="CollectedEntry{ITraktShowIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowCollectedAt(CollectedEntry<ITraktShowIds> showIdsCollectedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="show"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadata(ITraktShow show, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="showWithMetadata"/> to the builder.</summary>
        /// <param name="showWithMetadata">The <see cref="EntryWithMetadata{ITraktShow}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadata(EntryWithMetadata<ITraktShow> showWithMetadata);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="showIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadata(ITraktShowIds showIds, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="showIdsWithMetadata"/> to the builder.</summary>
        /// <param name="showIdsWithMetadata">The <see cref="EntryWithMetadata{ITraktShowIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadata(EntryWithMetadata<ITraktShowIds> showIdsWithMetadata);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="show"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="show"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(ITraktShow show, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="showWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="showWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktShow}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktShow> showWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="showIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="showIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(ITraktShowIds showIds, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="showIdsWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="showIdsWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktShowIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktShowIds> showIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="shows"/> collection to the builder.</summary>
        /// <param name="shows">A collection of <see cref="ITraktShow"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="shows"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShow> shows);

        /// <summary>Adds the given <paramref name="showIds"/> collection to the builder.</summary>
        /// <param name="showIds">A collection of <see cref="ITraktShowIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds);

        /// <summary>Adds the given <paramref name="showsCollectedAt"/> collection to the builder.</summary>
        /// <param name="showsCollectedAt">A collection of <see cref="CollectedEntry{ITraktShow}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsCollectedAt(IEnumerable<CollectedEntry<ITraktShow>> showsCollectedAt);

        /// <summary>Adds the given <paramref name="showIdsCollectedAt"/> collection to the builder.</summary>
        /// <param name="showIdsCollectedAt">A collection of <see cref="CollectedEntry{ITraktShowIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsCollectedAt(IEnumerable<CollectedEntry<ITraktShowIds>> showIdsCollectedAt);

        /// <summary>Adds the given <paramref name="showsWithMetadata"/> collection to the builder.</summary>
        /// <param name="showsWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktShow}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsWithMetadata(IEnumerable<EntryWithMetadata<ITraktShow>> showsWithMetadata);

        /// <summary>Adds the given <paramref name="showIdsWithMetadata"/> collection to the builder.</summary>
        /// <param name="showIdsWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktShowIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsWithMetadata(IEnumerable<EntryWithMetadata<ITraktShowIds>> showIdsWithMetadata);

        /// <summary>Adds the given <paramref name="showsWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="showsWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktShow}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktShow>> showsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="showIdsWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="showIdsWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktShowIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktShowIds>> showIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="show"/> to the builder.</summary>
        /// <param name="show">The <see cref="ITraktShow"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostCollectionSeasons"/> for the <paramref name="show"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="show"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowAndSeasons(ITraktShow show, PostCollectionSeasons seasons);

        /// <summary>Adds the given <paramref name="showAndSeasons"/> to the builder.</summary>
        /// <param name="showAndSeasons">The <see cref="CollectionShowAndSeasons{ITraktShow}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showAndSeasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowAndSeasons(CollectionShowAndSeasons<ITraktShow> showAndSeasons);

        /// <summary>Adds the given <paramref name="showIds"/> to the builder.</summary>
        /// <param name="showIds">The <see cref="ITraktShowIds"/> which will be added.</param>
        /// <param name="seasons">The <see cref="PostCollectionSeasons"/> for the <paramref name="showIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostCollectionSeasons seasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> to the builder.</summary>
        /// <param name="showIdsAndSeasons">The <see cref="CollectionShowAndSeasons{ITraktShowIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowAndSeasons(CollectionShowAndSeasons<ITraktShowIds> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="showsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showsAndSeasons">A collection of <see cref="CollectionShowAndSeasons{ITraktShow}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showsAndSeasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsAndSeasons(IEnumerable<CollectionShowAndSeasons<ITraktShow>> showsAndSeasons);

        /// <summary>Adds the given <paramref name="showIdsAndSeasons"/> collection to the builder.</summary>
        /// <param name="showIdsAndSeasons">A collection of <see cref="CollectionShowAndSeasons{ITraktShowIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="showIdsAndSeasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithShowsAndSeasons(IEnumerable<CollectionShowAndSeasons<ITraktShowIds>> showIdsAndSeasons);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeason(ITraktSeason season);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeason(ITraktSeasonIds seasonIds);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="season"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(ITraktSeason season, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="seasonCollectedAt"/> to the builder.</summary>
        /// <param name="seasonCollectedAt">The <see cref="CollectedEntry{ITraktSeason}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(CollectedEntry<ITraktSeason> seasonCollectedAt);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="seasonIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(ITraktSeasonIds seasonIds, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="seasonIdsCollectedAt"/> to the builder.</summary>
        /// <param name="seasonIdsCollectedAt">The <see cref="CollectedEntry{ITraktSeasonIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonCollectedAt(CollectedEntry<ITraktSeasonIds> seasonIdsCollectedAt);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="season"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(ITraktSeason season, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="seasonWithMetadata"/> to the builder.</summary>
        /// <param name="seasonWithMetadata">The <see cref="EntryWithMetadata{ITraktSeason}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(EntryWithMetadata<ITraktSeason> seasonWithMetadata);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="seasonIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(ITraktSeasonIds seasonIds, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="seasonIdsWithMetadata"/> to the builder.</summary>
        /// <param name="seasonIdsWithMetadata">The <see cref="EntryWithMetadata{ITraktSeasonIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadata(EntryWithMetadata<ITraktSeasonIds> seasonIdsWithMetadata);

        /// <summary>Adds the given <paramref name="season"/> to the builder.</summary>
        /// <param name="season">The <see cref="ITraktSeason"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="season"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="season"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="season"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(ITraktSeason season, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="seasonWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="seasonWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktSeason}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktSeason> seasonWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="seasonIds"/> to the builder.</summary>
        /// <param name="seasonIds">The <see cref="ITraktSeasonIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="seasonIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="seasonIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(ITraktSeasonIds seasonIds, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="seasonIdsWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="seasonIdsWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktSeasonIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktSeasonIds> seasonIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="seasons"/> collection to the builder.</summary>
        /// <param name="seasons">A collection of <see cref="ITraktSeason"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasons"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons);

        /// <summary>Adds the given <paramref name="seasonIds"/> collection to the builder.</summary>
        /// <param name="seasonIds">A collection of <see cref="ITraktSeasonIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds);

        /// <summary>Adds the given <paramref name="seasonsCollectedAt"/> collection to the builder.</summary>
        /// <param name="seasonsCollectedAt">A collection of <see cref="CollectedEntry{ITraktSeason}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonsCollectedAt(IEnumerable<CollectedEntry<ITraktSeason>> seasonsCollectedAt);

        /// <summary>Adds the given <paramref name="seasonIdsCollectedAt"/> collection to the builder.</summary>
        /// <param name="seasonIdsCollectedAt">A collection of <see cref="CollectedEntry{ITraktSeasonIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonsCollectedAt(IEnumerable<CollectedEntry<ITraktSeasonIds>> seasonIdsCollectedAt);

        /// <summary>Adds the given <paramref name="seasonsWithMetadata"/> collection to the builder.</summary>
        /// <param name="seasonsWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktSeason}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonsWithMetadata(IEnumerable<EntryWithMetadata<ITraktSeason>> seasonsWithMetadata);

        /// <summary>Adds the given <paramref name="seasonIdsWithMetadata"/> collection to the builder.</summary>
        /// <param name="seasonIdsWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktSeasonIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonsWithMetadata(IEnumerable<EntryWithMetadata<ITraktSeasonIds>> seasonIdsWithMetadata);

        /// <summary>Adds the given <paramref name="seasonsWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="seasonsWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktSeason}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktSeason>> seasonsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="seasonIdsWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="seasonIdsWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktSeasonIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="seasonIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithSeasonsWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktSeasonIds>> seasonIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisode episode);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisode(ITraktEpisodeIds episodeIds);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episode"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(ITraktEpisode episode, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="episodeCollectedAt"/> to the builder.</summary>
        /// <param name="episodeCollectedAt">The <see cref="CollectedEntry{ITraktEpisode}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>episodes
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(CollectedEntry<ITraktEpisode> episodeCollectedAt);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episodeIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(ITraktEpisodeIds episodeIds, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="episodeIdsCollectedAt"/> to the builder.</summary>
        /// <param name="episodeIdsCollectedAt">The <see cref="CollectedEntry{ITraktEpisodeIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeCollectedAt(CollectedEntry<ITraktEpisodeIds> episodeIdsCollectedAt);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="episode"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(ITraktEpisode episode, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="episodeWithMetadata"/> to the builder.</summary>
        /// <param name="episodeWithMetadata">The <see cref="EntryWithMetadata{ITraktEpisode}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(EntryWithMetadata<ITraktEpisode> episodeWithMetadata);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="episodeIds"/>.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(ITraktEpisodeIds episodeIds, ITraktMetadata metadata);

        /// <summary>Adds the given <paramref name="episodeIdsWithMetadata"/> to the builder.</summary>
        /// <param name="episodeIdsWithMetadata">The <see cref="EntryWithMetadata{ITraktEpisodeIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadata(EntryWithMetadata<ITraktEpisodeIds> episodeIdsWithMetadata);

        /// <summary>Adds the given <paramref name="episode"/> to the builder.</summary>
        /// <param name="episode">The <see cref="ITraktEpisode"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="episode"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episode"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episode"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(ITraktEpisode episode, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="episodeWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="episodeWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktEpisode}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktEpisode> episodeWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="episodeIds"/> to the builder.</summary>
        /// <param name="episodeIds">The <see cref="ITraktEpisodeIds"/> which will be added.</param>
        /// <param name="metadata">The <see cref="ITraktMetadata"/> for the given <paramref name="episodeIds"/>.</param>
        /// <param name="collectedAt">The UTC datetime when the <paramref name="episodeIds"/> was collected.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="metadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(ITraktEpisodeIds episodeIds, ITraktMetadata metadata, DateTime collectedAt);

        /// <summary>Adds the given <paramref name="episodeIdsWithMetadataCollectedAt"/> to the builder.</summary>
        /// <param name="episodeIdsWithMetadataCollectedAt">The <see cref="CollectedEntryWithMetadata{ITraktEpisodeIds}"/> which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodeWithMetadataAndCollectedAt(CollectedEntryWithMetadata<ITraktEpisodeIds> episodeIdsWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="episodes"/> collection to the builder.</summary>
        /// <param name="episodes">A collection of <see cref="ITraktEpisode"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodes"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);

        /// <summary>Adds the given <paramref name="episodeIds"/> collection to the builder.</summary>
        /// <param name="episodeIds">A collection of <see cref="ITraktEpisodeIds"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIds"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds);

        /// <summary>Adds the given <paramref name="episodesCollectedAt"/> collection to the builder.</summary>
        /// <param name="episodesCollectedAt">A collection of <see cref="CollectedEntry{ITraktEpisode}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodesCollectedAt(IEnumerable<CollectedEntry<ITraktEpisode>> episodesCollectedAt);

        /// <summary>Adds the given <paramref name="episodeIdsCollectedAt"/> collection to the builder.</summary>
        /// <param name="episodeIdsCollectedAt">A collection of <see cref="CollectedEntry{ITraktEpisodeIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodesCollectedAt(IEnumerable<CollectedEntry<ITraktEpisodeIds>> episodeIdsCollectedAt);

        /// <summary>Adds the given <paramref name="episodesWithMetadata"/> collection to the builder.</summary>
        /// <param name="episodesWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktEpisode}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodesWithMetadata(IEnumerable<EntryWithMetadata<ITraktEpisode>> episodesWithMetadata);

        /// <summary>Adds the given <paramref name="episodeIdsWithMetadata"/> collection to the builder.</summary>
        /// <param name="episodeIdsWithMetadata">A collection of <see cref="EntryWithMetadata{ITraktEpisodeIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithMetadata"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodesWithMetadata(IEnumerable<EntryWithMetadata<ITraktEpisodeIds>> episodeIdsWithMetadata);

        /// <summary>Adds the given <paramref name="episodesWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="episodesWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktEpisode}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodesWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodesWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktEpisode>> episodesWithMetadataCollectedAt);

        /// <summary>Adds the given <paramref name="episodeIdsWithMetadataCollectedAt"/> collection to the builder.</summary>
        /// <param name="episodeIdsWithMetadataCollectedAt">A collection of <see cref="CollectedEntryWithMetadata{ITraktEpisodeIds}"/>s which will be added.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktSyncCollectionPostBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="episodeIdsWithMetadataCollectedAt"/> is null.</exception>
        ITraktSyncCollectionPostBuilder WithEpisodesWithMetadataAndCollectedAt(IEnumerable<CollectedEntryWithMetadata<ITraktEpisodeIds>> episodeIdsWithMetadataCollectedAt);

        /// <summary>Creates a new <see cref="ITraktSyncCollectionPost" /> instance with the added movies, shows, seasons and episodes.</summary>
        /// <returns>A new <see cref="ITraktSyncCollectionPost" /> instance with the added movies, shows, seasons and episodes.</returns>
        ITraktSyncCollectionPost Build();
    }
}
