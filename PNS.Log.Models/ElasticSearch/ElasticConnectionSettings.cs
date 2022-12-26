using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.ElasticSearch
{
    public class ElasticConnectionSettings
    {
        public string ElasticSearchHost { get; set; }
        public string ElasticLoginIndex { get; set; }
        public string ElasticErrorIndex { get; set; }
        public string ElasticAuditIndex { get; set; }
        public string ElasticUsername { get; set; }
        public string ElasticPassword { get; set; }
    }
}
