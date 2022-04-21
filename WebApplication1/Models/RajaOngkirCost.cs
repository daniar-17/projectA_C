using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class RajaOngkirCost
    {
        [JsonProperty("rajaongkir")]
        public CostList CostListData { get; set; }
    }

    public class CostList
    {
        [JsonProperty("query")]
        public CostQueryList Query { get; set; }

        [JsonProperty("status")]
        public CostStatusList Status { get; set; }

        [JsonProperty("origin_details")]
        public CityResultList OriginDetails { get; set; }

        [JsonProperty("destination_details")]
        public CityResultList DestinationDetails { get; set; }

        [JsonProperty("results")]
        public List<CostResultList> Results { get; set; }
    }

    public class CostQueryList
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("courier")]
        public string Courier { get; set; }
    }

    public class CostStatusList
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class CostResultList
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("costs")]
        public List<Costs> Costs { get; set; }
    }

    public class Costs
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public List<Cost> Cost { get; set; }
    }

    public class Cost
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("etd")]
        public string Etd { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}