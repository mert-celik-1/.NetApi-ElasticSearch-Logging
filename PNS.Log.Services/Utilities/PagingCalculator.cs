using System;


namespace PNS.Log.Services.Utilities
{
    public static class PagingCalculator
    {
        /// <summary>
        /// Sayfa sayısını hesaplayan metod
        /// </summary>
        /// <param name="totalItemCount">Toplam madde sayısı</param>
        /// <param name="pageItemCount">Sayfa başına düşen madde sayısı</param>
        /// <returns>Sayfa sayısı</returns>
        public static int GetPageCount(int totalItemCount, int pageItemCount)
        {
            double pageCount = Math.Ceiling((double)totalItemCount / pageItemCount);

            return Convert.ToInt32(pageCount);
        }
    }
}
