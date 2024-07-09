using PersonsApi.DTOs;

namespace PersonsApi.Repositories;

public static class CreatePagination
{
    public static Pagination<T> ToPagination<T>(this IEnumerable<T> list, PaginationParam paginationParams)
    {
         var result = list.Skip(paginationParams.Page * paginationParams.PerPage)
            .Take(paginationParams.PerPage);
        return new Pagination<T>
        {
            PerPage = paginationParams.PerPage,
            Page = paginationParams.Page,
            TotalCount = result.Count(),
            Items = result.ToList()
        };
    }
}