using System.Threading.Tasks;

namespace DataReader.DataAccess
{
   public interface IHttpClientCommunicator
    {
        Task<string> GetDataAsync();
    }
}