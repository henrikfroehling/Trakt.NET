namespace TraktApiSharp.Example.UWP.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class PaginationList<T> : IEnumerable<T>
    {
        public ObservableCollection<T> Items { get; set; }

        public int? CurrentPage { get; set; }

        public int? LimitPerPage { get; set; }

        public int? TotalPages { get; set; }

        public int? TotalItemCount { get; set; }

        public int? TotalUserCount { get; set; }

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}
