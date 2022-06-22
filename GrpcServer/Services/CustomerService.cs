using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services;

public class CustomerService : Customer.CustomerBase
{
    public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
        var output = new CustomerModel
        {
            FirstName = request.UserId.Equals(1) ? "Anton" : "Sasha",
            SecondName = "Myrad"
        };

        return  Task.FromResult(output);
    }

    public override async Task GetNewCustomers(
        NewCustomerRequest request, 
        IServerStreamWriter<CustomerModel> responseStream, 
        ServerCallContext context)
    {
        List<CustomerModel> customer = new()
        {
            new CustomerModel
            {
                FirstName = "Anton",
                SecondName = "Kharchenko"
            },
            new CustomerModel
            {
                FirstName = "Tim",
                SecondName = "Corey"
            },
        };

        foreach (var cust in customer)
        {
          await  responseStream.WriteAsync(cust);
        }
    }
}