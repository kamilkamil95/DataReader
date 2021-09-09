using System.Threading.Tasks;

namespace DataReader.DataAccess
{
    interface IHttpClientCommunicator
    {
        Task<string> GetDataAsync();
    }
}