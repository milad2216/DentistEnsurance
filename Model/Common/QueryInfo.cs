namespace Entity.Common
{
    public class QueryInfo
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public SortInfo[] Sort { get; set; }
        public FilterInfo Filter { get; set; }
    }
    
    public class SortInfo
    {
        public string Field { get; set; }
        public string Dir { get; set; }
    }
   
    public class FilterInfo
    {
        public string Logic { get; set; }
        public FilterData[] Filters { get; set; }
    }
    public class FilterData
    {
        public string Operator { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
