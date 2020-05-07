using GraphQL.Types;
using IsotelBusinessLayer.GraphQLEntities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class DeleteRent : ObjectGraphType<object>
    {
        public DeleteRent()
        {
            Name = "DeleteRentMutation";
            Field<MutationResultType>(
                "deleteRent",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    int rentId = context.GetArgument<int>("id");
                    try
                    {
                        QueryResolver.DeleteRent(rentId);
                        return new MutationStatusType
                        {
                            Success = true,
                            Operation = "Deleted rent with id " + rentId
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
