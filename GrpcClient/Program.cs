// See https://aka.ms/new-console-template for more information


// using Grpc.Net.Client;
// using GrpcServer;
//
// var input = new HelloRequest { Test = "Grpc "};
// var channel = GrpcChannel.ForAddress("https://localhost:7100");
// var client = new Greeter.GreeterClient(channel);
//
// var reply = await client.SayHelloAsync(input);


using Grpc.Net.Client;
using GrpcServer;

var channel = GrpcChannel.ForAddress("https://localhost:7100");
var client = new Customer.CustomerClient(channel);
// var clientRequested = new CustomerLookupModel { UserId = 2 };
// var reply = await client.GetCustomerInfoAsync(clientRequested);

using var call = client.GetNewCustomers(new NewCustomerRequest());
while (await call.ResponseStream.MoveNext(CancellationToken.None))
{
    var currentCustomer = call.ResponseStream.Current;
    Console.WriteLine($"Customer {currentCustomer.FirstName}, {currentCustomer.SecondName}");
}