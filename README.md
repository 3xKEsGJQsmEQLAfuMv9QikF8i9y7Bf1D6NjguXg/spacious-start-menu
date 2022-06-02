# Spacious Start Menu

A launcher that can use the entire screen area.

![image00](https://user-images.githubusercontent.com/99333667/171615512-c89fbc54-c051-4acf-b616-f76338a8a635.png)

# Requirements

- Windows 10 or lator
- .NET 6 Desktop Runtime

# Install

Download and install `x64` of `.NET Desktop Runtime 6.x` from [Download .NET 6.0 (Linux, macOS, and Windows)](https://dotnet.microsoft.com/download/dotnet/6.0).

Download `SpaciousStartMenu.zip` from [Releases](https://github.com/3xKEsGJQsmEQLAfuMv9QikF8i9y7Bf1D6NjguXg/spacious-start-menu/releases).

Right-click on the zip, select Properties, check `Unblock` and close with the OK button.

![image01](https://user-images.githubusercontent.com/99333667/169164842-892d479f-7def-4044-ab0a-9b404d0ce194.png)

Extract the zip and place it in any location that does not require administrative privileges.

# Usage

Launch `SpaciousStartMenu.exe`.

Right-click on the screen and select `Edit Pinning` to add a definition.

Launch defined applications, folders, etc. at the click of a button.

## Main screen context menu

| Menu item             | Description                                          |
| --------------------- | ---------------------------------------------------- |
| Edit Pinning           | Displays the edit screen of the item to be launched. |
| Scale                 | Changes the display magnification of an item.        |
| Settings              | Displays the settings screen.                        |
| Open Program Location | Open the folder where this program is located.       |
| Open the program location and then exit the program | Open the folder where this program is located and exit the program. This menu item can be displayed in the settings.       |

## Pinned definition list screen

This is the screen displayed by `Edit Pinning`.

Double-click the list, click the Edit button on the far right, or click the `Add row` button to open the editing window.

Deletion of a checked line is confirmed when the `Save` button is pressed.

![image20](https://user-images.githubusercontent.com/99333667/171615972-7b647655-0b01-42b2-ace3-cd85a3a0813e.png)

## Pinning Edit Screen

Edit screen.

The `Path` field allows you to enter files and folders by drag & drop.

When `Heading` is selected, only `Title` can be entered.

![image21](https://user-images.githubusercontent.com/99333667/171616112-08fa2c48-a75f-43e3-bb29-b92dd346cea7.png)

Color selection menu.

![image22](https://user-images.githubusercontent.com/99333667/171616144-531c6a2d-f831-4e0c-a3a5-5fb8402ec814.png)

## Settings screen

![image23](https://user-images.githubusercontent.com/99333667/171616189-3366389f-e645-4324-9927-26d21c7b2bc7.png)

- Setup
  - Register to startup
  - Remove from Startup
  - Minimize when starting from startup
- Minimize
  - Esc key to minimize
  - Minimize by double-clicking on the menu margin
  - Minimization is suppressed when the launch button is pressed while the Ctrl key is held down
- Confirm
  - Confirm when exiting menu
- Context menu
  - Show `Open the program location and then exit the program` menu

# Recommended initial settings

Move the taskbar icon to the leftmost position.

![image10](https://user-images.githubusercontent.com/99333667/169648188-5ecdc736-b12d-403e-ba67-5c9d5648b46d.png)

Pin it to the taskbar.

![image11](https://user-images.githubusercontent.com/99333667/169648202-b4ef02dc-9e97-4d80-b23c-77b07a92baa0.png)

This allows the menu to be launched or activated with `Win` + `1`.

# Reference

- [https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5](https://qiita.com/Kosen-amai/items/61e6b03b8e0fccc35ee5)
