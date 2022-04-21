using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class RajaOngkirProvince
    {
        [JsonProperty("rajaongkir")]
        public ProvinceList ProvinceListData { get; set; }
    }

    public class ProvinceList
    {
        [JsonProperty("query")]
        public List<ProvinceQueryList> Query { get; set; }

        [JsonProperty("status")]
        public ProvinceStatusList Status { get; set; }

        [JsonProperty("results")]
        public List<ProvinceResultList> Result { get; set; }
    }

    public class ProvinceQueryList
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public class ProvinceStatusList
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ProvinceResultList
    {
        [JsonProperty("province_id")]
        public string Province_Id { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }
    }
}