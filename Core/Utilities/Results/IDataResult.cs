using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //burada hem datamın dönsün, hem işlem sonucu hem de işlem mesajı tutulsun istiyoruz
        //ama zaten işlem sonucunu ve işlem mesajının  tutan interface olduğu  için
        //tekrar yazmak yerine oradan alıyoruz.
        //generic yapı ürün olur, ürünler olur(list) gibi
        T Data { get; }
    }
}
