using System.Collections.Generic;
using ResultPipeline.Entities;

namespace ResultPipeline.Responses
{
    public class GetAllBeveragesResponse
    {
        public IEnumerable<Beverage> Beverages { get; set; }
    }
}
