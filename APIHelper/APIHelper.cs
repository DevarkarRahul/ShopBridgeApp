using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Configuration;
using ShopBridge.Models;

namespace ShopBridge.APIHelper
{
    public class APIHelper
    {
        static string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        static string apiUserName = ConfigurationManager.AppSettings["apiUserName"];
        static string apiPassword = ConfigurationManager.AppSettings["apiPassword"];
        static string authstring = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apiUserName + ":"+ apiPassword));
        public static IEnumerable<Product> Get()
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + authstring);
                client.BaseAddress = new Uri(baseAddress);

                var responseTask = client.GetAsync("Products");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    products = js.Deserialize<IEnumerable<Product>>(readTask);
                }
                else
                {
                    products = Enumerable.Empty<Product>();
                }
            }
            return products;
        }

        public static Product Get(int id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + authstring);
                client.BaseAddress = new Uri(baseAddress);

                var responseTask = client.GetAsync("products?id=" + id);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    product = js.Deserialize<Product>(readTask);
                }
                else
                {
                    product = null;
                }
            }
            return product;
        }

        public static bool Post(Product product)
        {
            bool isPosted;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + authstring);
                client.BaseAddress = new Uri(baseAddress);
                var json = JsonConvert.SerializeObject(product);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var responseTask = client.PostAsync("products", stringContent);

                var result = responseTask.Result;
                isPosted = result.IsSuccessStatusCode;

            }
            return isPosted;
        }

        public static bool Put(Product product)
        {
            bool isPosted;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + authstring);
                client.BaseAddress = new Uri(baseAddress);
                var json = JsonConvert.SerializeObject(product);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var responseTask = client.PutAsync("products", stringContent);

                var result = responseTask.Result;
                isPosted = result.IsSuccessStatusCode;

            }
            return isPosted;
        }

        public static bool Delete(int id)
        {
            bool isPosted;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + authstring);
                client.BaseAddress = new Uri(baseAddress);

                var responseTask = client.DeleteAsync("products?id=" + id);

                var result = responseTask.Result;
                isPosted = result.IsSuccessStatusCode;

            }
            return isPosted;
        }
    }
}