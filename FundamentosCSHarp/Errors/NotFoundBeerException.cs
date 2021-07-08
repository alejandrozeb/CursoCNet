using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHarp.Errors
{
    public class NotFoundBeerException: Exception
    {
        //heredamos de exception
        public NotFoundBeerException() : base() { }

        public NotFoundBeerException(string message) : base(message) { }

        public NotFoundBeerException(string message, Exception inner) : base(message ,inner) { }


    }
}
