using System.Collections.Generic;
using System.Linq;

namespace PNS.Log.Services.Abstractions
{

    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    public class ServiceError
    {
        public ServiceError(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }

        [Required]
        public string Message { get; }

        [Required]
        public int Code { get; }


        #region Errors
        public static ServiceError DefaultError => new ServiceError("Beklenmedik bir hata oluştu.", 999);

        public static ServiceError ModelStateError(string validationError)
        {
            return new ServiceError(validationError, 998);
        } // 998

        public static ServiceError ForbiddenError => new ServiceError("Bu işlemi gerçekleştirmek için yetkiniz yok.", 997);
        public static ServiceError UserNotFound => new ServiceError("Kullanıcı bulunamadı.", 100);
        public static ServiceError CategoryNotFound => new ServiceError("Kategori bulunamadı.", 101);
        public static ServiceError AuditLogNotFound => new ServiceError("Denetim Logu bulunamadı.", 102);
        public static ServiceError TransactionTypeNotFound => new ServiceError("İşlem tipi bulunamadı.", 103);
        public static ServiceError ExceptionLogNotFound => new ServiceError("Hata Logu bulunamadı.", 104);
        public static ServiceError UserLoginNotFound => new ServiceError("Kullanıcı giriş logu bulunamadı.", 105);
        public static ServiceError MerchantLoginNotFound => new ServiceError("Üye İşyeri Giriş Logu bulunamadı.", 106);
        public static ServiceError ClientNotFound => new ServiceError("Müşteri bulunamadı.", 107);
        #endregion

        #region Override Equals Operator

        // Docs: https://msdn.microsoft.com/ru-ru/library/ms173147(v=vs.80).aspx

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to ServiceError or is null return false.
            var error = obj as ServiceError;

            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError a, ServiceError b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion


        /// <summary>
        /// ServiceError tipi icerisinde tanimlanmis, hata mesajlarini kodlari ile geri donen methodlari calistirir.
        /// Sonuclarini bir Dictionary olarak geri doner. Bu method, hata kodlari mobil cihazlar icin kodlar onemli oldugu icin hazirlandi.
        /// </summary>
        public static Dictionary<int, string> GetAll()
        {
            var codes = new Dictionary<int, string>();
            void Add(int code, string message)
            {
                if (codes.ContainsKey(code))
                    return;
                codes.Add(code, message);
            }

            var type = typeof(ServiceError);
            var bindingFlags = BindingFlags.Public | BindingFlags.Static;

            var propertyInfos = type.GetProperties(bindingFlags);
            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetIndexParameters().Length > 0)
                    continue;
                if (!propertyInfo.CanRead)
                    continue;
                if (propertyInfo.PropertyType != typeof(ServiceError))
                    continue;
                var returnVal = propertyInfo.GetValue(null);
                if (returnVal == null)
                    continue;
                var serviceError = (ServiceError)returnVal;
                Add(serviceError.Code, serviceError.Message);
            }

            var methodInfos = type.GetMethods(bindingFlags);
            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.ReturnType != typeof(ServiceError))
                    continue;

                var parameterInfos = methodInfo.GetParameters();
                var parameters = new List<object>();

                foreach (var parameterInfo in parameterInfos)
                {
                    var parameterType = parameterInfo.ParameterType;
                    if (parameterType == typeof(int))
                        parameters.Add(0);
                    else if (parameterType == typeof(decimal))
                        parameters.Add(0m);
                    else if (parameterType == typeof(double))
                        parameters.Add(0d);
                    else if (parameterType == typeof(string))
                        parameters.Add("0");
                    else if (parameterType == typeof(bool))
                        parameters.Add(false);
                }

                try
                {
                    var returnVal = methodInfo.Invoke(null, parameters.ToArray());
                    if (returnVal == null)
                        continue;
                    var serviceError = (ServiceError)returnVal;
                    Add(serviceError.Code, serviceError.Message);
                }
                catch 
                {

                    continue;
                }
              
               
            }

            return codes.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }


    }
}
