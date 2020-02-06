using System;
using System.Collections.Generic;
using System.Text;

namespace OneDimensionalArray
{
    class SizeException : ArgumentException
    {
        public SizeException(string str, Exception inner) : base(str, inner) { }
        public SizeException(string message) : base(message) { }
    }
}
