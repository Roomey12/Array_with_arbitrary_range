using System;
using System.Collections.Generic;
using System.Text;

namespace OneDimensionalArray
{
    class IndexException : ArgumentException
    {
        public IndexException(string str, Exception inner) : base(str, inner) { }
        public IndexException(string message) : base(message) { }
    }
}
