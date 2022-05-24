using AutoMockerExampleCore.Interfaces;

namespace AutoMockerExampleCore.Test
{
    // You might want to use a stubbed implementation sometimes. Granted, a good mocking framework like Moq means
    // you probably won’t ever need to do that, but let’s assume you don’t want to use a mock, for whatever reason.
    // So in this example, I’ve created a little stubbed version of the FooService
    public class FooServiceStub : IFooService
    {
        private int Count { get; set; }
        public void DoFooThing(int number)
        {
            Count += number;
        }
    }
}