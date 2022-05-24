using AutoMockerExampleCore.Interfaces;

namespace AutoMockerExampleCore.Services
{
    public class SomeOtherService : ISomeOtherService
    {
        public int GetSomeValue(string item)
        {
            if (item == null)
            {
                return 0;
            }
            
            // Some sort of business logic...
            var result = item.Length * item.Length + 1;
            return result;
        }
    }
}