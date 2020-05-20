using Base.Core.Services;
using Newtonsoft.Json;
using System;

namespace Json.NewtonSoft.ThirdParty
{
    public class JsonConvertor : IJsonConvertor
    {
        public T ConvertToClass<T>(string data) => JsonConvert.DeserializeObject<T>(data);
        public string ConvertToJson(object data) => JsonConvert.SerializeObject(data);
    }
}
