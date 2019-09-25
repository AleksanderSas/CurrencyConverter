using System.Runtime.Serialization;

namespace CurrencyService
{
    [DataContract]
    public class RequestResult
    {
        [DataMember]
        public string Result { get; internal set; }

        [DataMember]
        public string ErrorMessage { get; internal set; }
    }
}
