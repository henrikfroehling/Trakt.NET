namespace TraktNET.SourceGeneration.Common
{
    internal static class HashHelpers
    {
        internal static int Combine(int hash1, int hash2)
        {
            uint rotateLeft = ((uint)hash1 << 5) | ((uint)hash2 >> 27);
            return ((int)rotateLeft + hash1) ^ hash2;
        }
    }
}
