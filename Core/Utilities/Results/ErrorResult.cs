using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {//resulttaki mesajımı gel burdan al yani içeriğini,
            //success'i ise default true vererek base classtaki succesi çalıştır dedik
        }
        public ErrorResult() : base(false)
        {//true'yu default vermiş olduk

        }
    }
}
