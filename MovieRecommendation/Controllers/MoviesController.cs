using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using movierecommender.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace movierecommender.Controllers
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        private readonly AppSettings _appSettings;
        //private static HttpClient Client = new HttpClient();
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(MovieService movieService, ILogger<MoviesController> logger, IOptions<AppSettings> appSettings)
        {
            _movieService = movieService;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public ActionResult Choose()
        {
            return View(_movieService.GetSomeSuggestions());
        }

        public new ActionResult User()
        {
            return View();
        }

       
        public ActionResult SetUser()
        {
            string UserID = HttpContext.Request.Form["userid"];
            string Rating = HttpContext.Request.Form["rating"];
            HttpContext.Session.Clear();

            HttpContext.Session.SetString("UserID", UserID);
            HttpContext.Session.SetString("Rating", Rating);
            return RedirectToAction("Choose");
        }
        static async Task<string> InvokeRequestResponseService(int id,List<string> UserDetails, ILogger logger, AppSettings appSettings)
        {
            
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                              new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "UserID", UserDetails[0]
                                            },
                                            {
                                                "MovieID", id.ToString()
                                            },
                                            {
                                                "Rating", UserDetails[1]
                                            },
                                }
                        }
                    },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                string apiKey = appSettings.apikey;
                string uri = appSettings.uri; 
                if (apiKey != string.Empty && uri != string.Empty)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    client.BaseAddress = new Uri(uri);

                    //HttpResponseMessage response = await client.PostAsync(appSettings.uri, new JsonContent(scoreRequest)).ConfigureAwait(false);


                    HttpResponseMessage response = await client
                        .PostAsync(appSettings.uri, new StringContent(JsonConvert.SerializeObject(scoreRequest), Encoding.UTF8, "application/json"))
                        .ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return result;
                    }
                    else
                    {
                        logger.LogError(string.Format("The request failed with status code: {0}", response.StatusCode));
                        // Print the headers - they include the requert ID and the timestamp,
                        // which are useful for debugging the failure
                        logger.LogDebug(response.Headers.ToString());

                        string responseContent = await response.Content.ReadAsStringAsync();
                        logger.LogDebug(responseContent);
                        return null;
                    }
                } else
                {
                    logger.LogError("Please provide apiKey and URI to the Machine Learning WebService");
                }

                return null; 
        }
}

        public async Task<ActionResult> Recommend(int id)
        {
            try
            {
                var UserID =  HttpContext.Session.GetString("UserID");
                var Rating = HttpContext.Session.GetString("Rating");
                List<string> UserDetails = new List<string>();
                UserDetails.Add(UserID);
                UserDetails.Add(Rating);
                var result = await InvokeRequestResponseService(id, UserDetails, _logger, _appSettings);
                var obj = JObject.Parse(result);
                var suggDict = obj["Results"]["output1"][0].ToObject<Dictionary<string, string>>();
                var suggList = suggDict.Values.ToList();

                var suggestedMovies = suggList
                        .Select(i => int.Parse(i))
                        .Select(i => _movieService.Get(i));
                return View(suggestedMovies);
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("An error occured:'{0}'", e));
                return View(); 
            }
         }

        public ActionResult Watch()
        {
            return View();
        }


        public class JsonContent : StringContent
        {
            public JsonContent(object obj) :
                base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }
    }
}