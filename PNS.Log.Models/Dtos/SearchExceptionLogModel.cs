using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.Dtos
{
    public class SearchExceptionLogModel
    {
        /// <summary>
        /// Kaçıncı sayfanın açılacağını gösterir
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

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
        /// Kaç adet işlem geçmişinin gösterileceğini belirtir
        /// </summary>
        [JsonProperty("pageItemCount")]
        public int PageItemCount { get; set; } = 10;

        /// <summary>
        /// Aranacak hata logunun id'si
        /// </summary>
        [JsonProperty("exceptionLogId")]
        public string ExceptionLogId { get; set; }

        /// <summary>
        /// Aranacak hata logunun kullanici id'si
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Aranacak hata logunun üye iş yeri id'si
        /// </summary>
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Aranacak hata logunun hata kodu
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Aranacak hata logunun hata mesajı
        /// </summary>
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Aranacak hata logunun açıklaması
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
