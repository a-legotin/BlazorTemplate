using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTemplate.Classes.RequestFeatures;

namespace BlazorProducts.Client.Features
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }
}
