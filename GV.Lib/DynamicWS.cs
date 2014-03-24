using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Policy;

namespace GV.Lib
{
    public static class DynamicWS
    {

        /// <summary>
        /// Get Method ,Get WebService Execte Result by WebService Url, Method Name, Parametes
        /// 通过Get请求，根据WebService地址、方法名、参数（String 类型），得到对应的调用结果
        /// </summary>
        /// <param name="uri">（WebService Url）WebService地址</param>
        /// <param name="method">（Method Name）方法名</param>
        /// <param name="Params">(Parametes, Dictionry Type,[Key,Value])参数</param>
        /// <returns>(WebService Execte Result)Web服务调用结果</returns>
        public static string GetServiceResultByUrlAndMethod(string uri, string method, Dictionary<string, string> Params)
        {
            return new WebClient().DownloadString(string.Format("{0}/{1}?{2}", uri, method, ConvertToUrlParams(Params)));
        }

        /// <summary>
        /// Get Method ,Get WebService Execte Result by WebService Url, Method Name, Parametes
        /// 通过Get请求，根据WebService地址、方法名、参数（String 类型），得到对应的调用结果
        /// </summary>
        /// <param name="uri">（WebService Url）WebService地址</param>
        /// <param name="method">（Method Name）方法名</param>
        /// <param name="Params">(Parametes String Type)参数（Example：a=123&b=321,a=123）</param>
        /// <returns>(WebService Execte Result)Web服务调用结果</returns>
        public static string GetServiceResultByUrlAndMethod(string uri, string method, string Params)
        {
            Dictionary<string, string> ParamsDic = new Dictionary<string, string>();
            if (Params.IndexOf('?') > -1)
            {
                foreach (string Param in Params.Split('?'))
                {
                    ThreadOneParam(ParamsDic, Param);
                }
            }
            else if (Params.IndexOf('=') > -1)
            {
                ThreadOneParam(ParamsDic, Params);
            }

            string url = string.Format("{0}/{1}?{2}", uri, method, ConvertToUrlParams(ParamsDic));

            return new WebClient().DownloadString(url);
        }

        private static void ThreadOneParam(Dictionary<string, string> ParamsDic, string Param)
        {
            if (Param.IndexOf('=') > -1)
            {
                ParamsDic.Add(Param.Split('=')[0], Param.Split('=')[1]);
            }
        }

        private static string ConvertToUrlParams(Dictionary<string, string> Params)
        {
            string reValue = string.Empty;
            foreach (KeyValuePair<string, string> kvp in Params)
            {
                reValue += string.Format("{0}={1}&", kvp.Key, UrlEncode(kvp.Value));
            }
            return reValue.Substring(0, reValue.Length - 1);
        }

        private static string PostServiceResultByUrlAndMethod(string uri, string method, Dictionary<string, string> Params)
        {
            return string.Empty;
        }

        /// <summary>
        /// Convert Url Encode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }
    }
}
