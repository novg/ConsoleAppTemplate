using System.Linq;
using ConsoleAppTemplate.Contracts;

namespace ConsoleAppTemplate.Services
{
    public class BarService : IBarService
    {
        private readonly IFooService _fooService;

        public BarService(IFooService fooService)
        {
            _fooService = fooService;
        }

        public void DoSomeRealWork()
        {
            Enumerable.Range(0, 10).ToList()
                .ForEach(i => _fooService.DoThing(i));
        }
    }
}