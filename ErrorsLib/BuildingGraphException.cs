﻿using System;

namespace ErrorsLib
{
    public class BuildingGraphException : GraphException
    {
        public BuildingGraphException(string message = "Some of elements are null") : base(message) { }
    }
}