﻿namespace API.Common
{
    public class PaginatedList<T>
    {
        public int TotalCount {  get; set; }

        public int Page {  get; set; }

        public int PageSize {  get; set; }

        public ICollection<T> Items { get; set; } = new List<T>();
    }
}
