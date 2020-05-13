using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using IsotelBusinessLayer.GraphQLEntities.Queries;
using IsotelBusinessLayer.GraphQLEntities.Mutations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Collections;

namespace IsotelAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("graphql")]
    public class GraphQLController : ApiController
    {
       
        public OkResult Options()
        {
            return Ok();
        }
        [System.Web.Mvc.HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] GraphQLQuery query)
        {
            var mutations = new List<ObjectGraphType<object>>
            {
                new RentMutation(),
                new LandlordMutation(),
                new DeleteLandlord(),
                new DeleteRent()
            };
            var schema = new Schema { Query = new IsotelQuery(), Mutation=new BaseMutation(mutationClasses: mutations)};
            Console.WriteLine(query.Query);
            var inputs = query.Variables.ToInputs();
            Console.WriteLine(inputs.Values);
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Inputs = inputs;
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(true);
            Console.WriteLine(result.Data);
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            
            return Ok(result);
        }
    }
}