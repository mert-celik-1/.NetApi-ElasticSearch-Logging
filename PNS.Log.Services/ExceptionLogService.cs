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
    public class ExceptionLogService : ElasticSearchService<ExceptionLog>, IExceptionLogService
    {
        public ExceptionLogService(ElasticClientProvider provider) : base(provider)
        {
        }

        public ServiceResult<PagingResponse<ExceptionLog>> SearchExceptionLogs(string indexName,PagingRequest pagingRequest, string exceptionLogId, string userId, string merchantId, string errorCode, string errorMessage, string description, DateTime startDate, DateTime endDate)
        {
            if (exceptionLogId == null) exceptionLogId = "";
            if (description == null) description = "";
            if (userId == null) userId = "";
            if (merchantId == null) merchantId = "";
            if (errorCode == null) errorCode = "";
            if (errorMessage == null) errorMessage = "";

            var response = _client.Search<ExceptionLog>(s => s
         .From(pagingRequest.PageSkip)
         .Size(pagingRequest.PageItemCount)
         .Sort(ss => ss.Descending(p => p.CreatedAt))
         .Query(q => q
             .Bool(b => b
                 .Must(

                     q => q.Term(t => t.Id, exceptionLogId.ToLower().Trim()),
                     q => q.Term(t => t.ErrorCode, errorCode.ToLower().Trim()),
                     q => q.Term(t => t.ErrorMessage, errorMessage.ToLower().Trim()),
                     q => q.MatchPhrasePrefix(m => m.Field(f => f.UserId).Query(userId)),
                     q => q.MatchPhrasePrefix(m => m.Field(f => f.MerchantId).Query(merchantId)),
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

            var pagingResponse = new PagingResponse<ExceptionLog>();

            pagingResponse.Items = response.Documents;

            pagingResponse.TotalPageCount = PagingCalculator.GetPageCount((int)response.Total, pagingRequest.PageItemCount);

            return ServiceResult.Success(pagingResponse);


        }
    }
}
