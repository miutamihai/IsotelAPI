using GraphQL.Types;
using IsotelBusinessLayer.GraphQLEntities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class OccupyRentMutation : ObjectGraphType<object>
    {
        public OccupyRentMutation()
        {
            Name = "OccupyRentMutation";
            Field<MutationResultType>(
                "occupyRent",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "username" },
                    new QueryArgument<StringGraphType> { Name = "userPhoneNumber" }
                    ),
                resolve: context =>
                {
                    int rentId = context.GetArgument<int>("id");
                    string username = context.GetArgument<string>("username");
                    string userPhoneNumber = context.GetArgument<string>("userPhoneNumber");
                    try
                    {
                        QueryResolver.OccupyRent(rentId, username, userPhoneNumber);
                        return new MutationStatusType
                        {
                            Success = true,
                            Operation = "Occupied rent with id " + rentId
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
