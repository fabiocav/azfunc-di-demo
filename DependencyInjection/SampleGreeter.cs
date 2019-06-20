namespace DependencyInjection
{
    public class SampleGreeter : IGreeter
    {
        public string CreateGreeting(string name)
        {
            return $"Hello, {name}. I'm a sample greeter.";
        }
    }
}
