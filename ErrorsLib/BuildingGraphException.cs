using System;

namespace ErrorsLib
{
    public class BuildingGraphException : Exception
    {
        public BuildingGraphException(string message = "Some of elements are null") : base(message) { }
    }
}