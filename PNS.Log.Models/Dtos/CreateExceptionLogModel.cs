using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PNS.Log.Models.Dtos
{
    public class CreateExceptionLogModel
    {
        /// <summary>
        ///  Oluşturulacak hata logunun kullanici id 'si
        /// </summary>
        [Required(ErrorMessage = "Kullanıcı Id'si boş bırakılamaz.")]
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Oluşturulacak hata logunun üye iş yeri id'si
        /// </summary>
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

      

        /// <summary>
        /// Oluşturulacak hata logunun hata kodu
        /// </summary>
        [Required(ErrorMessage = "Hata Kodu boş bırakılamaz.")]
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Oluşturulacak hata logunun hata mesajı
        /// </summary>
        [Required(ErrorMessage = "Hata Mesajı boş bırakılamaz.")]
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Oluşturulacak hata logunun açıklaması
        /// </summary>
        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
