using PNS.Log.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.Entities
{
    public class AuditLog: BaseEntity
    {


        /// <summary>
        /// Denetim logunun oluşturulduğu kişinin id'si
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Denetim logunun açıklaması
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Denetim logunun ip'si
        /// </summary>
        public string Ip { get; set; }


        /// <summary>
        /// Denetim logunu etkileyen kişinin id'si
        /// </summary>
        public string EffectedId { get; set; }

      

    }
}
