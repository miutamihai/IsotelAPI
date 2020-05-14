using GraphQL.Types;
using IsotelBusinessLayer.GraphQLEntities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class FreeRentMutation : ObjectGraphType<object>
    {
        public FreeRentMutation()
        {
            Name = "FreeRentMutation";
            Field<MutationResultType>(
                "freeRent",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    int rentId = context.GetArgument<int>("id");
                    try
                    {
                        QueryResolver.FreeRent(rentId);
                        return new MutationStatusType
                        {
                            Success = true,
                            Operation = "Freed up rent with id " + rentId
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
                }
                );
        }
    }
}
