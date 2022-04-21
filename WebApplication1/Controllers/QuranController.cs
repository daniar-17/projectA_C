using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QuranController : Controller
    {
        // GET: Quran
        public async Task<ActionResult> Index()
        {
            try
            {
                List<QuranModel> surats = await GetAllQuran();
                ViewData["ListSurat"] = surats;
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            return View();
        }

        public async Task<List<QuranModel>> GetAllQuran()
        {
            List<QuranModel> resultList = new List<QuranModel>();
            try
            {
                var client = new RestClient("https://equran.id/api/surat");
                var request = new RestRequest("", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                resultList = JsonConvert.DeserializeObject<List<QuranModel>>(response.Content);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            return resultList;
        }

        public async Task<ActionResult> Detail(string id)
        {
            QuranModel resultList = new QuranModel();
            try
            {
                var client = new RestClient(string.Format("https://equran.id/api/surat/{0}", id));
                var request = new RestRequest("", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                resultList = JsonConvert.DeserializeObject<QuranModel>(response.Content);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            ViewData["ListSuratDetail"] = resultList;
            return View("Detail");
        }

        public async Task<ActionResult> DetailTafsir(string id)
        {
            QuranModel resultList = new QuranModel();
            try
            {
                var client = new RestClient(string.Format("https://equran.id/api/tafsir/{0}", id));
                var request = new RestRequest("", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                resultList = JsonConvert.DeserializeObject<QuranModel>(response.Content);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            ViewData["ListTafsirDetail"] = resultList;
            return View("DetailTafsir");
        }
    }
}