using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppFlowerBouquet.Helper
{
    public class PaginatedList<T>: List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRecords { get; private set; }
        public bool HasNext => CurrentPage < TotalPage;
        public bool HasPrevious => CurrentPage > 1;

        public PaginatedList(List<T> list, int totalRecords, int currentPage, int pageSize)
        {
            TotalRecords = totalRecords;
            CurrentPage = currentPage;
            TotalPage = (int) Math.Ceiling((double) totalRecords / pageSize);
            PageSize = pageSize;
            this.AddRange(list);
        }

        public static PaginatedList<T> ToPaginatedList(IEnumerable<T> source, int pageSize, int pageNumber)
        {
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, source.Count(), pageNumber, pageSize);
        }
    }
}
