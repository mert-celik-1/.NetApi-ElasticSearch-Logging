using Nest;
using PNS.Log.Models.ElasticSearch;
using PNS.Log.Models.Entities;
using PNS.Log.Services.Abstractions;
using PNS.Log.Services.Interfaces;
using PNS.Log.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Services
{
    public class AuditLogService : ElasticSearchService<AuditLog>, IAuditLogService
    {
        public AuditLogService(ElasticClientProvider provider) : base(provider)
        {
        }

        public IReadOnlyCollection<AuditLog> SearchAuditLog(string indexName)
        {
            var response = _client.Search<AuditLog>(e => e
             .From(0)
             .Size(10)
             .Query(q => q.MatchPhrasePrefix(m => m.Field(f => f.Description).Query("denetim")) || q.Term(t => t.UserId, 444))

             .Index(indexName));

            return response.Documents;
        }

        public ServiceResult<PagingResponse<AuditLog>> SearchAuditLogs(string indexName, PagingRequest pagingRequest, string auditLogId, string description, string ip, string effectedId, DateTime startDate, DateTime endDate)
        {

            if (auditLogId == null) auditLogId = "";
            if (description == null) description = "";
            if (ip == null) ip = "";
            if (effectedId == null) effectedId = "";


            var response = _client.Search<AuditLog>(s => s
           .From(pagingRequest.PageSkip)
           .Size(pagingRequest.PageItemCount)
           .Sort(ss => ss.Descending(p => p.CreatedAt))
           .Query(q => q
               .Bool(b => b
                   .Must(

                       q => q.Term(t => t.Id, auditLogId.ToLower().Trim()),
                       q => q.Term(t => t.Ip, ip.ToLower().Trim()),
                        q => q.MatchPhrasePrefix(m => m.Field(f => f.EffectedId).Query(effectedId)),
                       q => q.MatchPhrasePrefix(m => m.Field(f => f.Description).Query(description)),
                        q => q.DateRange(r => r
                       .Field(f => f.CreatedAt)
                       .GreaterThanOrEquals(DateMath.Anchored(((DateTime)startDate).AddDays(0)))
                       .LessThanOrEquals(DateMath.Anchored(((DateTime)endDate).AddDays(1)))
                       ))
                    )
                 )
           .Index(indexName)
           );


            var pagingResponse = new PagingResponse<AuditLog>();

            pagingResponse.Items = response.Documents;

            pagingResponse.TotalPageCount = PagingCalculator.GetPageCount((int)response.Total, pagingRequest.PageItemCount);

            return ServiceResult.Success(pagingResponse);

        }
    }
}
