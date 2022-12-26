using PNS.Log.Models.Entities;
using PNS.Log.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Services.Interfaces
{
    public interface IExceptionLogService:IElasticSearchService<ExceptionLog>
    {
        ServiceResult<PagingResponse<ExceptionLog>> SearchExceptionLogs(string indexName, PagingRequest pagingRequest, string exceptionLogId, string userId, string merchantId, string errorCode, string errorMessage, string description, DateTime startDate, DateTime endDate);

    }
}
