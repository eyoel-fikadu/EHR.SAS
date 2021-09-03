using HospitalMgt.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Common.Mapping
{
    public static class PaginetedListExtension
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, PaginatedRequest paginatedRequest)
           => PaginatedList<TDestination>.CreateAsync(queryable, paginatedRequest.PageNumber, paginatedRequest.PageSize);
    }
}
