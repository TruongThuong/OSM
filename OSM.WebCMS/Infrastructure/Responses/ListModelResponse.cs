using System;
using System.Collections.Generic;

namespace OSM.WebCMS.Infrastructure.Responses
{
    public class ListModelResponse<TModel> : IListModelResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; }

        public string ErrorMessage { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }


        public IEnumerable<TModel> Model { get; set; }

        public int TotalRows { get; set; }
    }
}
