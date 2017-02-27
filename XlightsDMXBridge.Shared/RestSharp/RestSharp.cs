using log4net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XlightsDMXBridge.Shared
{
    public static class RestSharp
    {
        private static ILog Logging = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static RestClient CreateClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);

            var serializer = new NewtonsoftJsonSerializer();

            // Override with Newtonsoft JSON Handler
            client.AddHandler("application/json", serializer);
            client.AddHandler("text/json", serializer);
            client.AddHandler("text/x-json", serializer);
            client.AddHandler("text/javascript", serializer);
            client.AddHandler("*+json", serializer);

            return client;
        }

        public static string RestfulPOST(object request, string resource, string BaseEndPoint)
        {
            return RestfulCall(Method.POST, request, resource, BaseEndPoint);
        }
		  public static string RestfulGET(string resource, string BaseEndPoint)
		{
			return RestfulCall(Method.GET, null, resource, BaseEndPoint);
		}

		public static string RestfulCall(Method method, object request, string resource, string BaseEndPoint)
        {
            RestRequest restRequest = new RestRequest(resource, method);
            var client =  RestSharp.CreateClient(BaseEndPoint);
			 
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.JsonSerializer = new NewtonsoftJsonSerializer();

			if (request != null)
			{
				restRequest.AddJsonBody(request);
			}

			IRestResponse results = null;

			switch (method)
			{
				case Method.GET:
				    results =	client.Get(restRequest);

					break;
				case Method.POST:
					 results = client.Post(restRequest);
					break;
				case Method.DELETE:
					results = client.Delete(restRequest);
					break;
				case Method.HEAD:
					results = client.Head(restRequest);
					break;
				case Method.PATCH:
					results = client.Patch(restRequest);
					break;
				case Method.OPTIONS:
					results = client.Options(restRequest);
					break;
				default:
					throw new ArgumentException("Invalid Method"); 
			}


			if (!string.IsNullOrWhiteSpace(results.ErrorMessage))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BaseEndPoint            : " + BaseEndPoint);
                sb.AppendLine("Resource                : " + resource);
                sb.AppendLine("Method                  : " + method.ToString());
                sb.AppendLine("Status Code             : " + results.StatusCode.ToString());
                sb.AppendLine("Status Code Description : " + results.StatusDescription);
                sb.AppendLine("Response Status         : " + results.ResponseStatus.ToString());
               
                if (request != null)
                {
                    sb.AppendLine("Request      : " + JsonConvert.SerializeObject(request));
                }
                
                log4net.LogicalThreadContext.Properties["request"] = sb.ToString();
                log4net.LogicalThreadContext.Properties["response"] = JsonConvert.SerializeObject(results);
                Logging.Error("Error making REST Call:" + results.ErrorMessage, results.ErrorException);
            }

            return results.Content;
        }


        public static T RestfulPOST<T>(string resource, string baseEndPoint)
        {
            return RestfulPOST<T>(null, resource, baseEndPoint);
        }

        public static T RestfulPOST<T>(object request, string resource, string baseEndPoint)
        {
            string response = null;

            T result = default(T);
            try
            {
                response = RestfulPOST(request, resource, baseEndPoint);

                result = Serializer.JsonDeserialize<T>(response);
            }
            catch (Exception ex)
            {
                if (request != null)
                {
                    log4net.LogicalThreadContext.Properties["request"] = JsonConvert.SerializeObject(request).ToString();
                }

                log4net.LogicalThreadContext.Properties["response"] = response;
                Logging.Error(String.Format("An exception occurred while deserializing response from RestfulPOST.  Exception {0}", ex.Message), ex);

                throw;
            }

            return result;
        }

	 

		public static T RestfulGET<T>(string resource, string baseEndPoint)
		{
			string response = null;

			T result = default(T);
			try
			{
				response = RestfulGET( resource, baseEndPoint);

				result = Serializer.JsonDeserialize<T>(response);
			}
			catch (Exception ex)
			{

				log4net.LogicalThreadContext.Properties["response"] = response;
				Logging.Error(String.Format("An exception occurred while deserializing response from RestfulPOST.  Exception {0}", ex.Message), ex);

				throw;
			}

			return result;
		}
    }
}
