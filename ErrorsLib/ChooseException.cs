using System;

namespace ErrorsLib
{
    public class ChooseException : Exception
    {
        public ChooseException(string message = "Choose columns firstly") : base(message) { }
    }
}
