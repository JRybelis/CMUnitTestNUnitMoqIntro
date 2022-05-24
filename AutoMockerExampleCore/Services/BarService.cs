using AutoMockerExampleCore.Interfaces;

namespace AutoMockerExampleCore.Services
{
    public class BarService : IBarService
    {
        private readonly IFooService _fooService;
        private readonly ISomeOtherService _someOtherService;

        public BarService(IFooService fooService, ISomeOtherService someOtherService)
        {
            _fooService = fooService;
            _someOtherService = someOtherService;
        }

        public void DoBarThing()
        {
            for (var i = 0; i < 10; i++)
            {
                _fooService.DoFooThing(i);
            }
        }

        public int DoOtherThing(string item)
        {
            var result = _someOtherService.GetSomeValue(item);
            return result;
        }
    }
}