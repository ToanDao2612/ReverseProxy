using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Core.Services
{
    public interface IJsonConvertor
    {
        public T ConvertToClass<T>(string data);
        public string ConvertToJson(object data);
    }
}
