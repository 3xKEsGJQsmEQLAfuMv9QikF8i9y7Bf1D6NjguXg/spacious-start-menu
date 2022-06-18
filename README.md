- [Spacious Start Menu](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#spacious-start-menu)
- [Requirements](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#requirements)
- [Install](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#install)
- [Unnstall](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#uninstall)
- [Usage](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#usage)
  - [Main screen context menu](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#main-screen-context-menu)
  - [Pinned definition list screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#pinned-definition-list-screen)
  - [Pin edit screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#pin-edit-screen)
  - [Settings screen](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#settings-screen)
- [Recommended initial settings](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#recommended-initial-settings)
- [Reference](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu#reference)

---

# Spacious Start Menu

This is a program launcher that allows you to take advantage of the entire screen area.

The full screen listing frees the user from cumbersome scrolling operations.

![image00](https://user-images.githubusercontent.com/99333667/173183598-42dc5a99-e26d-4905-8d23-0abd741c329a.png)

# Requirements

- Windows 10 or later
- .NET 6 Desktop Runtime

# Install

## Step 1

Download and install `x64` of `.NET Desktop Runtime 6.x` from [Download .NET 6.0 (Linux, macOS, and Windows)](https://dotnet.microsoft.com/download/dotnet/6.0).

## Step 2

Download `SpaciousStartMenu.zip` from [Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases).

Right-click on the zip, select Properties, check `Unblock` and close with the OK button.

![image01](https://user-images.githubusercontent.com/99333667/169164842-892d479f-7def-4044-ab0a-9b404d0ce194.png)

Extract the zip and place it in any location that does not require administrative privileges.

# Uninstall

Delete the expanded folder.

# Usage

Launch `SpaciousStartMenu.exe`.

Right-click on the screen and select `Edit Pinning` to add a definition.

Launch defined applications, folders, etc. at the click of a button.

## Main screen context menu

| Menu item             | Description                                          |
| --------------------- | ---------------------------------------------------- |
| Edit Pin              | Displays the edit screen of the item to be launched. |
| Scale                 | Changes the display magnification of an item. You can also change it by holding down Ctrl and rotating the mouse wheel.      |
| Settings              | Displays the settings screen.                        |
| Open Program Location | Open the folder where this program is located.       |
| Open the program location and then exit the program | Open the folder where this program is located and exit the program. This menu item can be displayed in the settings.       |

## Pinned definition list screen

This is the list screen displayed by `Edit Pin`.

Double-click the list, click the Edit button on the far right, or click the `Add row` button to open the edit screen.

If a line is checked for deletion, the deletion will be executed when the `Save` button is clicked.

![imagePin1](https://user-images.githubusercontent.com/99333667/174437260-01ceefe0-8622-465a-9adf-32cdc8674997.png)

## Pin edit screen

Edit screen.

The `Path` field allows you to enter files and folders by drag & drop.

When `Headline` is selected, only `Title` can be entered.

![imagePin2](https://user-images.githubusercontent.com/99333667/174437286-efe1e40c-20e1-4119-93c5-02cd89a47b9b.png)

Color selection menu.

![imagePin3](https://user-images.githubusercontent.com/99333667/174437303-994dc96b-c5b4-4c5b-8299-7d2885bc3e2c.png)

Special folders and environment variables selection menu.

![imagePin4](https://user-images.githubusercontent.com/99333667/174437314-fd06abfd-19d2-4066-b7a7-f85473afa4d2.png)

## Settings screen

![imageStg](https://user-images.githubusercontent.com/99333667/174437384-e50bd045-de09-4b4e-85a1-67c9c1ea8cf3.png)

- Setup
  - Register to startup
  - Remove from Startup
  - Minimize when starting from startup
- Minimize
  - Minimize menu with Esc key
  - Minimize the menu by double-clicking on the menu margin
  - Suppresses menu minimization when pressing the launch button while holding down the Ctrl key
- Confirm
  - Confirm when exiting menu
- Context menu
  - Show `Open the program location and then exit the program` menu
- Child screen
  - Save screen size
  - Save screen position
- Advanced options
  - Direct definition file edit button on the pinned definition list screen

# Recommended initial settings

Move the taskbar icon to the leftmost position.

![image10](https://user-images.githubusercontent.com/99333667/169648188-5ecdc736-b12d-403e-ba67-5c9d5648b46d.png)

Pin it to the taskbar.

![image11](https://user-images.githubusercontent.com/99333667/169648202-b4ef02dc-9e97-4d80-b23c-77b07a92baa0.png)

This allows the menu to be launched or activated with `Win` + `1`.

# Reference

- [https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5](https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5)
