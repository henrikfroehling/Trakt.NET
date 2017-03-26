namespace TraktApiSharp.Objects.Basic.Implementations
{
    using Get.People;
    using Newtonsoft.Json;

    /// <summary>A Trakt cast member.</summary>
    public class TraktCastMember : ITraktCastMember
    {
        /// <summary>Gets or sets the character name of the cast member.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        /// <summary>Gets or sets the cast member. See also <seealso cref="ITraktPerson" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "person")]
        public ITraktPerson Person { get; set; }

        public override string ToString()
        {
            var character = !string.IsNullOrEmpty(Character) ? Character : "charactor not set";
            var person = Person != null ? Person.ToString() : "no person set";
            return $"{character}, {person}";
        }
    }
}
