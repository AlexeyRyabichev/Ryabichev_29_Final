using System;

namespace ErrorsLib
{
    public class GraphException : Exception
    {
        public GraphException(Exception exception) : base(null, exception) { }

        public GraphException(string message) : base(message) { }
    }
}