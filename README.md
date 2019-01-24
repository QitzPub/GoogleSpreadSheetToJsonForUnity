# GoogleSpreadSheetToJsonForUnity
Googleスプレッドシートのurlからjsonに変換して読み込むを行うことができるUnity向けのUtilです

## 導入方法
Archives中の　GoogleSpreadSheetToJsonVerx.x.x.unitypackage 
から導入が可能です！
https://github.com/QitzPub/GoogleSpreadSheetToJsonForUnity/tree/master/Archives

##  使い方

```namespace
using Qitz.DataUtil;
```
を入れます。

### Googleスプレッドシートのurlを取得します！

![googleスプレッドシートurl](https://i.gyazo.com/af6e69c3311e370e3b85cb5f29608a86.png "url")


### jsonで読み込めます。

```jsonで読み込む
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
```

### 指定のT型にシリアライズして読み込めます。

```指定の型にシリアライズして読み込む

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
```


