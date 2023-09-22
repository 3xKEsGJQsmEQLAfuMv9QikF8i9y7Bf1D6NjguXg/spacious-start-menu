## 表

### 🔷マウスジェスチャー

|ジェスチャー|説明|
|:---------|:--|
|最小化|メイン画面を最小化|
|デスクトップの表示|デスクトップを表示|
|拡大|メイン画面を拡大|
|縮小|メイン画面を縮小|
|先頭にスクロール|メイン画面の先頭にスクロール|
|末尾にスクロール|メイン画面の末尾にスクロール|
|上にスクロール|メイン画面を上にスクロール|
|下にスクロール|メイン画面を下にスクロール|
|ピン留め定義一覧画面を表示|ピン留め定義一覧画面を表示|
|Spacious Start Menuの設定画面を表示|設定画面を表示|
|すべてのフォルダーを閉じる|エクスプローラーで開いているフォルダーウィンドウをすべて閉じる|
|フォルダーを一覧表示|エクスプローラーで開いているフォルダーウィンドウを一覧表示|

[戻る](usage-ja.md#15-%E3%83%9E%E3%82%A6%E3%82%B9%E3%82%B8%E3%82%A7%E3%82%B9%E3%83%81%E3%83%A3%E3%83%BC)

### 🔷特殊フォルダー

|特殊フォルダー|指定方法|展開される値の例|
|:----|:----|:----|
|ApplicationData|`<ApplicationData>`|C:\Users\USER123\AppData\Roaming|
|CommonApplicationData|`<CommonApplicationData>`|C:\ProgramData|
|Cookies|`<Cookies>`|C:\Users\USER123\AppData\Local\Microsoft\Windows\INetCookies|
|DesktopDirectory|`<DesktopDirectory>`|C:\Users\USER123\Desktop|
|Favorites|`<Favorites>`|C:\Users\USER123\Favorites|
|Fonts|`<Fonts>`|C:\WINDOWS\Fonts|
|History|`<History>`|C:\Users\USER123\AppData\Local\Microsoft\Windows\History|
|InternetCache|`<InternetCache>`|C:\Users\USER123\AppData\Local\Microsoft\Windows\INetCache|
|LocalApplicationData|`<LocalApplicationData>`|C:\Users\USER123\AppData\Local|
|MyDocuments|`<MyDocuments>`|C:\Users\USER123\Documents|
|MyMusic|`<MyMusic>`|C:\Users\USER123\Music|
|MyPictures|`<MyPictures>`|C:\Users\USER123\Pictures|
|MyVideos|`<MyVideos>`|C:\Users\USER123\Videos|
|ProgramFiles|`<ProgramFiles>`|C:\Program Files|
|ProgramFilesX86|`<ProgramFilesX86>`|C:\Program Files (x86)|
|Programs|`<Programs>`|C:\Users\USER123\AppData\Roaming\Microsoft\Windows\Start Menu\Programs|
|SendTo|`<SendTo>`|C:\Users\USER123\AppData\Roaming\Microsoft\Windows\SendTo|
|StartMenu|`<StartMenu>`|C:\Users\USER123\AppData\Roaming\Microsoft\Windows\Start Menu|
|Startup|`<Startup>`|C:\Users\USER123\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup|
|System|`<System>`|C:\WINDOWS\system32|
|SystemX86|`<SystemX86>`|C:\WINDOWS\SysWOW64|
|UserProfile|`<UserProfile>`|C:\Users\USER123|
|Windows|`<Windows>`|C:\WINDOWS|

[戻る](usage-ja.md#33-%E7%89%B9%E6%AE%8A%E3%83%95%E3%82%A9%E3%83%AB%E3%83%80%E3%83%BC%E7%92%B0%E5%A2%83%E5%A4%89%E6%95%B0)

### 🔷環境変数

|環境変数|指定方法|展開される値の例|
|:----|:----|:----|
|ALLUSERSPROFILE|`<ENV:ALLUSERSPROFILE>`|C:\ProgramData|
|APPDATA|`<ENV:APPDATA>`|C:\Users\USER123\AppData\Roaming|
|LOCALAPPDATA|`<ENV:LOCALAPPDATA>`|C:\Users\USER123\AppData\Local|
|PROGRAMDATA|`<ENV:PROGRAMDATA>`|C:\ProgramData|
|PROGRAMFILES|`<ENV:PROGRAMFILES>`|C:\Program Files|
|PROGRAMFILES(X86)|`<ENV:PROGRAMFILES(X86)>`|C:\Program Files (x86)|
|SYSTEMROOT|`<ENV:SYSTEMROOT>`|C:\WINDOWS|
|TEMP|`<ENV:TEMP>`|C:\Users\USER123\AppData\Local\Temp|
|TMP|`<ENV:TMP>`|C:\Users\USER123\AppData\Local\Temp|
|USERPROFILE|`<ENV:USERPROFILE>`|C:\Users\USER123|

[戻る](usage-ja.md#33-%E7%89%B9%E6%AE%8A%E3%83%95%E3%82%A9%E3%83%AB%E3%83%80%E3%83%BC%E7%92%B0%E5%A2%83%E5%A4%89%E6%95%B0)

### 🔷特殊コマンド

|特殊コマンド|指定方法|説明|
|:----|:----|:----|
|System_Signout|`<CMD:System_Signout>`|サインアウト|
|System_Shutdown|`<CMD:System_Shutdown>`|シャットダウン|
|System_Restart|`<CMD:System_Restart>`|再起動|
|App_Minimized|`<CMD:App_Minimized>`|メイン画面を最小化|
|App_ZoomIn|`<CMD:App_ZoomIn>`|メイン画面を拡大|
|App_ZoomOut|`<CMD:App_ZoomOut>`|メイン画面を縮小|
|App_ScrollToTop|`<CMD:App_ScrollToTop>`|メイン画面の先頭にスクロール|
|App_ScrollToBottom|`<CMD:App_ScrollToBottom>`|メイン画面の末尾にスクロール|
|App_ScrollToUp|`<CMD:App_ScrollToUp>`|メイン画面を上にスクロール|
|App_ScrollToDown|`<CMD:App_ScrollToDown>`|メイン画面を下にスクロール|
|App_ReloadPinDefine|`<CMD:App_ReloadPinDefine>`|起動ボタン定義を再読み込み|
|Desktop_Show|`<CMD:Desktop_Show>`|デスクトップを表示|
|PinEditList_Show|`<CMD:Settings_Show>`|ピン留め定義一覧画面を表示|
|Settings_Show|`<CMD:Settings_Show>`|設定画面を表示|
|Explorer_CloseAllFolders|`<CMD:Explorer_CloseAllFolders>`|エクスプローラーで開いているフォルダーウィンドウをすべて閉じる|
|Explorer_ListFolders|`<CMD:Explorer_ListFolders>`|エクスプローラーで開いているフォルダーウィンドウを一覧表示|
|Info_LaunchButtonCount|`<CMD:Info_LaunchButtonCount>`|起動ボタン数を表示|
|Info_GroupTitleCount|`<CMD:Info_GroupTitleCount>`|起動ボタンの見出し数を表示|

[戻る](usage-ja.md#34-%E7%89%B9%E6%AE%8A%E3%82%B3%E3%83%9E%E3%83%B3%E3%83%89)

---

| [目次・概要](index-ja.md) | [インストール](install-ja.md) | [アップデート](update-ja.md) | [アンインストール](uninstall-ja.md) | 使い方 | [その他](other-ja.md) |

