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
    public class ExceptionLogController : ControllerBase
    {
        private readonly IExceptionLogService _exceptionLogService;
        private readonly string indexName = "exceptionlog";


        public ExceptionLogController(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }

        [HttpPost("create")]
        public IActionResult CreateExceptionLog(CreateExceptionLogModel exceptionLogModel)
        {
            var exceptionLog = exceptionLogModel.Adapt<ExceptionLog>();

            var response=_exceptionLogService.CheckExistsAndInsertLog(exceptionLog, indexName);

            return Ok(response);
        }

        [HttpPost("search")]
        public IActionResult SearchExceptionLog(SearchExceptionLogModel exceptionLogModel)
        {
            // Modelden string olarak aldığımız tarih değerlerini Datetime tipine çevirmeye çalışıyoruz, 
            // eğer çeviremezsek startdate i DateTime.MinValue veriyoruz endDate i de DateTime.MaxValue
            // veriyoruz bütün işlem geçmişini alabilmek için
            DateTime startDate;

            DateTime.TryParse(exceptionLogModel.StartDate, out startDate);

            DateTime endDate;

            DateTime.TryParse(exceptionLogModel.EndDate, out endDate);

            if (endDate == DateTime.MinValue)
            {
                endDate = DateTime.Now;
            }

            var pager = new PagingRequest(exceptionLogModel.Page, exceptionLogModel.PageItemCount);

            var response = _exceptionLogService.SearchExceptionLogs(indexName,pager, exceptionLogModel.ExceptionLogId, exceptionLogModel.UserId, exceptionLogModel.MerchantId, 
                exceptionLogModel.ErrorCode, exceptionLogModel.ErrorMessage, exceptionLogModel.Description,startDate, endDate);

            return Ok(response);
        }


        [HttpPost("get")]
        public IActionResult GetExceptionLogById(GetExceptionLogModel exceptionLogModel)
        {
            var response = _exceptionLogService.GetLogById(exceptionLogModel.ExceptionLogId, indexName);

            return Ok(response);
        }
    }
}
