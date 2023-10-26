using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetStore;
using PetStore.data;
using PetStore.Logic;
using PetStore.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var services = CreateServiceCollection();

var productLogic = services.GetService<IProductLogic>();

string userInput = DisplayMenuAndGetInput();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a product in JSON format");
        var userInputAsJson = Console.ReadLine();
        //need to fix dogleash var?
        var dogLeash = JsonSerializer.Deserialize<ProductEntity>(userInputAsJson);
        productLogic.AddProduct(dogLeash);
    }
    if (userInput == "2")
    {
        Console.Write("What is the id of the product you would like to view? ");
        var success = int.TryParse(Console.ReadLine(), out int id);
        if (!success) continue;
        var dogLeash = productLogic.GetProductById(id);
        Console.WriteLine(JsonSerializer.Serialize(id));
        Console.WriteLine();
    }
   
    userInput = DisplayMenuAndGetInput();
}

static string DisplayMenuAndGetInput()
{
    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a product");
    Console.WriteLine("Type 'exit' to quit");

    return Console.ReadLine();
}

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .AddTransient<IProductRepository, ProductRepository>()
        .BuildServiceProvider();
}