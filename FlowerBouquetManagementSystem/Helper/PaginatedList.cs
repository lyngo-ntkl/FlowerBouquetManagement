using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerBouquetManagementSystemWebApp.Helper
{
    public class PaginatedList<T>: List<T> 
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalObjects { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PaginatedList(List<T> list, int totalObjects, int pageNumber, int pageSize)
        {
            TotalObjects = totalObjects;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling((double) totalObjects / pageSize);
            AddRange(list);
        }

        public static PaginatedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize) 
        { 
            var totalObjects = source.Count();
            var list = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(list, totalObjects, pageNumber, pageSize);
        }
    }
}
