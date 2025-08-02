namespace CompanyName.ProjectName.Common.Helpers.Data
{
    public class DataRequest
    {
        public int Page { set; get; }  
        public int PageSize { set; get; }
        public string FilterBy { set; get; }
        public string Filter { set; get; }
        public string OrderBy { set; get; }
        public string Order { set; get; }   

        public DataRequest()
        {
            Page = 1;
            PageSize = 10;
            FilterBy = "";
            Filter = "";
            OrderBy = "";
            Order = "";
        }
    }
}