using avras_v2.Domain.Infrastructures.Requests;
using avras_v2.Domain.Infrastructures.Responses;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Extensions
{
    public static class Pagination
    {
        public static async Task<TResponse> GetPagedListAsync<TResponse, T>(this IQueryable<T> query, BasePagedRequest request) where TResponse : BasePagedResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();

            response.TotalPages = (int)Math.Round((decimal)count / request.PageSize, mode: MidpointRounding.ToPositiveInfinity);
            response.TotalRegisters = count;
            response.Data = await query
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

            return response;
        }
    }
}
