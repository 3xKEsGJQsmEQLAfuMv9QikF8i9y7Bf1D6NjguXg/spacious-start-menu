- [Spacious Start Menu](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#spacious-start-menu)
- [Requirements](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#requirements)
- [Install](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#install)
- [Update](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#update)
- [Uninstall](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#uninstall)
- [Usage](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#usage)
  - [Main screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#main-screen)
  - [Pinned definition list screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#pinned-definition-list-screen)
  - [Pin edit screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#pin-edit-screen)
  - [Settings screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#settings-screen)
- [Recommended initial settings](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#recommended-initial-settings)
- [Reference article](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#reference-article)

---

# Spacious Start Menu

This is a program launcher that allows you to take advantage of the entire screen area.

The full screen listing frees the user from cumbersome scrolling operations.

![image00](https://user-images.githubusercontent.com/99333667/177764481-10bacdda-2ee5-4bbc-aea1-99d5cd088828.png)

# 🟦Requirements

- Windows 10 or later
- .NET 6 Desktop Runtime

# 🟦Install

## 🔷Step 1

Download and install `x64` of `.NET Desktop Runtime 6.x` from [Download .NET 6.0 (Linux, macOS, and Windows)](https://dotnet.microsoft.com/download/dotnet/6.0).

## 🔷Step 2

<details open>
<summary>💠For manual installation</summary>

Download `SpaciousStartMenu.zip` from [Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases).

Right-click on the zip, select Properties, check `Unblock` and close with the OK button.

![image01](https://user-images.githubusercontent.com/99333667/169164842-892d479f-7def-4044-ab0a-9b404d0ce194.png)

Extract the zip and place it in any location that does not require administrative privileges.
</details>

<details>
<summary>💠For installation using Scoop</summary>

**🔹Scoop installation**

omit

**🔹Add bucket**

Execute the following command.

```
scoop bucket add 3xkesg https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/scoop-3xke
```

**🔹Install the app**

Execute the following command.

```
scoop install spacious-start-menu
```
</details>

# 🟦Update

If you have started the `Spacious Start Menu`, close it.

<details open>
<summary>💠For manual installation</summary>

Download `SpaciousStartMenu.zip` from [Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases).

Right-click on the zip, select Properties, check `Unblock` and close with the OK button.

Unzip the zip and copy the extracted file to the previous location.
</details>

<details>
<summary>💠For installation using Scoop</summary>

**🔹Scoop and app updates**

Execute the following command.

```
scoop update
scoop update spacious-start-menu
```
</details>

# 🟦Uninstall

If you have started the `Spacious Start Menu`, close it.

<details open>
<summary>💠For manual installation</summary>

Delete the expanded folder.
</details>

<details>
<summary>💠For installation using Scoop</summary>

**🔹Uninstall the app**

Execute the following command.

```
scoop uninstall spacious-start-menu
```

**🔹Remove bucket**

Execute the following command.

```
scoop bucket rm 3xkesg
```
</details>

# 🟦Usage

Launch `SpaciousStartMenu.exe`.

Right-click on the screen and select `Edit Pinning` to add a definition.

Launch defined applications, folders, etc. at the click of a button.

## 🔷Main screen

You can open a folder or start a program by pressing the launch button.

For executable programs, you can run them as an administrator by pressing the launch button while holding down `Ctrl` + `Shift`.

### 🔹Context menu

It is displayed by right-clicking the `...` button on the title bar or the margin other than the launch button.

| Menu item             | Description                                          |
| --------------------- | ---------------------------------------------------- |
| Edit Pin              | Displays the edit screen of the item to be launched. |
| Scale                 | Changes the display magnification of an item. You can also change the scale by rotating Ctrl + mouse wheel on the main screen. |
| Settings              | Displays the settings screen.                        |
| Open Program Location | Open the folder where this program is located.       |
| Open the program location and then exit the program | Open the folder where this program is located and exit the program. This menu item can be displayed in the settings.       |

## 🔷Pinned definition list screen

This is the list screen displayed by `Edit Pin`.

Double-click the list, click the Edit button on the far right, or click the `Add row` button to open the edit screen.

If a line is checked for deletion, the deletion will be executed when the `Save` button is clicked.

![imagePin1](https://user-images.githubusercontent.com/99333667/174482870-d9617b5d-67dd-4da4-970e-1f40ff1d471d.png)

## 🔷Pin edit screen

Edit screen.

The `Path` field allows you to enter files and folders by drag & drop.

When `Headline` is selected, only `Title` can be entered.

![imagePin2](https://user-images.githubusercontent.com/99333667/175758210-40a76450-c7c6-42ce-993c-9aab44e032ea.png)

Color selection menu.

![imagePin3](https://user-images.githubusercontent.com/99333667/175758222-c88e784f-48eb-49b2-9d29-a6ed777f6081.png)

Special folders and environment variables selection menu.

![imagePin4](https://user-images.githubusercontent.com/99333667/175758232-61659191-4736-4a7b-ae5a-b1190d472419.png)

## 🔷Settings screen

![imageStg](https://user-images.githubusercontent.com/99333667/179078153-a0a3dca2-2f42-462e-b495-5f6582cb5f75.png)

# 🟦Recommended initial settings

Move the taskbar icon to the leftmost position.

![image10](https://user-images.githubusercontent.com/99333667/178992497-734ecff4-3677-43e1-a599-ae7baf312978.png)

Pin it to the taskbar.

![image11](https://user-images.githubusercontent.com/99333667/178992577-f00f7875-a6d5-4192-87c7-cc404d1b07c0.png)

Now you can use the `Win` + `1` shortcut key to launch or activate the application, which is similar to the way the Start menu is called up.

# 🟦Reference article

- [https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5](https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5)
