using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.Dtos
{
    public class SearchAuditLogModel
    {
        /// <summary>
        /// Kaçıncı sayfanın açılacağını gösterir
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Kaç adet işlem geçmişinin gösterileceğini belirtir
        /// </summary>
        [JsonProperty("pageItemCount")]
        public int PageItemCount { get; set; } = 10;

        /// <summary>
        /// İşlem geçmişinin hangi tarihten itibaren alınacağını belirtir
        /// </summary>
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// İşlem geçmişinin hangi tarihe kadar alınacağını belirtir
        /// </summary>
        [JsonProperty("endDate")]
        public string EndDate { get; set; }

     

        /// <summary>
        /// Aranacak denetim logunun id'si
        /// </summary>
        [JsonProperty("auditLogId")]
        public string AuditLogId { get; set; }

        /// <summary>
        /// Aranacak denetim logunun açıklaması
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Aranacak denetim logunun ip'si
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }


        /// <summary>
        /// Aranacak denetim logundan etkilenenin id'si
        /// </summary>
        [JsonProperty("effectedId")]
        public string EffectedId { get; set; }



    }
}
