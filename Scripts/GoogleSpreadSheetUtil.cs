using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Networking;

namespace Qitz.DataUtil
{
    public static class CSVFromGoogleSpreadSheet
    {
        /// <summary>
        /// GoogleSpreadSheetのurlからcsvを取得する
        /// </summary>
        /// <returns>The CSVF rom google spread sheet URL.</returns>
        /// <param name="url">URL.</param>
        /// <param name="callBack">Call back.</param>
        public static IEnumerator GetCSVFromGoogleSpreadSheetUrl(string url, Action<string> callBack)
        {
            if (url.IndexOf("https://docs.google.com/spreadsheets") == -1 || url.IndexOf("edit#") == -1)
            {
                Debug.LogError("GoogleSpreadSheetのurlではないっぽい");
                yield break;
            }

            url = url.Replace("edit#", "export?format=csv&");

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.Send();
            if (request.isError)
            {
                Debug.LogError(request.error);
                callBack(request.error);
            }
            else
            {
                string text = request.downloadHandler.text;
                callBack(text);
            }
        }
    }

    public static class JsonFromGoogleSpreadSheet
    {

        /// <summary>
        /// 指定したタイプにシリアライズされたリストで返す
        /// </summary>
        /// <returns>The tearget type from google spread sheet URL.</returns>
        /// <param name="url">URL.</param>
        /// <param name="callBack">Call back.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerator GetTeargetTypeDataFromGoogleSpreadSheetUrl<T>(string url, Action<List<T>> callBack)
        {
            yield return GetJsonArrayFromGoogleSpreadSheetUrl(url, (jsonArray) =>
            {
                callBack(jsonArray.Select(json => JsonUtility.FromJson<T>(json)).ToList());
            });
        }

        /// <summary>
        /// GoogleSpreadSheetのurlからJsonの配列を取得する
        /// </summary>
        /// <returns>The json array from google spread sheet URL.</returns>
        /// <param name="url">URL.</param>
        /// <param name="callBack">Call back.</param>
        public static IEnumerator GetJsonArrayFromGoogleSpreadSheetUrl(string url, Action<string[]> callBack)
        {
            yield return CSVFromGoogleSpreadSheet.GetCSVFromGoogleSpreadSheetUrl(url, (csv) =>
            {
                callBack(GetJsonArrayFromCSV(csv));
            });
        }

        static string[] GetJsonArrayFromCSV(string csv)
        {
            string[] lines = csv.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] jsonArray = new string[lines.Length - 1];
            List<string> data = lines.Skip(1).ToList();
            string[] head = lines[0].Split(',');
            int count = 0;
            foreach (var d in data)
            {
                string[] elements = d.Split(',');
                string json = "{\"";
                for (int i = 0; i < head.Length; i++)
                {
                    if (i != 0) json += "\"";
                    json += head[i];
                    json += "\":\"";
                    json += elements[i];
                    json += "\"";
                    if (i != head.Length - 1)
                    {
                        json += ",";
                    }
                }
                json += "}";
                jsonArray[count] = json;
                count++;
            }
            return jsonArray;
        }
    }
}
