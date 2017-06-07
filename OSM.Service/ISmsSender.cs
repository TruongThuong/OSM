using System.Threading.Tasks;

namespace OSM.Service
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}