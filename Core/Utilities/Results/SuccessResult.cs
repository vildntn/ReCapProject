using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {//resulttaki mesajımı gel burdan al içeriğini,
            //success'i ise default true vererek base classtaki succesi çalıştır dedik
        }
        public SuccessResult():base(true)
        {//true'yu default vermiş olduk

        }
        
    }
}
