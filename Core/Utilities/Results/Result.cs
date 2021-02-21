using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
        //sınfıın proplarını tek tek çağırmak yerine constructor ile çağırıyoruz 
        //kişi sadece bool döndürmek isteyebilir , mesaj görmek istemeyebilir
        //proplara setter eklemeden sadece constructor içinde set edebiliyoruz
    {
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success {get;}

        public string Message { get; }
    }
}
