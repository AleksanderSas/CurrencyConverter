using System.ServiceModel;
using System.Threading.Tasks;

namespace Client.Services
{
    class CurrencyConverterService : ICurrencyConverterService
    {
        public async Task<string> Convert(string input)
        {
            try
            {
                CurrencyWebService.ICurrencyConverter converter = new CurrencyWebService.CurrencyConverterClient();
                var result = await converter.ConvertAsync(input);
                if (string.IsNullOrEmpty(result.ErrorMessage))
                {
                    return result.Result;
                }
                throw new ClientException(result.ErrorMessage);
            }catch(CommunicationException)
            {
                throw new ClientException("Connection error");
            }
        }
    }
}
