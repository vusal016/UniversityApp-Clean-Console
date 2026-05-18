namespace UniversityApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var app = AppBuilder.Build();
            await app.RunAsync();
        }
    }
}
