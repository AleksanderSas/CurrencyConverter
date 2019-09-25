using System.Threading.Tasks;

namespace Client.Services
{
    interface ICurrencyConverterService
    {
        Task<string> Convert(string input);
    }
}
