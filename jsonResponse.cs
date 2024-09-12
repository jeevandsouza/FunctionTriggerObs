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

namespace Company.Function.JD2
{

    public  class jsonResponse{

        public static string SolutionResponse ()
        {
          
              string jsonResponse1 = @"
        [
            {
              'id': '93978f7b-49b4-445a-a3fb-7261356b71d5',
              'record_type': 'Solution',
              'solution_name': 'FixMe',
              'solution_type': 'Marketplace',
              'industry': ['Healthcare', 'Sovereign'],
              'engagement_stage': 'Operate',
              'solution_description': 'Some description about the solution',
              'state': 'PUBLISHED',
              'ownerGroups': ['72800b9b-3bc9-4ae9-9ae7-3f441a1aea77'],
              'viewerGroups': ['28af561a-1a0d-459b-8e3a-47d69456bc58'],
              'created_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
              'created_at': 1716392311,
              'last_modified_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
              'last_modified_at': 1716392311,
              'is_deleted': false,
              'deleted_by': '',
              'deleted_at': null,
              '_etag': '9317857e-5267-430b-b61c-0f576b180454'
            },
            {
              'id': '13978f7b-49b4-445a-a3fb-7261356b71d6',
              'record_type': 'Solution',
              'solution_name': 'FixMe2',
              'solution_type': 'Marketplace',
              'industry': ['Healthcare', 'Sovereign'],
              'engagement_stage': 'Operate',
              'solution_description': 'Some description about the solution',
              'state': 'PUBLISHED',
              'ownerGroups': ['72800b9b-3bc9-4ae9-9ae7-3f441a1aea77'],
              'viewerGroups': ['28af561a-1a0d-459b-8e3a-47d69456bc58'],
              'created_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
              'created_at': 1716392311,
              'last_modified_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
              'last_modified_at': 1716392311,
              'is_deleted': false,
              'deleted_by': '',
              'deleted_at': null,
              '_etag': '9317857e-5267-430b-b61c-0f576b180454'
            }
        ]";
            
            return jsonResponse1;
            }
       


       public static string SolutionIDResponse(){
            string jsonResponse2 = @" 
            [
            {
  'id': '1111193978f7b-49b4-445a-a3fb-7261356b71d5',
  'record_type': 'Solution',
  'solution_name': 'FixMe',
  'solution_type': 'Marketplace',
  'industry': ['Healthcare', 'Sovereign'],
  'engagement_stage': 'Operate',
  'solution_description': 'Some description about the solution',
  'state': 'PUBLISHED',
  'ownerGroups': ['72800b9b-3bc9-4ae9-9ae7-3f441a1aea77'],
  'viewerGroups': ['28af561a-1a0d-459b-8e3a-47d69456bc58'],
  'components': [
    {
      'id': '222293978f7b-49b4-445a-a3fb-7261356b71d5',
      'record_type': 'Component',
      'solution_id': '93978f7b-49b4-445a-a3fb-7261356b71d5',
      'cloud_type': 'Azure',
      'tenant_id': '7442e6fd-a2b2-4fb8-ad39-ddf74a3a2c48',
      'tenant_name': 'Contoso Tenant',
      'subscription_id': 'eebeb679-a6bb-4166-be71-8c55c06beaba',
      'subscription_name': 'Contoso Subscription',
      'resource_type': 'Microsoft.DocumentDb/databaseAccounts',
      'resource_provider': 'Microsoft.DocumentDb',
      'degraded_threshold': 90,
      'interrupted_threshold': 40,
      'service_connection_id': '87678f7b-49b4-445a-a3fb-7261356b71d5',
      'resources': [
        {
          'id': '33393978f7b-49b4-445a-a3fb-7261356b71d5',
          'record_type': 'Resource',
          'solution_id': '93978f7b-49b4-445a-a3fb-7261356b71d5',
          'resource_group': 'contoso-dev-rg',
          'resource_location': 'westus2',
          'resource_id': '/subscriptions/b7b45850-8344-4aa9-9afb-49fbfae18278/resourceGroups/agi-dev-rg/providers/Microsoft.DocumentDb/databaseAccounts/agi-dev-db',
          'resource_url': 'https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/b7b45850-8344-4aa9-9afb-49fbfae18278/resourceGroups/agi-dev-rg/providers/Microsoft.DocumentDb/databaseAccounts/agi-dev-db',
          'resource_tags': ['tag1'],
          'created_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
          'created_at': '1716392311',
          'last_modified_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
          'last_modified_at': '1716392311',
          '_etag': '9317857e-5267-430b-b61c-0f576b180454'
        }
      ],
      'created_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
      'created_at': '1716392311',
      'last_modified_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
      'last_modified_at': '1716392311',
      '_etag': '9317857e-5267-430b-b61c-0f576b180454'
    }
  ],
  'service_connections': [
    {
      'id': '44487678f7b-49b4-445a-a3fb-7261356b71d5',
      'record_type': 'ServiceConnection',
      'solution_id': '93978f7b-49b4-445a-a3fb-7261356b71d5',
      'name': 'SC-Healthcare',
      'description': 'Healthcare Subscription Service Connection',
      'cloud_type': 'Azure',
      'tenant_id': '7442e6fd-a2b2-4fb8-ad39-ddf74a3a2c48',
      'tenant_name': 'Contoso Tenant',
      'subscription_id': 'eebeb679-a6bb-4166-be71-8c55c06beaba',
      'subscription_name': 'Contoso Subscription',
      'service_principal_id': '54268f7b-49b4-445a-a3fb-7261356b71d5',
      'secret_type': 'Certificate',
      'secret_identifier': 'https://some-vault.vault.azure.net/secrets/sc-mgmt-cert/3351005297b64b9f8b1497e043103474',
      'created_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
      'created_at': '1716392311',
      'last_modified_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
      'last_modified_at': '1716392311',
      '_etag': '9317857e-5267-430b-b61c-0f576b180454'
    }
  ],
  'created_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
  'created_at': '1716392311',
  'last_modified_by': '4ddf2196-1acb-4f1d-90f8-c1b4cd81c645',
  'last_modified_at': '1716392311',
  'is_deleted': false,
  'deleted_by': '',
  'deleted_at': null,
  '_etag': '9317857e-5267-430b-b61c-0f576b180454'
}
,
      {
  'id': '555a1b2c3d4-e5f6-7890-abcd-ef1234567890',
  'record_type': 'Solution',
  'solution_name': 'FixMe',
  'solution_type': 'Marketplace',
  'industry': ['Healthcare', 'Sovereign'],
  'engagement_stage': 'Operate',
  'solution_description': 'Some description about the solution',
  'state': 'PUBLISHED',
  'ownerGroups': ['12345678-90ab-cdef-1234-567890abcdef'],
  'viewerGroups': ['abcdef12-3456-7890-abcd-ef1234567890'],
  'components': [
    {
      'id': '666a2b3c4d5-e6f7-8901-abcd-ef2345678901',
      'record_type': 'Component',
      'solution_id': 'a1b2c3d4-e5f6-7890-abcd-ef1234567890',
      'cloud_type': 'Azure',
      'tenant_id': '8442e6fd-b3c2-4fb8-ad39-ddf74a3a2c49',
      'tenant_name': 'Contoso Tenant',
      'subscription_id': 'f1b2e679-a7cb-4266-be71-8c66d07beaba',
      'subscription_name': 'Contoso Subscription',
      'resource_type': 'Microsoft.DocumentDb/databaseAccounts',
      'resource_provider': 'Microsoft.DocumentDb',
      'degraded_threshold': 90,
      'interrupted_threshold': 40,
      'service_connection_id': 'a3b4c5d6-e7f8-9012-abcd-ef3456789012',
      'resources': [
        {
          'id': '777b1c2d3e4-f5g6-7890-abcd-ef4567890123',
          'record_type': 'Resource',
          'solution_id': 'a1b2c3d4-e5f6-7890-abcd-ef1234567890',
          'resource_group': 'contoso-dev-rg',
          'resource_location': 'westus2',
          'resource_id': '/subscriptions/c8c45850-9454-4bb9-9abc-59cbfbf28312/resourceGroups/agi-dev-rg/providers/Microsoft.DocumentDb/databaseAccounts/agi-dev-db',
          'resource_url': 'https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/c8c45850-9454-4bb9-9abc-59cbfbf28312/resourceGroups/agi-dev-rg/providers/Microsoft.DocumentDb/databaseAccounts/agi-dev-db',
          'resource_tags': ['tag1'],
          'created_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
          'created_at': '1716392312',
          'last_modified_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
          'last_modified_at': '1716392312',
          '_etag': 'a238657e-6378-541c-b71c-0f689a180455'
        }
      ],
      'created_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
      'created_at': '1716392312',
      'last_modified_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
      'last_modified_at': '1716392312',
      '_etag': 'a238657e-6378-541c-b71c-0f689a180455'
    }
  ],
  'service_connections': [
    {
      'id': '888b4c5d6e7-f8g9-0123-abcd-ef5678901234',
      'record_type': 'ServiceConnection',
      'solution_id': 'a1b2c3d4-e5f6-7890-abcd-ef1234567890',
      'name': 'SC-Healthcare',
      'description': 'Healthcare Subscription Service Connection',
      'cloud_type': 'Azure',
      'tenant_id': '8442e6fd-b3c2-4fb8-ad39-ddf74a3a2c49',
      'tenant_name': 'Contoso Tenant',
      'subscription_id': 'f1b2e679-a7cb-4266-be71-8c66d07beaba',
      'subscription_name': 'Contoso Subscription',
      'service_principal_id': 'b5c6d7e8-f9g0-1234-abcd-ef6789012345',
      'secret_type': 'Certificate',
      'secret_identifier': 'https://some-vault.vault.azure.net/secrets/sc-mgmt-cert/3351005297b64b9f8b1497e043103474',
      'created_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
      'created_at': '1716392312',
      'last_modified_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
      'last_modified_at': '1716392312',
      '_etag': 'a238657e-6378-541c-b71c-0f689a180455'
    }
  ],
  'created_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
  'created_at': '1716392312',
  'last_modified_by': '5e6f2196-2bcd-4f1d-90f8-c1b4cd81c646',
  'last_modified_at': '1716392312',
  'is_deleted': false,
  'deleted_by': '',
  'deleted_at': null,
  '_etag': 'a238657e-6378-541c-b71c-0f689a180455'
}
      
             ] 
             ";

             return jsonResponse2;
            
       }        
    }
    
}          
    