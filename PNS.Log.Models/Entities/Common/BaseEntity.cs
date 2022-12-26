using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.Entities.Common
{
    public class BaseEntity
    {
        /// <summary>
        /// Log benzersiz kimlik
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Oluşturulan tarih
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
    }
}
