using System.ServiceModel;

namespace CurrencyService
{
    [ServiceContract]
    public interface ICurrencyConverter
    {
        
        [OperationContract]
        RequestResult Convert(string input);
    }
}
