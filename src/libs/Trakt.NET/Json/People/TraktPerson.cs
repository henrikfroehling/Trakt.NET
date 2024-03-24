namespace TraktNET
{
    public class TraktPerson : TraktPersonMinimal
    {
        public TraktPersonSocialIds? SocialIds { get; set; }

        public string? Biography { get; set; }

#if NET6_0_OR_GREATER
        public DateOnly? Birthday { get; set; }
#else
        public string? Birthday { get; set; }
#endif

#if NET6_0_OR_GREATER
        public DateOnly? Death { get; set; }
#else
        public string? Death { get; set; }
#endif

        public string? Birthplace { get; set; }

        public string? Homepage { get; set; }

        public TraktKnownForDepartment? KnownForDepartment { get; set; }

        public TraktGender? Gender { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
