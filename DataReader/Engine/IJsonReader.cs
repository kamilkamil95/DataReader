using System.Threading.Tasks;

namespace DataReader.Engine
{
   public  interface IJsonReader
    {
        Task ReadJsonAsync();
    }
}