using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PNS.Log.Models.Dtos;
using PNS.Log.Models.Entities;
using PNS.Log.Services;
using PNS.Log.Services.Abstractions;
using PNS.Log.Services.Interfaces;
using System;

namespace PNS.Log.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;
        private readonly string indexName = "auditlog";

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpPost("create")]
        public IActionResult CreateAuditLog(CreateAuditLogModel auditLogDto)
        {
            var auditLog = auditLogDto.Adapt<AuditLog>();

            var response=_auditLogService.CheckExistsAndInsertLog(auditLog, indexName) ;

            return Ok(response);
        }

        [HttpPost("search")]
        public IActionResult SearchAuditLog(SearchAuditLogModel auditLogModel)
        {
            // Modelden string olarak aldığımız tarih değerlerini Datetime tipine çevirmeye çalışıyoruz, 
            // eğer çeviremezsek startdate i DateTime.MinValue veriyoruz endDate i de DateTime.MaxValue
            // veriyoruz bütün işlem geçmişini alabilmek için
            DateTime startDate;

            DateTime.TryParse(auditLogModel.StartDate, out startDate);

            DateTime endDate;

            DateTime.TryParse(auditLogModel.EndDate, out endDate);

            if (endDate == DateTime.MinValue)
            {
                endDate = DateTime.Now;
            }

            var pager = new PagingRequest(auditLogModel.Page, auditLogModel.PageItemCount);

            var response= _auditLogService.SearchAuditLogs(indexName, pager, auditLogModel.AuditLogId, auditLogModel.Description, auditLogModel.Ip, auditLogModel.EffectedId, startDate, endDate);

            return Ok(response);
        }

        [HttpPost("get")]
        public IActionResult GetAuditLogById(GetAuditLogModel auditLogDto)
        {
            var response = _auditLogService.GetLogById(auditLogDto.AuditLogId, indexName);

            return Ok(response);
        }

    }
}
