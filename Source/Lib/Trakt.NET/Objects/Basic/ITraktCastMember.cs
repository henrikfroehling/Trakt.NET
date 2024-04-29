﻿namespace TraktNet.Objects.Basic
{
    using Get.People;
    using System.Collections.Generic;

    /// <summary>A Trakt cast member.</summary>
    public interface ITraktCastMember
    {
        /// <summary>Gets or sets the characters collection of the cast member.<para>Nullable</para></summary>
        IList<string> Characters { get; set; }

        /// <summary>Gets or sets the cast member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        ITraktPerson Person { get; set; }
    }
}
