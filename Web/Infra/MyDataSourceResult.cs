using System.Collections;

namespace Web.Infra
{
    public class MyDataSourceResult
    {
        public int total { get; set; }

        public IEnumerable data { get; set; }
    }
}