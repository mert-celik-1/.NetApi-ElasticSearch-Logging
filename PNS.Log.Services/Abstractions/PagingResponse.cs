namespace PNS.Log.Services.Abstractions
{
    using System.Collections.Generic;

    public class PagingResponse<T>
    {
        public int TotalPageCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
