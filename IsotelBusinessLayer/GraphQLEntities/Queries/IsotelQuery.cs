using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsotelBusinessLayer.GraphQLEntities.Types;

namespace IsotelBusinessLayer.GraphQLEntities.Queries
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
            Field<LandlordType>("landlord",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => QueryResolver.GetLandlord(context.GetArgument<int>("id"))
                );
            Field<ListGraphType<CityType>>("cities",
                resolve: context => QueryResolver.GetCities()
                );
            Field<ListGraphType<RentType>>("rents_for_landlord",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => QueryResolver.GetRentsForLandlord(context.GetArgument<int>("id"))
               );
            Field<ListGraphType<RentType>>("available_rents",
                resolve: context => QueryResolver.GetAvailableRents()
                );
            Field<ListGraphType<RentType>>("rents_for_city",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => QueryResolver.GetRentsForCity(context.GetArgument<int>("id"))
                );
        }
    }
}
