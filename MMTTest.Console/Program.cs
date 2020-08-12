using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MMTTest.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<IApiCaller, ApiCaller>();
                }).UseConsoleLifetime();
            var host = builder.Build();

            using var serviceScope = host.Services.CreateScope();
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var apiCaller = services.GetRequiredService<IApiCaller>();

                    System.Console.WriteLine("1a. Featured products");
                    System.Console.WriteLine();
                    System.Console.WriteLine("SKU   Name    Description     Price");
                    var products = await apiCaller.FeaturedProducts();
                    foreach (var product in products)
                    {
                        System.Console.WriteLine($"{product.Sku}    {product.Name}  {product.Description}   {product.Price:0:c}");
                    }
                    System.Console.WriteLine();

                    System.Console.WriteLine("1b. Available categories");
                    System.Console.WriteLine();
                    var categories = await apiCaller.AvailableCategories();
                    foreach (var category in categories)
                    {
                        System.Console.WriteLine(category);
                    }
                    System.Console.WriteLine();

                    System.Console.WriteLine("1c. Products by category");
                    System.Console.WriteLine("Enter one of the above categories");
                    var categoryName = System.Console.ReadLine();
                    System.Console.WriteLine("SKU   Name    Description     Price");
                    var catProducts = await apiCaller.ProductsByCategory(categoryName);
                    foreach (var product in catProducts)
                    {
                        System.Console.WriteLine($"{product.Sku}    {product.Name}  {product.Description}   {product.Price:0:c}");
                    }
                    System.Console.WriteLine();
                    System.Console.WriteLine("SKU   Name    Description     Price");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
