using GraphQL.Types;
using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities
{
    public class LandlordMutation : ObjectGraphType<object>
    {
        public LandlordMutation()
        {
            Name = "CreateLandlordMutation";
            Field<LandlordType>(
                "createLandlord",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LandlordInputType>> { Name = "landlord"}
                ),
                resolve: context => {
                    var landlord = context.GetArgument<Landlord>("landlord");
                    return QueryResolver.AddLandlord(landlord);
                });
        }
    }
}
