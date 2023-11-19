using Microsoft.EntityFrameworkCore;
using Sieve.Models;

namespace Core.Shared
{
    public class PagedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        private PagedList()
        {
        }

        private PagedList(
            IEnumerable<T> items,
            int count,
            int pageNumber,
            int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            Items = items;
        }

        public static PagedList<T> Copy<TIn>(
            PagedList<TIn> pagedList,
            IEnumerable<T> mappedModels)
        {
            return new PagedList<T>
            {
                Items = mappedModels,
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount
            };
        }

        public static async Task<PagedList<T>> ToPagedListAsync(
            IQueryable<T> source,
            SieveModel sieveModel)
        {
            var count = source.Count();

            sieveModel.Page ??= 1;
            sieveModel.PageSize ??= 10;

            var items = await source
                .Skip((sieveModel.Page!.Value - 1) * sieveModel.PageSize!.Value)
                .Take(sieveModel.PageSize.Value)
                .ToListAsync();

            return new PagedList<T>(items, count, sieveModel.Page.Value, sieveModel.PageSize.Value);
        }
    }
}
