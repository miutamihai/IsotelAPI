using GraphQL.Types;
using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsotelBusinessLayer.GraphQLEntities.Types;
using IsotelBusinessLayer.GraphQLEntities.InputTypes;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class RentMutation : ObjectGraphType<object>
    {
        public RentMutation()
        {
            Name = "CreateRentMutation";
            Field<MutationResultType>(
                "createRent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RentInputType>> { Name = "rent" }
                    ),
                resolve: context =>
                {
                    var rent = context.GetArgument<Rent>("rent");
                    try
                    {
                        QueryResolver.AddRent(rent);
                        return new MutationStatusType
                        {
                            Success = true,
                            Operation = "Added rent with address " + context.GetArgument<Rent>("rent").Address
                        };
                    }
                    catch
                    {
                        return new MutationStatusType
                        {
                            Success = false,
                            Operation = ""
                        };
                    }
                });
        }
    }
}
