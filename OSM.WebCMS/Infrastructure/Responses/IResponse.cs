using System;

namespace OSM.WebCMS.Infrastructure.Responses
{
    public interface IResponse
    {
        string Message { get; set; }

        bool DidError { get; set; }

        string ErrorMessage { get; set; }
    }
}
