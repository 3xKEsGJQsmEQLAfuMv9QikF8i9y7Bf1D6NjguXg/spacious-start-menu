## Usage

Launch `SpaciousStartMenu.exe`. A sample launch button definition is generated on first launch.

Edit the launch button definition by right-clicking on the screen and choosing `Edit Pin`. This work is equivalent to pinning in the **Start Menu**.

Click the launch button to start an application, folder, etc.

- [Main screen](#main-screen)
- [Pinned definition list screen](#pinned-definition-list-screen)
- [Pin edit screen](#pin-edit-screen)
- [Settings screen](#settings-screen)

### 🔷Main screen

#### 💠Overview

You can open a folder or start a program by pressing the launch button.

For executable programs, you can run them as an administrator by pressing the launch button while holding down `Ctrl` + `Shift`.

#### 💠Context menu

It is displayed by right-clicking the `...` button on the title bar or the margin other than the launch button.

| Menu item             | Description                                          |
| --------------------- | ---------------------------------------------------- |
| Edit Pin              | Displays the edit screen of the item to be launched. |
| Scale                 | Changes the display magnification of an item. You can also change the scale by rotating Ctrl + mouse wheel on the main screen. |
| Settings              | Displays the settings screen.                        |
| Open Program Location | Open the folder where this program is located.       |
| Open the program location and then exit the program | Open the folder where this program is located and exit the program. This menu item can be shown/hidden in the settings.       |

#### 💠Title bar

##### 🔹Modifier key status

While pressing a modifier key such as `Ctrl` or `Shift`, the mode valid for the key being pressed is displayed.
You can switch display/hide and display position on the setting screen.

![Modifier key status in title bar](img/titleBar01.png)

##### 🔹Logged-in user

Shows currently logged in user. You can switch display/hide on the settings screen.
Click to sign out, shut down, or restart.

![Login user in title bar](img/titleBar02.png)

#### 💠Zoom in/out

You can zoom in/out by pressing the `+`, `-` buttons on the context menu or by holding down the `Ctrl` key and rotating the mouse wheel.

##### 🔹Zoom in

Largest view of Spacious Start Menu.

![Zoom in](img/main02.png)

##### 🔹Zoom out

Smallest view of Spacious Start Menu.

![Zoom out](img/main01.png)

### 🔷Pinned definition list screen

This is a list of launch buttons, etc., displayed by `Edit Pin` in the context menu.

Double-click the list, click the edit icon at the right end of the list, or click the `Add Row` button or `Edit Row` button below to open the edit screen.

If you select the delete (trash can) icon on the far right or press the `Delete` key, the actual deletion will occur when the `Save` button is pressed.

![Pinned definition list](img/pinList01.png)

### 🔷Pin edit screen

#### 💠Overview

Edit screen.

When `Headline` is selected, only `Title` can be entered.
If you want to draw a line to separate groups, select `Headline` and press the `Separator` button. The `Title` will be set to the string `--------------------` which will be recognized as a separator.

![Select headline](img/pinEdit04.png)

The `Path` field allows you to enter files and folders by drag & drop.

The `Working Directory` and `Arguments` are optional.

![Pin edit](img/pinEdit01.png)

#### 💠Color

Color selection menu.

![Pin edit color selection](img/pinEdit02.png)

#### 💠Special folders and environment variables

Special folders and environment variables selection menu.

![Pin edit special folders](img/pinEdit03.png)

- [List of special folders](table.md#special-folders)
- [List of environment variables](table.md#environment-variables)

#### 💠Special Commands

Selecting `Special commands` will give you a choice of several commands that are not application launches. When you select a command from the choices, the `Title` is also set automatically, but can be changed to any name later.

![Pin edit special command](img/pinEdit05.png)

- [List of special commands](table.md#special-commands)

##### 🔹Display example of special commands

![Examples of special commands](img/spCmd01.png)

#### 💠Landmark

Select `Landmark` to place a label for the emoji. Use it as a separator for launch buttons or as a landmark when looking for a button.

![Landmark](img/pinEdit06.png)

### 🔷Settings screen

![Settings](img/stg01.png)

#### 💠Setup

##### 🔹Register to startup

Register the `Spacious Start Menu` shortcut in Startup.

##### 🔹Add a minimize launch option to the shortcut

Add the option to start in minimized state to the command line when registering a shortcut to startup.
This setting is unnecessary if `Start in minimized state` is enabled.

##### 🔹Remove from Startup

Remove the `Spacious Start Menu` shortcut from Startup.

##### 🔹Export settings

Outputs definitions of launch buttons and various settings to a file.

##### 🔹Import settings

Load the settings exported by the `Export settings` function.

#### 💠Minimize

##### 🔹Start in minimized state

Minimize when the application starts.

##### 🔹Minimize menu with Esc key

Causes the main screen to be minimized when the `Esc` key is pressed.

##### 🔹Minimize by double-clicking on the screen margin

Minimize the main screen when you double-click a part other than the startup button on the main screen.

##### 🔹Suppresses menu minimization when pressing the launch button while holding down the Ctrl key

Normally, pressing the launch button minimizes the main screen, but we don't want it to minimize when pressing the `Ctrl` key while pressing the launch button.

#### 💠Title bar

##### 🔹Show modifier key status on the title bar

While pressing a modifier key such as `Ctrl` or `Shift`, the title bar displays the mode that is valid for the key being pressed.

![Modifier key status in title bar](img/titleBar01.png)

##### 🔹Show logged-in user in title bar

The name of the logged-in user is displayed in the upper right corner of the title bar.

![Login user in title bar](img/titleBar02.png)

#### 💠Launch button headline

##### 🔹Show sequential numbers in headings

Displays sequential numbers on group headings from top to bottom.

#### 💠Bottom area

##### 🔹Show desktop button

Specify the height and width of the **Show desktop button** at the bottom right of the main screen.

![Show desktop button](img/desktopBtn01.png)

![Show desktop button large size](img/desktopBtn02.png)

#### 💠Confirm

##### 🔹Confirm when exiting from the button on the title bar

A confirmation dialog is displayed when the close button on the upper right of the title bar is pressed.

#### 💠Context menu

##### 🔹Show `Open the program location and then exit the program` menu

In the context menu, display a menu item to open the folder where Spacious Start Menu is located in Explorer and then exit the program.

#### 💠Child screen

##### 🔹Save screen size

Save the size of each screen.

##### 🔹Save screen position

Save the position of each screen.

#### 💠Advanced options

##### 🔹Direct definition file edit button on the `Pinned definition list` screen

A button to switch to the mode for directly editing the definition file is displayed at the bottom left of the pinned definition list screen.

#### 💠About

Displays the version of Spatial Start Menu and the version of .NET runtime.

---

| [Index](index.md) | [Install](install.md) | [Update](update.md) | [Uninstall](uninstall.md) | Usage | [Other](other.md) |
