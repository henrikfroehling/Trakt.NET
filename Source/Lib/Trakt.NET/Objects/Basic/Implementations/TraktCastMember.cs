namespace TraktNet.Objects.Basic
{
    using Get.People;

    /// <summary>A Trakt cast member.</summary>
    public class TraktCastMember : ITraktCastMember
    {
        /// <summary>Gets or sets the character name of the cast member.<para>Nullable</para></summary>
        public string Character { get; set; }

        /// <summary>Gets or sets the cast member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        public ITraktPerson Person { get; set; }

        /// <summary>Gets a string representation of the cast member.</summary>
        /// <returns>A string representation of the cast member.</returns>
        public override string ToString()
        {
            var character = !string.IsNullOrEmpty(Character) ? Character : "charactor not set";
            var person = Person != null ? Person.ToString() : "no person set";
            return $"{character}, {person}";
        }
    }
}
