namespace TraktApiSharp.Example.UWP.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class PaginationList<T> : IEnumerable<T>
    {
        public List<T> Items { get; set; }

        public int? CurrentPage { get; set; }

        public int? LimitPerPage { get; set; }

        public int? TotalPages { get; set; }

        public int? TotalItemCount { get; set; }

        public int? TotalUserCount { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items?.GetEnumerator();
        }
    }
}
