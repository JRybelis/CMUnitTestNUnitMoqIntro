using AutoMockerExampleCore.Interfaces;

namespace AutoMockerExampleCore.Test
{
    public class FooServiceStub : IFooService
    {
        private int Count { get; set; }
        public void DoFooThing(int number)
        {
            Count += number;
        }
    }
}