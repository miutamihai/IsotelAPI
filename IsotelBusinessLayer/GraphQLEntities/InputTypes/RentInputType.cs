using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.InputTypes
{
    public class RentInputType : InputObjectGraphType
    {
        public RentInputType()
        {
            Name = "RentInput";
            Field<NonNullGraphType<StringGraphType>>("address");
            Field<NonNullGraphType<IntGraphType>>("cityId");
            Field<NonNullGraphType<IntGraphType>>("landlordId");
            Field<NonNullGraphType<IntGraphType>>("pricePerDay");
        }
    }
}
