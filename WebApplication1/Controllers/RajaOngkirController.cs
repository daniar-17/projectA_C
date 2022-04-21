using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace WebApplication1.Controllers
{
    public class RajaOngkirController : Controller
    {
        private readonly string myKeys = "695fd2e1535a3750238404ee731b0ebd";
        // GET: RajaOngkir
        public async Task<ActionResult> Index()
        {
            try
            {
                List<CityResultList> citys = await GetAllCity();
                //return JsonConvert.SerializeObject(provinces, Formatting.Indented);
                //return Json(provinces, JsonRequestBehavior.AllowGet);
                ViewData["ListCity"] = citys;
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }
            
            return View();
        }

        public async Task<List<ProvinceResultList>> GetAllProvince()
        {
            var client = new RestClient("https://api.rajaongkir.com/starter/province");
            var request = new RestRequest("", Method.Get);
            request.AddHeader("key", myKeys);
            RestResponse response = await client.ExecuteAsync(request);
            var getData = JsonConvert.DeserializeObject<RajaOngkirProvince>(response.Content).ProvinceListData;

            return getData.Result;
        }

        public async Task<List<CityResultList>> GetAllCity()
        {
            var client = new RestClient("https://api.rajaongkir.com/starter/city");
            var request = new RestRequest("", Method.Get);
            request.AddHeader("key", myKeys);
            RestResponse response = await client.ExecuteAsync(request);
            var getData = JsonConvert.DeserializeObject<RajaOngkirCity>(response.Content).CityListData;

            return getData.Results;
        }

        public async Task<ActionResult> SearchCost(string origin, string destination, string weight)
        {
            try
            {
                weight = (double.Parse(weight) * 1000).ToString();
                string[] courier = { "jne", "tiki", "pos" };
                //ViewBag.cityfrom = null;
                //ViewBag.cityto = null;

                List<CostResultList> resultCosts = new List<CostResultList>();
                for(int i = 0; i < courier.Length; i++)
                {
                    var client = new RestClient("https://api.rajaongkir.com/starter/cost");
                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("key", myKeys);
                    request.AddHeader("content-type", "application/x-www-form-urlencoded");
                    request.AddParameter("origin", origin);
                    request.AddParameter("destination", destination);
                    request.AddParameter("weight", weight);
                    request.AddParameter("courier", courier[i]);
                    RestResponse response = await client.ExecuteAsync(request);
                    if (response.ErrorMessage == null)
                    {
                        var data = JsonConvert.DeserializeObject<RajaOngkirCost>(response.Content).CostListData;
                        if (data.Status.Code == 400)
                        {
                            throw new Exception(data.Status.Description);
                        }

                        //ViewBag.cityfrom = data.OriginDetails.Type.ToLower().Replace("kabupaten", "kab") + " " + data.OriginDetails.CityName;
                        //ViewBag.cityto = data.DestinationDetails.Type.ToLower().Replace("kabupaten", "kab") + " " + data.DestinationDetails.CityName;

                        if (data.Results.Count > 0)
                        {
                            resultCosts.AddRange(data.Results);
                        }
                    }
                    else
                    {
                        throw new Exception(response.ErrorMessage + ": Check your connection");
                    }
                }
                ViewData["listdata"] = resultCosts;
            }
            catch (Exception e)
            {
                ViewBag.sysError = e.Message;
            }
            
            return PartialView("~/Views/RajaOngkir/_GridView.cshtml");
        }
    }
}