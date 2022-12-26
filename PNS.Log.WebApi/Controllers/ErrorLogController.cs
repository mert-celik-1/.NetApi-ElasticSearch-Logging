using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PNS.Log.Models.Dtos;
using PNS.Log.Models.Entities;
using PNS.Log.Services.Abstractions;
using PNS.Log.Services.Interfaces;
using System;

namespace PNS.Log.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorLogController : ControllerBase
    {
        private readonly IErrorLogService _errorLogService;
        private readonly string indexName = "errorlog";


        public ErrorLogController(IErrorLogService errorLogService)
        {
            _errorLogService = errorLogService;
        }

        [HttpPost("create")]
        public IActionResult CreateErrorLog(CreateErrorLogModel errorLogModel)
        {
            var errorLog = errorLogModel.Adapt<ErrorLog>();

            var response=_errorLogService.CheckExistsAndInsertLog(errorLog, indexName);

            return Ok(response);
        }

        [HttpPost("search")]
        public IActionResult SearchErrorLog(SearchErrorLogModel errorLogModel)
        {
            // Modelden string olarak aldığımız tarih değerlerini Datetime tipine çevirmeye çalışıyoruz, 
            // eğer çeviremezsek startdate i DateTime.MinValue veriyoruz endDate i de DateTime.MaxValue
            // veriyoruz bütün işlem geçmişini alabilmek için
            DateTime startDate;

            DateTime.TryParse(errorLogModel.StartDate, out startDate);

            DateTime endDate;

            DateTime.TryParse(errorLogModel.EndDate, out endDate);

            if (endDate == DateTime.MinValue)
            {
                endDate = DateTime.Now;
            }

            var pager = new PagingRequest(errorLogModel.Page, errorLogModel.PageItemCount);

            var response = _errorLogService.SearchErrorLogs(indexName, pager, errorLogModel.ErrorLogId, errorLogModel.UserId, errorLogModel.MerchantId,
                errorLogModel.ErrorCode, errorLogModel.ErrorMessage, startDate, endDate);

            return Ok(response);
        }


    

    }
}
