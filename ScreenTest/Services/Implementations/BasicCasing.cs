using ScreenTest.Services.Contracts;

namespace ScreenTest.Services.Implementations
{
    public class BasicCasing : ICasing
    {
        public string ChangeCasing(string input, string caseFormat)
        {
            if (caseFormat == "UpperCase")
                return input.ToUpperInvariant();
            else if (caseFormat == "LowerCase")
                return input.ToLowerInvariant();
            else
                return input;
        }
    }

}
