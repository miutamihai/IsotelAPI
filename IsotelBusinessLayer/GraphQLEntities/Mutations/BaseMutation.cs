using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Mutations
{
    public class BaseMutation : ObjectGraphType<object>
    {
        public BaseMutation(List<ObjectGraphType<object>> mutationClasses)
        {
            foreach (var mutationClass in mutationClasses)
            {
                foreach (var field in mutationClass.Fields)
                {
                    AddField(field);
                }
            }
        }
    }
}
