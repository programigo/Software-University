﻿using System;

namespace BashSoft.Execptions
{
    public class InvalidCommandException : Exception
    {
        public const string InvalidCommand = "The command {0} is invalid";

        public InvalidCommandException(string input) : base(string.Format(InvalidCommand, input))
        {
        }
    }
}