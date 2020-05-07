using GraphQL.Types;
using IsotelBusinessLayer.GraphQLEntities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class DeleteLandlord : ObjectGraphType<object>
    {
        public DeleteLandlord()
        {
            Name = "DeleteLandlordMutation";
            Field<MutationResultType>(
                "deleteLandlord",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id"}
                    ),
                resolve: context =>
                {
                    int landlordId = context.GetArgument<int>("id");
                    try
                    {
                        QueryResolver.DeleteLandlord(landlordId);
                        return new MutationStatusType
                        {
                            Success = true,
                            Operation = "Deleted landlord with id " + landlordId
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
