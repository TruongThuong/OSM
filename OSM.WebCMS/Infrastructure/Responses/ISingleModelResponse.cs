namespace OSM.WebCMS.Infrastructure.Responses
{
    public interface ISingleModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
