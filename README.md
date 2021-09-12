# GoogleSpreadSheetToJsonForUnity
Googleスプレッドシートのurlからjsonに変換して読み込むを行うことができるUnity向けのUtilです

## 導入方法
Archives中の　GoogleSpreadSheetToJsonVerx.x.x.unitypackage 
から導入が可能です！
https://github.com/QitzPub/GoogleSpreadSheetToJsonForUnity/raw/master/Archives/GoogleDriveMasterDataStore.unitypackage

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

BasedataStoreを継承したDataStoreを作成します。<br>
<br>

```C#

using UnityEngine;
using Qitz.DataUtil;
using System.Collections.Generic;

namespace Qitz.DataUtil.Demo
{
    [CreateAssetMenu]
    public class SkillReleaseConditionVODataStore : BaseDataStore<SkillReleaseConditionVO>
    {
        [ContextMenu("サーバーからデータを読み込む")]
        protected override void LoadDataFromServer()
        {
            base.LoadDataFromServer();
        }
    }
}
```
[CreateAssetMenu]をクラスにつけるのをお忘れなく！<br>
<br>

### GoogleSpreadSheetの項目を読み込むためのValueObjectをつくります

```C#

using UnityEngine;
using System.Collections.Generic;
using Qitz.DataUtil;

namespace Qitz.DataUtil.Demo
{
    [System.Serializable]
    public class SkillReleaseConditionVO 
    {

        [SerializeField]
        int id;
        public int Id => id;


        [SerializeField]
        string unique_name;
        public string UniqueName => unique_name;


        [SerializeField]
        int value;
        public int Value => value;


        [SerializeField]
        string type;
        public string Type => type;

    }
}

```

[System.Serializable]をつけるのをお忘れなく！<br>
<br>

### 右クリックでScriptableObjectを生成できます！

![googleスプレッドシートurl](https://i.gyazo.com/1985f9e6b12411866ff30fb0beec6f88.jpg "url")<br>
<br>
![googleスプレッドシートurl](https://i.gyazo.com/fd59a941b1c500f70469309e8dd2f885.png "url")<br>
<br>
生成されたScriptableObjectにGoogleSpreadSheetのUrlをいれて右クリックでサーバー読み込みを選択しデータを読み込みます<br>
<br>



