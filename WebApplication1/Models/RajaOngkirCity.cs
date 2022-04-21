using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class RajaOngkirCity
    {
        [JsonProperty("rajaongkir")]
        public CityList CityListData { get; set; }
    }

    public class CityList
    {
        [JsonProperty("query")]
        public List<CityQueryList> Query { get; set; }

        [JsonProperty("status")]
        public CityQueryList Status { get; set; }

        [JsonProperty("results")]
        public List<CityResultList> Results { get; set; }
    }

    public class CityQueryList
    {
        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class CityStatusList
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class CityResultList
    {
        [JsonProperty("city_id")]
        public string CityId { get; set; }

        [JsonProperty("province_id")]
        public string ProvinceId { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
    }
}