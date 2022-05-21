using System.Collections.Generic;

namespace SpaciousStartMenu.Settings
{
    internal class LauncherDefinition
    {
        public const char Delimiter = '\t';
        public const string GroupTitleHeader = "//";
        public const int GroupTitleColumnIndex = 0;

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
                App.GetRes("R_SystemFolder"),
                App.GetRes("R_Download"),
                App.GetRes("R_Desktop"),
                App.GetRes("R_Document"),
                App.GetRes("R_Picture"),
                App.GetRes("R_Video"),
                App.GetRes("R_Music"),
                App.GetRes("R_Tools"),
                App.GetRes("R_Calc"),
                App.GetRes("R_Notepad"),
                App.GetRes("R_Paint"),
                App.GetRes("R_Settings"),
                App.GetRes("R_ControlPanel"));
        }

        public static IReadOnlyDictionary<string, int> Columns = new Dictionary<string, int>
        {
            {"Color", 0},
            {"ButtonTitle", 1},
            {"Path", 2},
        };

        public bool IsGroupTitle(string[] values)
        {
            return values[GroupTitleColumnIndex].StartsWith(GroupTitleHeader);
        }

        public string GetGroupTitle(string[] values)
        {
            return values[GroupTitleColumnIndex][GroupTitleHeader.Length..];
        }
    }
}
