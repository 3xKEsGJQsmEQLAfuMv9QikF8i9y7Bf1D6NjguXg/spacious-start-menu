## Lists

### 🔷Mouse gestures

|Gestures|Description|
|:---------|:--|
|Minimized|Minimize main screen|
|Show desktop|Show desktop|
|Zoom in|Zoom in main screen|
|Zoom out|Zoom out main screen|
|Scroll to top|Scroll main screen to top|
|Scroll to bottom|Scroll main screen to end|
|Scroll to up|Scroll main screen up|
|Scroll to down|Scroll down the main screen|
|Show pinned definition list|Show pinned definition list|
|Show Spacious Start Menu settings screen|Show settings screen|
|Close all folders|Close all open folder windows in explorer|
|List folders|List open folder windows in explorer|
|Highlight of recently used launch buttons|Highlight recently used launch buttons for a certain period of time|

[Back](usage.md#15-mouse-gestures)

### 🔷Special folders

|Special folder|Specification method|Examples of expanded values|
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

[Back](usage.md#33-special-folders-and-environment-variables)

### 🔷Environment variables

|Environment variable|Specification method|Examples of expanded values|
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

[Back](usage.md#33-special-folders-and-environment-variables)

### 🔷Special commands

|Special commands|Specification method|Description|
|:----|:----|:----|
|System_Signout|`<CMD:System_Signout>`|Sign out|
|System_Shutdown|`<CMD:System_Shutdown>`|Shut down|
|System_Restart|`<CMD:System_Restart>`|Restart|
|App_Minimized|`<CMD:App_Minimized>`|Minimize main screen|
|App_ZoomIn|`<CMD:App_ZoomIn>`|Zoom in main screen|
|App_ZoomOut|`<CMD:App_ZoomOut>`|Zoom out main screen|
|App_ScrollToTop|`<CMD:App_ScrollToTop>`|Scroll main screen to top|
|App_ScrollToBottom|`<CMD:App_ScrollToBottom>`|Scroll main screen to end|
|App_ScrollToUp|`<CMD:App_ScrollToUp>`|Scroll main screen up|
|App_ScrollToDown|`<CMD:App_ScrollToDown>`|Scroll down the main screen|
|App_ReloadPinDefine|`<CMD:App_ReloadPinDefine>`|Reload launch button definition|
|Desktop_Show|`<CMD:Desktop_Show>`|Show desktop|
|PinEditList_Show|`<CMD:PinEditList_Show>`|Show pinned definition list|
|Settings_Show|`<CMD:Settings_Show>`|Show settings screen|
|Explorer_CloseAllFolders|`<CMD:Explorer_CloseAllFolders>`|Close all open folder windows in explorer|
|Explorer_ListFolders|`<CMD:Explorer_ListFolders>`|List open folder windows in explorer|
|Info_LaunchButtonCount|`<CMD:Info_LaunchButtonCount>`|Show the number of launch buttons|
|Info_GroupTitleCount|`<CMD:Info_GroupTitleCount>`|Show launch button's headline count|

[Back](usage.md#34-special-commands)

### 🔷shortcut keys

#### 💠Main screen

| key                                        | description                                                                        |
| :----------------------------------------- | :--------------------------------------------------------------------------------- |
| `Ctrl` + click the launch button           | Minimization of the main screen is suppressed when the application is launched[^1] |
| `Ctrl` + `Shift` + click the launch button | Run as administrator                                                               |
| `Ctrl` + `F`                               | highlight the launch button[^1]                                                    |
| `Ctrl` + mouse wheel up rotation           | Zoom in                                                                            |
| `Ctrl` + mouse wheel down rotation         | Zoom out                                                                           |
| `Esc`                                      | minimize main screen[^1]                                                           |
| `Ctrl` + `,`                               | show Settings screen                                                               |

[^1]: If the function is enabled in the settings

[戻る](usage.md#11-overview)

#### 💠Pin edit screen

| key          | description            |
| :----------- | :--------------------- |
| `Ctrl` + `↑` | focus on upper control |
| `Ctrl` + `↓` | focus on lower control |
| `Ctrl` + `←` | Focus on left control  |
| `Ctrl` + `→` | Focus on right control |

[戻る](usage.md#31-overview)

---

| [Index](index.md) | [Install](install.md) | [Update](update.md) | [Uninstall](uninstall.md) | Usage | [Other](other.md) |
