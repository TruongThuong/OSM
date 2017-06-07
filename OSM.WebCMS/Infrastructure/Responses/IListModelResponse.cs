using System;
using System.Collections.Generic;

namespace OSM.WebCMS.Infrastructure.Responses
{
    public interface IListModelResponse<TModel> : IResponse
    {
        int PageSize { get; set; }
        int TotalRows { get; set; }

        int PageNumber { get; set; }

        int TotalPages { get; set; }

        IEnumerable<TModel> Model { get; set; }
    }
}
