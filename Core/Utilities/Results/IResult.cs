using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için
    public interface IResult
    {//iki prop döndürsün sadece, void için yani
        //ürün eklendiğinde bool true döndürsün ve eklendi message döndürsün
        bool Success { get; }
        string Message { get; }
    }
}
