namespace PNS.Log.Services.Abstractions
{
    using Newtonsoft.Json;

    public class PagingRequest
    {
        public PagingRequest(int pageIndex, int pageItemCount)
        {
            this.PageIndex = pageIndex;
            this.PageItemCount = pageItemCount;
        }

        public int PageIndex { get; }

        public int PageItemCount { get; }

        [JsonIgnore]
        public int PageSkip
        {
            get
            {
                return (this.PageIndex * this.PageItemCount) - this.PageItemCount;
            }
        }
    }
}