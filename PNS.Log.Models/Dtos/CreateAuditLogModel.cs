using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PNS.Log.Models.Dtos
{
    public class CreateAuditLogModel
    {
        /// <summary>
        /// Oluşturulacak denetim logunun descriptionu
        /// </summary>
        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Oluşturulacak denetim logunun ip'si
        /// </summary>
        [Required(ErrorMessage = "Ip Adresi boş bırakılamaz.")]
        [JsonProperty("ip")]
        public string Ip { get; set; }


        /// <summary>
        /// Oluşturulacak denetim logunun etkilenen kullanıcı id'si
        /// </summary>
        [Required(ErrorMessage = "Etkilenen Id'si boş bırakılamaz.")]
        [JsonProperty("effectedId")]
        public string EffectedId { get; set; }

    
    }
}
