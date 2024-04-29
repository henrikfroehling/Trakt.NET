﻿namespace TraktNet.Objects.Get.Shows
{
    using System.Collections.Generic;

    /// <summary>Represents a collection of show cast- and crew-members.</summary>
    public interface ITraktShowCastAndCrew
    {
        /// <summary>Gets or sets a list of showcast members. See also <seealso cref="ITraktShowCastMember" />.<para>Nullable</para></summary>
        IList<ITraktShowCastMember> Cast { get; set; }

        /// <summary>Gets or sets the show crew members. See also <seealso cref="ITraktShowCrew" />.<para>Nullable</para></summary>
        ITraktShowCrew Crew { get; set; }

        /// <summary>Gets or sets a list of guest stars. See also <seealso cref="ITraktShowCastMember" />.<para>Nullable</para></summary>
        IList<ITraktShowCastMember> GuestStars { get; set; }
    }
}
