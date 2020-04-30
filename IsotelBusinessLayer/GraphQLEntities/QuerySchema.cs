using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities
{
    public class QuerySchema : Schema
    {
        public QuerySchema(IDependencyResolver resolve)
        {
            Query = resolve.Resolve<IsotelQuery>();
        }
    }
}
