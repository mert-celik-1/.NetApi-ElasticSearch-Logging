using PNS.Log.Models.Entities;
using PNS.Log.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Services.Interfaces
{
    public interface IAuditLogService : IElasticSearchService<AuditLog>
    {
        /// <summary>
        /// Denetim loglarını arar ve sayfa halinde geri döndürür.
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="auditLogId"></param>
        /// <param name="description"></param>
        /// <param name="ip"></param>
        /// <param name="transactionId"></param>
        /// <param name="createdById"></param>
        /// <param name="effectedId"></param>
        /// <param name="categoryId"></param>
        /// <param name="isActive"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        ServiceResult<PagingResponse<AuditLog>> SearchAuditLogs(string indexName,PagingRequest pagingRequest, string auditLogId, string description, string ip, string effectedId, DateTime startDate, DateTime endDate);

        public IReadOnlyCollection<AuditLog> SearchAuditLog(string indexName);

    }
}
