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
using NetTopologySuite.Operation.Buffer;
using Newtonsoft.Json.Linq;

namespace Company.Function.JD2
{

    public  class SolutionDetailsWrite{

        public static void WriteSolutionDetailsToRedis (List<string> ids,IDatabase db)
        {
            var jsonData = jsonResponse.SolutionIDResponse();
            var solutionDetails = JsonConvert.DeserializeObject<List<SolutionDetail>>(jsonData);
            foreach (var solutionDetail in solutionDetails)
            {
                var solutionId = solutionDetail.Id;
                    var solutionKey = $"solution:{solutionId}";
                    var solutionJson = JsonConvert.SerializeObject(solutionDetail);
                    db.StringSet(solutionKey, solutionJson);
                
            } 
                           
        }
    }

   // Elements that all CSA API response items share
public class BaseAdvisorItem
{
	[JsonProperty("id")]
	public string Id { get; set; }
	[JsonProperty("record_type")]
	public string RecordType { get; set; }
	[JsonProperty("created_by")]
	public string CreatedBy { get; set; }
	[JsonProperty("created_at")]
	public string CreatedAt { get; set; }
	[JsonProperty("last_modified_by")]
	public string LastModifiedBy { get; set; }
	[JsonProperty("last_modified_at")]
	public string LastModifiedAt { get; set; }
	public string _etag { get; set; }

	public BaseAdvisorItem()
	{
		Id = "";
		RecordType = "";
		CreatedBy = "";
		CreatedAt = "";
		LastModifiedBy = "";
		LastModifiedAt	= "";
		_etag = "";
	}
}

// Solution Data Model

// Solution Detail Data Model - Solution by id
public class SolutionDetail : Solution
{
	[JsonProperty("components")]
	public List<Component> Components { get; set; }
	[JsonProperty("service_connections")]
	public List<ServiceConnection> ServiceConnections { get; set; }

	public SolutionDetail() : base()
	{
		Components = new List<Component>();
		ServiceConnections = new List<ServiceConnection>();
	}
}

// Direct Child of Solution Data Model
public class SolutionChildItem : BaseAdvisorItem
{
	[JsonProperty("solution_id")]
	public string SolutionId { get; set; }
	[JsonProperty("cloud_type")]
	public string CloudType { get; set; }
	[JsonProperty("tenant_id")]
	public string TenantId { get; set; }
	[JsonProperty("tenant_name")]
	public string TenantName { get; set; }
	[JsonProperty("subscription_id")]
	public string SubscriptionId { get; set; }
	[JsonProperty("subscription_name")]
	public string SubscriptionName { get; set; }

	public SolutionChildItem() : base()
	{
		SolutionId = "";
		CloudType = "";
		TenantId = "";
		TenantName = "";
		SubscriptionId = "";
		SubscriptionName = "";
	}
}

// Component Data Model
public class Component : SolutionChildItem
{
	[JsonProperty("resource_type")]
	public string ResourceType { get; set; }
	[JsonProperty("resource_provider")]
	public string ResourceProvider { get; set; }
	[JsonProperty("degraded_threshold")]
	public float DegradedThreshold { get; set; }
	[JsonProperty("interrupted_threshold")]
	public float InterruptedThreshold { get; set; }
	[JsonProperty("service_connection_id")]
	public string ServiceConnectionId { get; set; }
	[JsonProperty("resources")]
	public List<Resource> Resources { get; set; }

	public Component() : base()
	{
		ResourceType = "";
		ResourceProvider = "";
		DegradedThreshold = 0;
		InterruptedThreshold = 0;
		ServiceConnectionId = "";
		Resources = new List<Resource>();
	}
}

// Service Connection Data Model
public class ServiceConnection : SolutionChildItem
{
	[JsonProperty("name")]
	public string Name { get; set; }
	[JsonProperty("description")]
	public string Description { get; set; }
	[JsonProperty("service_principal_id")]
	public string ServicePrincipalId { get; set; }
	[JsonProperty("secret_type")]
	public string SecretType { get; set; }
	[JsonProperty("secret_identifier")]
	public string SecretIdentifier { get; set; }

	public ServiceConnection() : base()
	{
		Name = "";
		Description = "";
		ServicePrincipalId = "";
		SecretType = "";
		SecretIdentifier = "";
	}
}

//Resource Data Model
public class Resource : BaseAdvisorItem
{
	[JsonProperty("solution_id")]
	public string SolutionId { get; set; }
	[JsonProperty("resource_group")]
	public string ResourceGroup { get; set; }
	[JsonProperty("resource_location")]
	public string ResourceLocation { get; set; }
	[JsonProperty("resource_id")]
	public string ResourceId { get; set; }
	[JsonProperty("resource_url")]
	public string ResourceUrl { get; set; }
	[JsonProperty("resource_tags")]
	public List<string> ResourceTags { get; set; }

	public Resource() : base()
	{
		SolutionId = "";
		ResourceGroup = "";
		ResourceLocation = "";
		ResourceId = "";
		ResourceUrl = "";
		ResourceTags = new List<string>();
	}

}
}