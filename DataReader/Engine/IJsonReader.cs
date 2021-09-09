using DataReader.DataModels.JSON;
using System.Threading.Tasks;

namespace DataReader.Engine
{
   public  interface IJsonReader
    {
        bool ReadJson();
    }
}