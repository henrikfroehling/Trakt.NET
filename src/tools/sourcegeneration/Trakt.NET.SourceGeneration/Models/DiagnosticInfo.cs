using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Models
{
    public readonly struct DiagnosticInfo : IEquatable<DiagnosticInfo>
    {
        public DiagnosticDescriptor Descriptor { get; private init; }

        public Location? Location { get; private init; }

        public static DiagnosticInfo Create(DiagnosticDescriptor descriptor, Location? location)
        {
            Location? trimmedLocation = location == null ? null : GetTrimmedLocation(location);

            return new DiagnosticInfo
            {
                Descriptor = descriptor,
                Location = location
            };

            static Location? GetTrimmedLocation(Location location)
                => Location.Create(location.SourceTree?.FilePath ?? string.Empty, location.SourceSpan, location.GetLineSpan().Span);
        }

        public Diagnostic CreateDiagnostic() => Diagnostic.Create(Descriptor, Location);

        public override bool Equals(object obj) => obj is DiagnosticInfo diagnosticInfo && Equals(diagnosticInfo);

        public bool Equals(DiagnosticInfo other) => Descriptor.Equals(other.Descriptor) && Location == other.Location;

        public override int GetHashCode()
        {
            int hashCode = Descriptor.GetHashCode();
            return HashHelpers.Combine(hashCode, Location?.GetHashCode() ?? 0);
        }

        public static bool operator ==(DiagnosticInfo left, DiagnosticInfo right) => left.Equals(right);

        public static bool operator !=(DiagnosticInfo left, DiagnosticInfo right) => !(left == right);
    }
}
