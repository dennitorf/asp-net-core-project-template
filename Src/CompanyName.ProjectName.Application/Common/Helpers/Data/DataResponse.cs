using System.Linq;

namespace CompanyName.ProjectName.Common.Helpers.Data
{
    public class DataResponse<T>
    {
        public int Total { set; get; }
        public IQueryable<T> Data { set; get; }
    }
}