using GraphQL.Types;
using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Types
{
    public class RentType : ObjectGraphType<Rent>
    {
        public RentType()
        {
            Field(x => x.RentId).Description("Rent Identifier");
            Field(x => x.Address).Description("Rent Address");
            Field(x => x.CityId).Description("Rent Location Identifier");
            Field(x => x.LandlordId).Description("Rent Owner Identifier");
            Field(x => x.PricePerDay).Description("Rent Price per Day in US Dollars");
            Field(x => x.IsAvailable).Description("Rent availability");

        }
    }
}
