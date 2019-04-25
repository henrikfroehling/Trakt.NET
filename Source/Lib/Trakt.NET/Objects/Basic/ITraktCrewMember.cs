namespace TraktNet.Objects.Basic
{
    using Get.People;

    /// <summary>A Trakt crew member.</summary>
    public interface ITraktCrewMember
    {
        /// <summary>Gets or sets the job name of the crew member.<para>Nullable</para></summary>
        string Job { get; set; }

        /// <summary>Gets or sets the crew member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        ITraktPerson Person { get; set; }
    }
}
