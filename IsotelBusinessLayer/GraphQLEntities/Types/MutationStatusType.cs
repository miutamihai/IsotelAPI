using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Types
{
    public class MutationStatusType
    {
        public string Operation { get; set; }
        public bool Success { get; set; }
    }
}
