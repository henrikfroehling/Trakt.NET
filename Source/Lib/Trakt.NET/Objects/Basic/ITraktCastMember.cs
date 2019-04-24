namespace TraktNet.Objects.Basic
{
    using Get.People;

    /// <summary>A Trakt cast member.</summary>
    public interface ITraktCastMember
    {
        /// <summary>Gets or sets the character name of the cast member.<para>Nullable</para></summary>
        string Character { get; set; }

        /// <summary>Gets or sets the cast member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        ITraktPerson Person { get; set; }
    }
}
