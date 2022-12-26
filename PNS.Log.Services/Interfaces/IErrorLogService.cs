using PNS.Log.Models.Entities;
using PNS.Log.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Services.Interfaces
{
    public interface IErrorLogService : IElasticSearchService<ErrorLog>
    {
        ServiceResult<PagingResponse<ErrorLog>> SearchErrorLogs(string indexName, PagingRequest pagingRequest, string errorLogId, string userId, string merchantId, string errorCode, string errorMessage, DateTime startDate, DateTime endDate);

    }
}
