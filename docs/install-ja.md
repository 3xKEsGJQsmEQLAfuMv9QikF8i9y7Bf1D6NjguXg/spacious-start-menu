
## インストール

### 🔷ステップ1

[.NET 8.0 (Linux、macOS、Windows) をダウンロードする](https://dotnet.microsoft.com/ja-jp/download/dotnet/8.0)の `.NET デスクトップ ランタイム` の `x64` リンクからダウンロード・インストールを実行します。

### 🔷ステップ2

#### 💠手動インストールの場合

[Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases)から `SpaciousStartMenu.zip` をダウンロードします。

zipを右クリック、 `プロパティ` を選択して、 `許可する` にチェックを入れ、 `OK` ボタンで閉じます。

![プロパティ](img/install01-ja.png)
  
zipを解凍し、管理者権限を必要としない任意の場所に配置します。

#### 💠Scoopを使用したインストールの場合（ユーザー単位）

##### 🔹Scoopのインストール

[こちらを参照](https://scoop.sh/)

##### 🔹Gitのインストール

Gitがインストールされていない場合は、以下のコマンドを実行します。

```
scoop install git
```

##### 🔹bucketの追加

以下のコマンドを実行します。

```
scoop bucket add 3xkesg https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/scoop-3xke
```

##### 🔹アプリのインストール

以下のコマンドを実行します。

```
scoop install spacious-start-menu
```

#### 💠Chocolateyを使用したインストールの場合（すべてのユーザーで共通）

##### 🔹Chocolateyのインストール

[こちらを参照](https://chocolatey.org/install)

🔹アプリのインストール

以下のコマンドを管理者として実行します。

```
choco install spacious-start-menu
```

---

| [目次・概要](index-ja.md) | インストール | [アップデート](update-ja.md) | [アンインストール](uninstall-ja.md) | [使い方](usage-ja.md) | [その他](other-ja.md) |


