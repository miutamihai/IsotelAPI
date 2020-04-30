using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities
{
    public class IsotelQuery : ObjectGraphType
    {
        public IsotelQuery()
        {
            Field<CityType>("city",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
                resolve: context => QueryResolver.GetCity(context.GetArgument<int>("id"))
                );
            Field<RentType>("rent",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => QueryResolver.GetRent(context.GetArgument<int>("id"))
                );
            Field<CityType>("landlord",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => QueryResolver.GetLandlord(context.GetArgument<int>("id"))
                );
        }
    }
}
