using Nest;
using PNS.Log.Models.ElasticSearch;
using PNS.Log.Models.Entities;
using PNS.Log.Models.Entities.Common;
using PNS.Log.Services.Abstractions;
using PNS.Log.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Services
{
    public class ElasticSearchService<T> : IElasticSearchService<T> where T : BaseEntity
    {
        ElasticClientProvider _provider;
        public ElasticClient _client;
        public ElasticSearchService(ElasticClientProvider provider)
        {
            _provider = provider;
            _client = _provider.ElasticClient;
        }
        public ServiceResult CheckExistsAndInsertLog(T logModel, string indexName)
        {

            if (!_client.Indices.Exists(indexName).Exists)
            {
                var newIndexName = indexName + System.DateTime.Now.Ticks;

                var indexSettings = new IndexSettings();
                indexSettings.NumberOfReplicas = 1;
                indexSettings.NumberOfShards = 3;

                var response = _client.Indices.Create(newIndexName, index =>
                   index.Map<T>(m => m.AutoMap()
                          )
                  .InitializeUsing(new IndexState() { Settings = indexSettings })
                  .Aliases(a => a.Alias(indexName)));

            }
            logModel.Id = Guid.NewGuid().ToString();
            IndexResponse responseIndex = _client.Index<T>(logModel, idx => idx.Index(indexName));

            return ServiceResult.Success();
        }

        public ServiceResult<IReadOnlyCollection<T>> GetLogById(string id, string indexName)
        {
            var response = _client.Search<T>(e => e
          .From(0)
          .Size(1)
          .Query(q => q.MatchPhrase(m => m.Field(f => f.Id).Query(id)))
          .Index(indexName));


            return ServiceResult.Success(response.Documents);


        }
    }
}
