using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace ErrorCatcher.Helper
{
    /// <summary>
    /// Credit from this link
    /// http://www.codeandyou.com/2015/09/how-to-get-query-string-headers-and-body-from-HttpActionExecutedContext.html
    /// </summary>
    public class WebApiRequestHelper
    {
        public List<KeyValuePair<string, string>> GetQueryStringFromRequest(HttpActionExecutedContext context)
        {
            var queryStringList = new List<KeyValuePair<string,
                string>>();

            if (context.Request.RequestUri != null)
            {
                if (context.Request.RequestUri.Query.Count() != 0)
                {
                    var queryCollection = context.Request.RequestUri.Query.Substring(1).Split('&');

                    foreach (var item in queryCollection)
                    {
                        var itm = item.Split('=');
                        var queryString = new KeyValuePair<string,
                            string>(itm[0], itm[1]);
                        queryStringList.Add(queryString);
                    }
                }
            }

            return queryStringList;
        }

        public List<KeyValuePair<string, string>> GetHeadersFromRequest(HttpActionExecutedContext context)
        {
            var headersList = new List<KeyValuePair<string,
                string>>();

            foreach (var header in context.Request.Headers)
            {
                headersList.Add(new KeyValuePair<string, string>(header.Key, ((string[])(header.Value))[0]));
            }

            return headersList;
        }
        public string GetBodyFromRequest(HttpActionExecutedContext context)
        {
            string data;
            using (var stream = context.Request.Content.ReadAsStreamAsync().Result)
            {
                if (stream.CanSeek)
                {
                    stream.Position = 0;
                }
                data = context.Request.Content.ReadAsStringAsync().Result;
            }
            return data;
        }
    }
}
