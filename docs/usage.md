# Usage

Launch `SpaciousStartMenu.exe`.

Right-click on the screen and select `Edit Pinning` to add a definition.

Launch defined applications, folders, etc. at the click of a button.

- [Main screen](#main-screen)
- [Pinned definition list screen](#pinned-definition-list-screen)
- [Pin edit screen](#pin-edit-screen)
- [Settings screen](#settings-screen)

## 🔷Main screen

You can open a folder or start a program by pressing the launch button.

For executable programs, you can run them as an administrator by pressing the launch button while holding down `Ctrl` + `Shift`.

### 💠Context menu

It is displayed by right-clicking the `...` button on the title bar or the margin other than the launch button.

| Menu item             | Description                                          |
| --------------------- | ---------------------------------------------------- |
| Edit Pin              | Displays the edit screen of the item to be launched. |
| Scale                 | Changes the display magnification of an item. You can also change the scale by rotating Ctrl + mouse wheel on the main screen. |
| Settings              | Displays the settings screen.                        |
| Open Program Location | Open the folder where this program is located.       |
| Open the program location and then exit the program | Open the folder where this program is located and exit the program. This menu item can be displayed in the settings.       |

### 💠Zoom in/out

You can zoom in/out by pressing the `+`, `-` buttons on the context menu or by holding down the `Ctrl` key and rotating the mouse wheel.

#### Zoom in

![Zoom in](img/main02.png)

#### Zoom out

![Zoom out](img/main01.png)

## 🔷Pinned definition list screen

This is the list screen displayed by `Edit Pin`.

Double-click the list, click the Edit button on the far right, or click the `Add row` button to open the edit screen.

If you select the delete (trash can) icon on the far right or press the `Delete` key, the actual deletion will occur when the `Save` button is pressed.

![Pinned definition list](img/pinList01.png)

## 🔷Pin edit screen

Edit screen.

When `Headline` is selected, only `Title` can be entered.
If you want to draw a line to separate groups, select `Headline` and press the `Separator` button. The `Title` will be set to the string `--------------------` which will be recognized as a separator.

![Select headline](img/pinEdit04.png)

The `Path` field allows you to enter files and folders by drag & drop.

The `Working Directory` and `Arguments` are optional.

![Pin edit](img/pinEdit01.png)

Color selection menu.

![Pin edit color selection](img/pinEdit02.png)

Special folders and environment variables selection menu.

![Pin edit special folders](img/pinEdit03.png)

Selecting `Special command` will give you a choice of several commands that are not application launches. When you select a command from the choices, the `Title` is also set automatically, but can be changed to any name later.

![Pin edit special command](img/pinEdit05.png)

Select `Landmark` to place a label for the emoji. Use it as a separator for launch buttons or as a landmark when looking for a button.

![Landmark](img/pinEdit06.png)

## 🔷Settings screen

![Settings](img/stg01.png)

### 💠Setup

#### Register to startup

Register a shortcut on startup.

#### Add a minimize launch option to the shortcut

Add the option to start in minimized state to the command line when registering a shortcut to startup.
This setting is unnecessary if `Start in minimized state` is enabled.

#### Remove from Startup

Remove the shortcut from startup.

#### Export settings

Outputs definitions of launch buttons and various settings to a file.

#### Import settings

Load the settings exported by the `Export settings` function.

### 💠Minimize

#### Start in minimized state

Minimize when the application starts.

#### Minimize menu with Esc key

Causes the main screen to be minimized when the `Esc` key is pressed.

#### Minimize by double-clicking on the screen margin

Minimize the main screen when you double-click a part other than the startup button on the main screen.

#### Suppresses menu minimization when pressing the launch button while holding down the Ctrl key

Normally, pressing the launch button minimizes the main screen, but we don't want it to minimize when pressing the `Ctrl` key while pressing the launch button.

### 💠Title bar

#### Show modifier key status on the title bar

Displays the mode in the title bar while the `Ctrl` key or `Ctrl` + `Shift` key is pressed.

#### Show logged-in user in title bar

The name of the logged-in user is displayed in the upper right corner of the title bar.

### 💠Launch button headline

#### Show sequential numbers in headings

Displays sequential numbers on group headings from top to bottom.

### 💠Confirm

#### Confirm when exiting from the button on the title bar

A confirmation dialog is displayed when the close button on the upper right of the title bar is pressed.

### 💠Context menu

#### Show `Open the program location and then exit the program` menu

In the context menu, display a menu item to open the folder where `Spacious Start Menu` is located in Explorer and then exit the program.

### 💠Child screen

#### Save screen size

Save the size of each screen.

#### Save screen position

Save the position of each screen.

### 💠Advanced options

#### Direct definition file edit button on the `Pinned definition list` screen

A button to switch to the mode for directly editing the definition file is displayed at the bottom left of the pinned definition list screen.

### 💠About

Displays the version of `Spatial Start Menu` and the version of .NET runtime.

---

| [Index](index.md) | [Install](install.md) | [Update](update.md) | [Uninstall](uninstall.md) | Usage | [Other](other.md) |
