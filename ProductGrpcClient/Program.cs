using Grpc.Core;
using Grpc.Net.Client;
using ProductGrpc.Protos;

Console.WriteLine("Waiting for server...");
Thread.Sleep(2000);

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new ProductProtoService.ProductProtoServiceClient(channel);

await GetProductAsync(client);
await GetAllProducts(client);


Console.ReadLine();


static async Task GetProductAsync(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("GetProductAsync started...");
    var response = await client.GetProductAsync(new GetProductRequest { ProductId = 1 });
    Console.WriteLine("GetProductAsync Response :" + response.ToString());
}

static async Task GetAllProducts(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("GetAllProducts started...");
    using (var clientData = client.GetAllProducts(new GetAllProductsRequest()))
        await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine(responseData);
        }
}

