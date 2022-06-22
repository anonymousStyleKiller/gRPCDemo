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
}