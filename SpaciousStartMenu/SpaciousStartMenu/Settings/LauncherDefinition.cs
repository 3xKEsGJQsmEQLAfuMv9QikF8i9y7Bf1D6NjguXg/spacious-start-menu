using System.Collections.Generic;

namespace SpaciousStartMenu.Settings
{
    internal class LauncherDefinition
    {
        public const char Delimiter = '\t';
        public const string GroupTitleHeader = "//";
        public const int ColorOrGroupTitleColumnIndex = 0;
        public const int TitleColumnIndex = 1;
        public const int PathColumnIndex = 2;
        public const int MaxColumns = 3;

        private const string _defaultDataFormat = @"//{0}
CadetBlue	{1}	shell:Downloads
DeepSkyBlue	{2}	shell:Desktop
Silver	{3}	shell:Personal
DodgerBlue	{4}	shell:My Pictures
BlueViolet	{5}	shell:My Video
Chocolate	{6}	shell:My Music
Silver	C Drive	C:\
Gold	Local	shell:Local AppData
Gold	Apps/2.0	shell:Local AppData\Apps\2.0
Gold	Roaming	shell:AppData
Gold	Program Files (x86)	shell:ProgramFilesX86
Gold	Program Files	shell:ProgramFiles
Gold	Profile	shell:Profile
Gold	Start/Program	shell:Programs
Gold	Start/Program/Startup	shell:Startup
Gold	SendTo	shell:SendTo
Gold	Screenshots	shell:My Pictures\Screenshots
Gold	drivers/etc	shell:System\drivers\etc

//{7}
Gray	{8}	calc.exe
LightSkyBlue	{9}	notepad.exe
SkyBlue	{10}	mspaint.exe
Black	Command Prompt	cmd.exe
DodgerBlue	Windows PowerShell	PowerShell.exe
Navy	PowerShell	pwsh.exe
DimGray	Windows Terminal	wt.exe
White	Microsoft Store	shell:AppsFolder\Microsoft.WindowsStore_8wekyb3d8bbwe!App

//{11}
SkyBlue	{12}	shell:ControlPanelFolder
Gray	System Properties	SystemPropertiesAdvanced.exe
Gray	System > Display	ms-settings:display
Gray	System > Power & battery	ms-settings:powersleep
Gray	System > About	ms-settings:about
Gray	Network & internet > Ethernet	ms-settings:network-ethernet
Gray	Network & internet > Proxy	ms-settings:network-proxy
Gray	Personalization > Colors	ms-settings:personalization-colors
Gray	Personalization > Start	ms-settings:personalization-start
Gray	Personalization > Taskbar	ms-settings:taskbar
Gray	Apps > Apps & features	ms-settings:appsfeatures
Gray	Time & language > Language & region	ms-settings:regionlanguage
Gray	Windows Update	ms-settings:windowsupdate
";

        public static string GetDefaultData()
        {
            return string.Format(_defaultDataFormat, 
                App.R("R_SystemFolder"),
                App.R("R_Download"),
                App.R("R_Desktop"),
                App.R("R_Document"),
                App.R("R_Picture"),
                App.R("R_Video"),
                App.R("R_Music"),
                App.R("R_Tools"),
                App.R("R_Calc"),
                App.R("R_Notepad"),
                App.R("R_Paint"),
                App.R("R_Settings"),
                App.R("R_ControlPanel"));
        }

        public bool IsGroupTitle(string[] values)
        {
            return values[ColorOrGroupTitleColumnIndex].StartsWith(GroupTitleHeader);
        }

        public string GetGroupTitle(string[] values)
        {
            return values[ColorOrGroupTitleColumnIndex][GroupTitleHeader.Length..];
        }
    }
}
