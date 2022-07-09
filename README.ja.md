
- [Spacious Start Menu](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#spacious-start-menu)
- [要件](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E8%A6%81%E4%BB%B6)
- [インストール](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%BC%E3%83%AB)
- [バージョンアップ](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%B3%E3%82%A2%E3%83%83%E3%83%97)
- [アンインストール](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/blob/main/README.ja.md#%E3%82%A2%E3%83%B3%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%BC%E3%83%AB)
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

![image00](https://user-images.githubusercontent.com/99333667/177764163-f8ecca7f-f4e0-4d81-878d-cbbcf83f6786.png)

# 🟦要件

- Windows10以降
- .NET6 デスクトップ ランタイム

# 🟦インストール

## 🔷ステップ1

[.NET 6.0 (Linux、macOS、Windows) をダウンロードする](https://dotnet.microsoft.com/download/dotnet/6.0)の`.NET デスクトップ ランタイム`の`x64`リンクからダウンロード・インストールを実行します。

## 🔷ステップ2

<details open>
<summary>💠手動インストールの場合</summary>

[Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases)から`SpaciousStartMenu.zip`をダウンロードします。

zipを右クリック、`プロパティ`を選択して、`許可する`にチェックを入れ、`OK`ボタンで閉じます。

![image01j](https://user-images.githubusercontent.com/99333667/174457149-cec1fba3-8a9b-4403-b72f-6320fdb71891.png)

zipを解凍し、管理者権限を必要としない任意の場所に配置します。
</details>

<details>
<summary>💠Scoopを使用したインストールの場合</summary>

**🔹Scoopのインストール**

省略

**🔹bucketの追加**

```
scoop bucket add 3xkesg https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/scoop-3xke
```

**🔹アプリのインストール**

```
scoop install spacious-start-menu
```

</details>

# 🟦バージョンアップ

`Spacious Start Menu`を起動していたら終了しておきます。

<details open>
<summary>💠手動インストールの場合</summary>

[Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases)から`SpaciousStartMenu.zip`をダウンロードします。

zipを右クリック、`プロパティ`を選択して、`許可する`にチェックを入れ、`OK`ボタンで閉じます。

zipを解凍し、展開ファイルを前回配置場所に上書きコピーします。
</details>

<details>
<summary>💠Scoopを使用したインストールの場合</summary>

**🔹scoopとアプリのアップデート**

以下のコマンドを実行します。

```
scoop update
scoop update spacious-start-menu
```
</details>

# 🟦アンインストール

`Spacious Start Menu`を起動していたら終了しておきます。

<details open>
<summary>💠手動インストールの場合</summary>

展開フォルダごと削除します。
</details>

<details>
<summary>💠Scoopを使用したインストールの場合</summary>

**🔹アプリのアンインストール**

以下のコマンドを実行します。

```
scoop uninstall spacious-start-menu
```

**🔹bucketの削除**

以下のコマンドを実行します。

```
scoop bucket rm 3xkesg
```
</details>

# 🟦使い方

`SpaciousStartMenu.exe`を起動します。

画面を右クリックし、`ピン留めの編集`を選択して定義を追加します。

ボタンをクリックすると、アプリケーションやフォルダなどを起動できます。

## 🔷メイン画面のコンテキストメニュー

| メニュー項目             | 説明                                          |
| --------------------- | ---------------------------------------------------- |
| ピン留めの編集              | ピン留め定義一覧画面を表示します。 |
| 表示倍率                 | ボタン等の表示倍率を変更します。メイン画面上で`Ctrl`+マウスホイール回転でも変更できます。        |
| 設定              | 設定画面を表示します。                        |
| プログラムの場所を開く | このプログラムが配置されているフォルダを開きます。       |
| プログラムの場所を開いて終了 | このプログラムが配置されているフォルダを開き、プログラムを終了します。このメニュー項目は、設定で有効化できます。       |

## 🔷ピン留め定義一覧画面

コンテキストメニューの`ピン留めの編集`で表示される一覧画面です。

一覧をダブルクリックするか、右端の編集アイコンをクリックするか、`行の追加`ボタンをクリックして編集画面を開きます。

削除（ごみ箱）アイコンをチェックした場合、`保存`ボタンが押されたタイミングで実際の削除が行われます。

![imagePin1j](https://user-images.githubusercontent.com/99333667/174482913-62648e8f-47f2-4e45-923d-8372a65e599c.png)

## 🔷ピン留め編集画面

個々の定義の編集画面です。

`見出し`選択時は`タイトル`のみ入力可です。

`パス`はドラッグ&ドロップでファイルやフォルダーを指定することや、特殊フォルダーや環境変数を使用することもできます。

`作業フォルダー`と`引数`は任意入力です。

![imagePin2j](https://user-images.githubusercontent.com/99333667/175758328-fe293af9-f4c8-4ce9-b80f-e4408e6c1e91.png)

色選択メニューです。

![imagePin3j](https://user-images.githubusercontent.com/99333667/175758335-94a75dcb-75a9-4b92-88dc-5fe8ca51667a.png)

特殊フォルダー・環境変数選択メニューです。

![imagePin4j](https://user-images.githubusercontent.com/99333667/175758353-260a082d-0747-420e-9184-8848b59363d3.png)

## 🔷設定画面

![imageStg](https://user-images.githubusercontent.com/99333667/177764226-bbfa2dd6-c84a-44c4-9348-1c028754c6cd.png)

# 🟦お勧め設定

タスクバーアイコンを左端の位置に移動します。

![image10](https://user-images.githubusercontent.com/99333667/169648188-5ecdc736-b12d-403e-ba67-5c9d5648b46d.png)

タスクバーにピン留めします。

![image11j](https://user-images.githubusercontent.com/99333667/174457313-ebb5c6a7-8083-4dfa-8c36-6a55cfd648f0.png)

これで`Win` + `1`のショートカットキーでメニューを起動またはアクティブにできます。

# 🟦参考資料

- [https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5](https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5)

