using PNS.Log.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNS.Log.Models.Entities
{
    public class ErrorLog : BaseEntity
    {

        /// <summary>
        /// Müşteri id'si
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Üye iş yeri id'si
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Hata kodu
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Hata mesajı
        /// </summary>
        public string ErrorMessage { get; set; }



    }
}
