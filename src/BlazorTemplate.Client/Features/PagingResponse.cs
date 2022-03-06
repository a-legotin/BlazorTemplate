using System.Collections.Generic;
using BlazorTemplate.Classes.RequestFeatures;

namespace BlazorTemplate.Client.Features;

public class PagingResponse<T> where T : class
{
    public List<T> Items { get; set; }
    public MetaData MetaData { get; set; }
}