# GoogleSpreadSheetToJsonForUnity
Googleスプレッドシートのurlからjsonに変換して読み込むを行うことができるUnity向けのUtilです

## 導入方法
Archives中の　GoogleSpreadSheetToJsonVerx.x.x.unitypackage 
から導入が可能です！
https://github.com/QitzPub/GoogleSpreadSheetToJsonForUnity/tree/master/Archives

パッケージからUnityへインスコします〜〜！<br>
![インスコ図](https://i.gyazo.com/d76cbd29f11ae1bb3efb49ac55d0b587.png "インスコ")<br>


##  使い方

```C#
using Qitz.DataUtil;
```
を入れます。

### Googleスプレッドシートのurlを取得します！

まずはシートを公開します！

![googleスプレッドシートurl](https://i.gyazo.com/ce201599d1ff3c92fcf3b32c4a04d98e.png "url")<br>
<br>
シートのurlを取得します！
<br>
![googleスプレッドシートurl](https://i.gyazo.com/af6e69c3311e370e3b85cb5f29608a86.png "url")


### jsonで読み込めます。

```C#
        public IEnumerator JsonLoadFromGoogleSpreadSheetTest()
        {
            yield return JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl("https://docs.google.com/spreadsheets/d/1m--rzZdlS0eURgjQ0Fr4oZHLSY5xvrf8adLaOzSgBEA/edit#gid=1515512237", (jsonArray) =>
            {
                foreach (var json in jsonArray)
                {
                    Debug.Log(json);
                }

            });
            yield return null;
        }
```

### 指定のT型にシリアライズして読み込めます。

```C#

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


