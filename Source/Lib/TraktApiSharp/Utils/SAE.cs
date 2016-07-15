namespace TraktApiSharp.Utils
{
    public sealed class SAE : Pair<int, int[]>
    {
        public SAE(int season, int[] episodes)
        {
            First = season;
            Second = episodes;
        }

        public int Season
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
