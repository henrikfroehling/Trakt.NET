namespace TraktApiSharp.Objects.Basic
{
    using Get.People;
    using Newtonsoft.Json;

    /// <summary>A Trakt crew member.</summary>
    public class TraktCrewMember
    {
        /// <summary>Gets or sets the job name of the crew member.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        /// <summary>Gets or sets the crew member. See also <seealso cref="TraktPerson" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }

        public override string ToString()
        {
            var job = !string.IsNullOrEmpty(Job) ? Job : "job not set";
            var person = Person != null ? Person.ToString() : "no person set";
            return $"{job}, {person}";
        }
    }
}
