﻿using GraphQL.Types;
using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsotelBusinessLayer.GraphQLEntities.Types;
using IsotelBusinessLayer.GraphQLEntities.InputTypes;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class LandlordMutation : ObjectGraphType<object>
    {
        public LandlordMutation()
        {
            Name = "CreateLandlordMutation";
            Field<MutationResultType>(
                "createLandlord",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LandlordInputType>> { Name = "landlord"}
                ),
                resolve: context => {
                    var landlord = context.GetArgument<Landlord>("landlord");
                    try
                    {
                        QueryResolver.AddLandlord(landlord);
                        return new MutationStatusType
                        {
                            Success = true,
                            Operation = "Added landlord " + context.GetArgument<Landlord>("landlord").FirstName + " " + context.GetArgument<Landlord>("landlord").LastName
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
                });
        }
    }
}
