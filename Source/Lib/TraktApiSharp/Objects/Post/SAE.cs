namespace TraktApiSharp.Objects.Post
{
    using Utils;

    public sealed class SAE : Pair<int, int[]>
    {
        public SAE(int number, int[] episodes)
        {
            First = number;
            Second = episodes;
        }

        public int Number
        {
            get { return First; }
            set { First = value; }
        }

        public int[] Episodes
        {
            get { return Second; }
            set { Second = value; }
        }
    }
}
