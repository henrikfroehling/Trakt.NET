﻿namespace TraktNet.Objects.Get.People.Credits
{
    using System.Collections.Generic;

    /// <summary>A collection of crew positions in different categories, which a Trakt person has.</summary>
    public interface ITraktPersonMovieCreditsCrew
    {
        /// <summary>
        /// Gets or sets a list of crew positions in the production category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Production { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the art category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Art { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Crew { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the costume and make-up category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> CostumeAndMakeup { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the directing category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Directing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the writing category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Writing { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the sound category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Sound { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the camera category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Camera { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the lighting category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Lighting { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the visual effects category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> VisualEffects { get; set; }

        /// <summary>
        /// Gets or sets a list of crew positions in the editing category. See also <seealso cref="ITraktPersonMovieCreditsCrewItem" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPersonMovieCreditsCrewItem> Editing { get; set; }
    }
}
