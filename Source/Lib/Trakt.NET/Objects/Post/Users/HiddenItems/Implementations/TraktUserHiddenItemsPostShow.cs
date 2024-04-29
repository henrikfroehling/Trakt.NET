﻿namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Shows;
    using System.Collections.Generic;

    /// <summary>
    /// An user hidden items post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktUserHiddenItemsPostShow : ITraktUserHiddenItemsPostShow
    {
        /// <summary>Gets or sets the title of the show.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the year of the show.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="ITraktShowIds" />.</summary>
        public ITraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserHiddenItemsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the hidden items list.
        /// Otherwise, only the specified seasons will be added to the hidden items list.
        /// </para>
        /// </summary>
        public IList<ITraktUserHiddenItemsPostShowSeason> Seasons { get; set; }
    }
}
