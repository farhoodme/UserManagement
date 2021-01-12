using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManagement
{
    public class PagedResultDto<T> : List<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public PagedResultDto(int count, List<T> items)
        {
            TotalCount = count;
            Items = items;
        }

        public static PagedResultDto<T> ToPagedList(IEnumerable<T> source, int skipCount, int maxResultCount)
        {
            var count = source.Count();
            var items = source.Skip(skipCount).Take(maxResultCount).ToList();

            return new PagedResultDto<T>(count, items);
        }
    }
}
