using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PNS.Log.Models.Dtos
{
    public class GetAuditLogModel
    {
        /// <summary>
        /// Çekilecek denetim logunun id'si
        /// </summary>
        [Required(ErrorMessage = "Denetim Logu Id'si boş bırakılamaz.")]
        [JsonProperty("auditLogId")]
        public string AuditLogId { get; set; }
    }
}
