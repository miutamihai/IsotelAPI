using IsotelDataLayer.Models;
using IsotelBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Types;

namespace IsotelBusinessLayer.GraphQLEntities.Types
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType()
        {
            Field(x => x.CityId).Description("City Identifier");
            Field(x => x.Name).Description("Name of the city");
            Field(x => x.PhoneNumber).Description("Phone number for the city's local police department");
            Field<ListGraphType<RentType>>("Rents", resolve: context => QueryResolver.GetRentsForCity(context.Source.CityId, "USD"), description: "List all rents");
        }
    }
}
