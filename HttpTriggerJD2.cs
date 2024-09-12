using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization; // Add this line
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Company.Function.JD2
{

    public class Solution
{
    public string Id { get; set; }
    public string RecordType { get; set; }
    public string SolutionName { get; set; }
    public string SolutionType { get; set; }
    public List<string> Industry { get; set; }
    public string EngagementStage { get; set; }
    public string SolutionDescription { get; set; }
    public string State { get; set; }
    public List<string> OwnerGroups { get; set; }
    public List<string> ViewerGroups { get; set; }
    public string CreatedBy { get; set; }
    public long CreatedAt { get; set; }
    public string LastModifiedBy { get; set; }
    public long LastModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public string DeletedBy { get; set; }
    public long? DeletedAt { get; set; }
    public string ETag { get; set; }
}
    public class HttpTriggerJD2
    {
        private static readonly ConnectionMultiplexer redis;

         static HttpTriggerJD2()
        {
            try
            {
                redis = ConnectionMultiplexer.Connect("localhost");
            }
            catch (RedisConnectionException ex)
            {
                Console.WriteLine($"Redis connection failed: {ex.Message}");
                throw;
            }
        }

        [Function("HttpTriggerJD2")]
       public static async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger<HttpTriggerJD2>();
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await HandleRequest(req, logger);
        }

        private static async Task<HttpResponseData> HandleRequest(HttpRequestData req, ILogger logger)
        {
            var db = redis.GetDatabase();

            //check if redisKey ->"Solutions" exists if yes then do setMemeberAsync and get the solution Id
            //if not present then do setAddAsync and add the solution Id using the below logic.
            // Next solution Detail will be added the same way using solutionID as the key and values are SolutionID and 

            if (req.Method.Equals(HttpMethods.Post, System.StringComparison.OrdinalIgnoreCase))
            {  //"Solutions" {1,2,3,4};
              //Solution_1 {components,resources}

              //Solution  id
                // Read the request body
                 

                         var jsonData = jsonResponse.SolutionResponse();
                      var solutions = JsonConvert.DeserializeObject<List<Solution>>(jsonData);
                           
        // Extract all the "id" values
                        List<string> ids = new List<string>();
                         foreach (var solution in solutions)
                          {
                              ids.Add(solution.Id);
                          }
               
                     var redisKey = "Solutions"; 
                // Store the value in Redis Hash  
                     string concatenatedValue = string.Join(",", ids);
                         //write to redis
                await db.SetAddAsync(redisKey, concatenatedValue);

                // Next call to write solution Detail here
                 SolutionDetailsWrite.WriteSolutionDetailsToRedis(ids,db);

                 var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
               // await response.WriteStringAsync(JsonConvert.SerializeObject(jdata));
                return response;
            }


            else if (req.Method.Equals(HttpMethods.Get, System.StringComparison.OrdinalIgnoreCase))
            {
               string redisKey = "Solutions";
                var setEntries = await db.SetMembersAsync(redisKey);

               List<string> valueList = setEntries.SelectMany(entry => entry.ToString().Split(',')).ToList();


                    var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
                    await response.WriteStringAsync(JsonConvert.SerializeObject(valueList));
                    return response;
                
            }

            var unsupportedMethodResponse = req.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            await unsupportedMethodResponse.WriteStringAsync("Only GET and POST methods are supported.");
            return unsupportedMethodResponse;
        }
    }
}
