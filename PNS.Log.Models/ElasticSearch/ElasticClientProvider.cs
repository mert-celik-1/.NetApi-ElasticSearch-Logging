using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.ElasticSearch
{
    public class ElasticClientProvider
    {
        public ElasticClientProvider(IOptions<ElasticConnectionSettings> elasticConfig)
        {
            ElasticSearchHost = elasticConfig.Value.ElasticSearchHost;
            ElasticClient = CreateClient();
            ElasticPassword = elasticConfig.Value.ElasticPassword;
            ElasticUsername = elasticConfig.Value.ElasticUsername;
        }

        private ElasticClient CreateClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .DisableDirectStreaming(true)
                .BasicAuthentication("elastic","745896")
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false);

            return new ElasticClient(connectionSettings);
        }

        public ElasticClient CreateClientWithIndex(string defaultIndex)
        {
            var connectionSettings = new ConnectionSettings(new Uri(ElasticSearchHost))
                .DisablePing()
                .SniffOnStartup(false)
                .SniffOnConnectionFault(false)
                .DefaultIndex(defaultIndex);

            return new ElasticClient(connectionSettings);
        }

        public ElasticClient ElasticClient { get; }

        public string ElasticSearchHost { get; set; }
        public string ElasticUsername { get; set; }
        public string ElasticPassword { get; set; }
    }
}
