using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PNS.Log.Models.Dtos
{
    public class GetExceptionLogModel
    {
        /// <summary>
        /// Çekilecek hata logunun id'si
        /// </summary>
        [Required(ErrorMessage = "Hata Log Id'si boş bırakılamaz.")]
        [JsonProperty("exceptionLogId")]
        public string ExceptionLogId { get; set; }
    }
}
