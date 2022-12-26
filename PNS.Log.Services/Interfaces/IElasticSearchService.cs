using PNS.Log.Models.Entities;
using PNS.Log.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Services.Interfaces
{
    public interface IElasticSearchService<T> where T : class
    {
        public ServiceResult CheckExistsAndInsertLog(T logMode, string indexName);
        public ServiceResult<IReadOnlyCollection<T>> GetLogById(string id, string indexName);

    }
}
