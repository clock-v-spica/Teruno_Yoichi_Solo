# Teruno_Yoichi

| ----- | バージョン |
| ----- | ------ |
| Unity | 2021.1.11f |
| Oculus Integration | 38.0 |

## セットアップ
[Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)はGithubにプッシュできるファイルサイズの関係でignoreにされています。**クローン後各自でパッケージを導入してください**。

各自で作業内容が被ってコンフリクトを起こさないよう、作業の際には以下の二点に気をつけてください。
 - mainから**ブランチを切る**
   - ブランチ名については任せますが、誰が作業しているのか、何について作業しているのか分かりやすい名前が良いでしょう。
   - ex ) kaiba/add-photon
 - **Assets/ [作業ファイル種類] /[名前]　というように階層を分ける**
   - ex ) Assets/Scripts/Kaiba/example.cs
   - ex ) Assets/Scenes/Kaiba/MainScene.unity

/Library /obj　などのUnityの中間ファイル群の階層はignoreに入っています。
基本的には作業で変更したファイルのみコミットしてください。(EditorLayoutなどの個人ファイルをコミットするのは控えましょう)

不明点/改善点あればKaibaまでー
