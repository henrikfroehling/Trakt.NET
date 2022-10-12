namespace TraktNet.PostBuilder
{
    using System;

    internal static class PostBuilderUtility
    {
        internal static void CheckNotes(string notes)
        {
            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes));
        }
    }
}
