using System;

namespace CompanyName.ProjectName.Domain.Exceptions
{
    public class UnsupportedColourException : Exception
    {
        public UnsupportedColourException(string code) : base($"Colour \"{code}\" is unsupported.")
        {
        }
    }
}
