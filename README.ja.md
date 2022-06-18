
- [Spacious Start Menu](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#spacious-start-menu)
- [要件](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E8%A6%81%E4%BB%B6)
- [インストール](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%BC%E3%83%AB)
- [使い方](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E4%BD%BF%E3%81%84%E6%96%B9)
  - [メイン画面のコンテキストメニュー](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%83%A1%E3%82%A4%E3%83%B3%E7%94%BB%E9%9D%A2%E3%81%AE%E3%82%B3%E3%83%B3%E3%83%86%E3%82%AD%E3%82%B9%E3%83%88%E3%83%A1%E3%83%8B%E3%83%A5%E3%83%BC)
  - [ピン留め定義一覧画面](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%83%94%E3%83%B3%E7%95%99%E3%82%81%E5%AE%9A%E7%BE%A9%E4%B8%80%E8%A6%A7%E7%94%BB%E9%9D%A2)
  - [ピン留め編集画面](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%83%94%E3%83%B3%E7%95%99%E3%82%81%E7%B7%A8%E9%9B%86%E7%94%BB%E9%9D%A2)
  - [設定画面](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E8%A8%AD%E5%AE%9A%E7%94%BB%E9%9D%A2)
- [お勧め設定](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%81%8A%E5%8B%A7%E3%82%81%E8%A8%AD%E5%AE%9A)
- [参考資料](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E5%8F%82%E8%80%83%E8%B3%87%E6%96%99)

---

# Spacious Start Menu

これは、画面領域全体を活用できるプログラムランチャーです。

フルスクリーンで一覧できるため、ユーザーは煩雑なスクロール操作から解放されます。

![image00j](https://user-images.githubusercontent.com/99333667/174457163-3da6ae21-8f1c-44f1-b8e2-17661217eed0.png)

# 要件

- Windows10以降
- .NET6デスクトップ ランタイム

# インストール

## ステップ1

[.NET 6.0 (Linux、macOS、Windows) をダウンロードする](https://dotnet.microsoft.com/download/dotnet/6.0)から`x64`のリンクでダウンロード・インストールを実行します。

## ステップ2

[Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases)から`SpaciousStartMenu.zip`をダウンロードします。

zipを右クリック、`プロパティ`を選択して、`許可する`にチェックを入れ、`OK`ボタンで閉じます。

![image01j](https://user-images.githubusercontent.com/99333667/174457149-cec1fba3-8a9b-4403-b72f-6320fdb71891.png)

zipを解凍し、管理者権限を必要としない場所に配置します。

# 使い方

`SpaciousStartMenu.exe`を起動します。

画面を右クリックし、`ピン留めの編集`を選択して定義を追加します。

ボタンをクリックすると、アプリケーションやフォルダなどを起動できます。

## メイン画面のコンテキストメニュー

| メニュー項目             | 説明                                          |
| --------------------- | ---------------------------------------------------- |
| ピン留めの編集              | ピン留め定義一覧画面を表示します。 |
| 表示倍率                 | ボタン等の表示倍率を変更します。`Ctrl`+マウスホイール回転でも変更できます。        |
| 設定              | 設定画面を表示します。                        |
| プログラムの場所を開く | このプログラムが配置されているフォルダを開きます。       |
| プログラムの場所を開いて終了 | このプログラムが配置されているフォルダを開き、プログラムを終了します。このメニュー項目は、設定で有効化できます。       |

## ピン留め定義一覧画面

コンテキストメニューの`ピン留めの編集`で表示される一覧画面です。

一覧をダブルクリックするか、右端の編集アイコンをクリックするか、`行の追加`ボタンをクリックして編集画面を開きます。

削除（ごみ箱）アイコンをチェックした場合、`保存`ボタンが押されたタイミングで実際の削除が行われます。

![imagePin1j](https://user-images.githubusercontent.com/99333667/174457446-42afa570-6c3a-4ebc-8654-ceeab036ba09.png)

## ピン留め編集画面

個々の定義の編集画面です。

`見出し`選択時は`タイトル`のみ入力可です。

`パス`はドラッグ&ドロップでファイルやフォルダーを指定することや、特殊フォルダーや環境変数を使用することもできます。

`作業フォルダー`と`引数`は任意入力です。

![imagePin2j](https://user-images.githubusercontent.com/99333667/174457517-dedf7606-a5b5-4dc2-b866-ebddc2aecea8.png)

色選択メニューです。

![imagePin3j](https://user-images.githubusercontent.com/99333667/174457579-1336cbb4-372d-41cc-a73b-006624335da8.png)

特殊フォルダー・環境変数選択メニューです。

![imagePin4j](https://user-images.githubusercontent.com/99333667/174457533-16cf8a2a-d363-441b-97b7-e4ce3a2a0f43.png)

## 設定画面

![imageStg1j](https://user-images.githubusercontent.com/99333667/174457536-20e83bf3-db9f-4310-bde8-9532b168b5e8.png)

# お勧め設定

タスクバーアイコンを左端の位置に移動します。

![image10](https://user-images.githubusercontent.com/99333667/169648188-5ecdc736-b12d-403e-ba67-5c9d5648b46d.png)

タスクバーにピン留めします。

![image11j](https://user-images.githubusercontent.com/99333667/174457313-ebb5c6a7-8083-4dfa-8c36-6a55cfd648f0.png)

これで`Win` + `1`のショートカットキーでメニューを起動またはアクティブにできます。

# 参考資料

- [https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5](https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5)

