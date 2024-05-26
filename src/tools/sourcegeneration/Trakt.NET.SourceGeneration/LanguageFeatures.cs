using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    // Fix for error "CS0518 Predefined type 'System.Runtime.CompilerServices.IsExternalInit' is not defined or imported"
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class IsExternalInit { }

    // Fix for error "CS0656 Missing compiler required member 'System.Runtime.CompilerServices.RequiredMemberAttribute..ctor'"
    [AttributeUsage(AttributeTargets.All)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RequiredMemberAttribute : Attribute { }

    // Fix for error "CS0656 Missing compiler required member 'System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute..ctor'"
    [AttributeUsage(AttributeTargets.All)]
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS9113 // Parameter is unread.
    public class CompilerFeatureRequiredAttribute(string name) : Attribute { }
#pragma warning restore CS9113 // Parameter is unread.
}

namespace System.Diagnostics.CodeAnalysis
{
    // Fix for error "CS0656 Missing compiler required member 'System.Diagnostics.CodeAnalysis.SetsRequiredMemberAttribute..ctor'"
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class SetsRequiredMembersAttribute : Attribute { }
}
