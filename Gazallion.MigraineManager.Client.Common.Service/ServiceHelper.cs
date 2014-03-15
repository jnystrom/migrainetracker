using System;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
//using Windows.Data.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Serialization;
using Gazallion.MigraineManager.Client.Common.Service.I.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;


namespace Gazallion.MigraineManager.Client.Common.Service
{
    public static class ServiceHelper
    {
        public static async Task GetDataAsync(string url)
        {
            await GetDataAsync(url, CancellationToken.None);
        }
        public static async Task GetDataAsync(string url, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // My tests keep dropping here without any error or stack trace  !!
                    HttpResponseMessage response = await client.GetAsync(url, token);

                    if (!token.IsCancellationRequested)
                    {
                        await ValidateResponse(response);
                        
                    }
                }
                catch (TaskCanceledException)
                {
                    // do nothing
                }
               
            }
        }
        public static async Task<T> GetDataAsync<T>(string url)
        {
            return await GetDataAsync<T>(url, CancellationToken.None);
        }
        public static async Task<T> GetDataAsync<T>(String url, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // My tests keep dropping here without any error or stack trace  !!
                    HttpResponseMessage response = await client.GetAsync(url, token);

                    if (!token.IsCancellationRequested)
                    {
                        await ValidateResponse(response);

                        //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                        //return (T)serializer.ReadObject(await response.Content.ReadAsStreamAsync());
                        return await Deserialize<T>(response.Content);
                    }
                    return default(T);
                }
                catch (TaskCanceledException)
                {
                    return default(T);
                }
                
            }

        }

        private static async Task<T> Deserialize<T>(HttpContent content)
        {
            var data = await content.ReadAsStreamAsync();
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader reader = new StreamReader(await content.ReadAsStreamAsync()))
            {
                using (JsonReader jsonReader = new JsonTextReader(reader))
                {
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
                
        public static async Task PostDataAsync(string url)
        {
            await PostDataAsync(url, CancellationToken.None);
        }
        public static async Task PostDataAsync(string url, CancellationToken cancelToken)
        {
            await PostDataAsync(url, null, cancelToken);
        }
        public static async Task<T> PostDataAsync<T>(string url)
        {
            return await PostDataAsync<T>(url,CancellationToken.None);
        }
        public static async Task<T> PostDataAsync<T>(string url, CancellationToken cancelToken)
        {
            return await PostDataAsync<T>(url, null, cancelToken);
        }
        public static async Task PostDataAsync(string url, object data)
        {
            await PostDataAsync(url, data, CancellationToken.None);
        }
        public static async Task PostDataAsync(string url, object data, CancellationToken cancelToken)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    StringContent jsonContent = new StringContent(String.Empty);
                    if (data != null)
                    {
                        jsonContent = new StringContent(parseIntoJSON(data));
                        jsonContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    }
                    var response = await client.PostAsync(url, jsonContent, cancelToken);
                    if (!cancelToken.IsCancellationRequested)
                    {
                        await ValidateResponse(response);

                    }
                }
                catch (TaskCanceledException)
                {
                    // do nothing
                }
                
            }
        }
        public static async Task<T> PostDataAsync<T>(string url, object data)
        {
            return await PostDataAsync<T>(url, data, CancellationToken.None);
        }
        public static async Task<T> PostDataAsync<T>(string url, object data, CancellationToken cancelToken)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    StringContent jsonContent = new StringContent(String.Empty);
                    if (data != null)
                    {
                        jsonContent = new StringContent(parseIntoJSON(data));
                        jsonContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        Debug.WriteLine(string.Format("PostData: Content Set"));
                    }
                    HttpResponseMessage response = await client.PostAsync(url, jsonContent, cancelToken);
                    if (!cancelToken.IsCancellationRequested)
                    {
                        await ValidateResponse(response);
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                        return (T)serializer.ReadObject(await response.Content.ReadAsStreamAsync());
                    }

                    return default(T);
                }
                catch (TaskCanceledException)
                {
                    return default(T);
                }
            }
        }

        public static async Task DeleteDataAsync(string url)
        {
            using (var client = new HttpClient())
            {
                
                var response = await client.DeleteAsync(url);
                await ValidateResponse(response);

            }
        }

        internal static string parseIntoJSON(object data)
        {
            System.Diagnostics.Debug.WriteLine("++parseIntoJSON");

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
            string retVal;

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, data);
                var bytes = ms.ToArray();
                retVal = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            }

            System.Diagnostics.Debug.WriteLine("--parseIntoJSON: {0}",retVal);

            return retVal;
        }

        static async Task ValidateResponse(HttpResponseMessage response)
        {
            HttpStatusCode status = HttpStatusCode.Accepted;

            //return;
            //string content = string.Empty;
            //switch ((int)response.StatusCode)
            //{ 
            //    case HttpStatusCode.Accepted:
            //        {
            //            break;

            //        }
            //}
            return;
            //switch (response.StatusCode)
            //{
            //    case HttpStatusCode.OK:
            //    case HttpStatusCode.Created:
            //        break;

            //    case HttpStatusCode.NoContent:
            //        throw new NoContentException();

            //    case HttpStatusCode.BadRequest:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new BadRequestException(content);
            //        else
            //            throw new BadRequestException();

            //    case HttpStatusCode.Unauthorized:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new UnauthorizedException(content);
            //        else
            //            throw new UnauthorizedException();

            //    case HttpStatusCode.Forbidden:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new ForbiddenException(content);
            //        else
            //            throw new ForbiddenException();

            //    case HttpStatusCode.NotFound:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new NotFoundException(content);
            //        else
            //            throw new NotFoundException();

            //    case HttpStatusCode.Conflict:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new ConflictException(content);
            //        else
            //            throw new ConflictException();

            //    case HttpStatusCode.PreconditionFailed:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new PreconditionFailedException(content);
            //        else
            //            throw new PreconditionFailedException();

            //    case HttpStatusCode.InternalServerError:
            //        content = await response.Content.ReadAsStringAsync();
            //        if (!string.IsNullOrEmpty(content))
            //            throw new ServerErrorException(content);
            //        else
            //            throw new ServerErrorException();

            //    default:
            //        throw new InvalidOperationException(string.Format("Unexpected Response Code {0}", response.StatusCode));
            //}
        }
        
    }

    //public class ServiceHelper<T>
    //{
    //    public async Task<T> GetDataAsync(string url)
    //    {
    //        return await ServiceHelper.GetDataAsync<T>(url);
    //    }

    //    public async Task WriteDataAsync(string url)
    //    {
    //        await ServiceHelper.PostDataAsync<T>(url);
    //    }

    //    public async Task PostData(string url, object data)
    //    {
    //        await ServiceHelper.PostDataAsync(url, data);
    //    }

    //    public async Task DeleteData(string url)
    //    {
    //        await ServiceHelper.DeleteData<T>(url);
    //    }

    //    private static string parseIntoJSON(object data)
    //    {
    //        return ServiceHelper.parseIntoJSON(data);
    //    }
    //}

}
