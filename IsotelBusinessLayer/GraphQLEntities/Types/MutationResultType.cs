using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Types
{
    class MutationResultType : ObjectGraphType<MutationStatusType>
    {
        public MutationResultType()
        {
            Field(x => x.Success).Description("Success status of mutation");
            Field(x => x.Operation).Description("Operation done by mutation");
        }
    }
}
