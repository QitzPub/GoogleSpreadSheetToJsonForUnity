using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using Qitz.DataUtil;

namespace Tests
{
    public class CsvLoadFromGoogleSpreadSheetTest
    {
        [Serializable]
        public class TestClassObejct
        {
            [SerializeField]
            int id;
            public int Id { get { return id; } }

            [SerializeField]
            string name;
            public string Name { get { return name; } }

            [SerializeField]
            string description;
            public string Description { get { return description; } }
        }

        [UnityTest]
        public IEnumerator GetDataFromGoogleSpreadSheetTest()
        {
            yield return JsonFromGoogleSpreadSheet
            .GetTeargetTypeDataFromGoogleSpreadSheetUrl<TestClassObejct>("https://docs.google.com/spreadsheets/d/1m--rzZdlS0eURgjQ0Fr4oZHLSY5xvrf8adLaOzSgBEA/edit#gid=1076726587", (dataList) =>
            {
                foreach (var data in dataList)
                {
                    Debug.Log(data.Name);
                }

            });
            yield return null;
        }

        [UnityTest]
        public IEnumerator JsonLoadFromGoogleSpreadSheetTest()
        {
            yield return JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl("https://docs.google.com/spreadsheets/d/1m--rzZdlS0eURgjQ0Fr4oZHLSY5xvrf8adLaOzSgBEA/edit#gid=1515512237", (jsonArry) =>
            {
                foreach (var json in jsonArry)
                {
                    Debug.Log(json);
                }

            });
            yield return null;
        }
    }
}
