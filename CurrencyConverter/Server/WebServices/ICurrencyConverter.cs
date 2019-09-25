using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface ICurrencyConverter
    {
        
        [OperationContract]
        RequestResult Convert(string input);
    }
}
