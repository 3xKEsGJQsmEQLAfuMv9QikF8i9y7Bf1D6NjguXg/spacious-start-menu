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
Gray	System/About	ms-settings:about
";

        public static string GetDefaultData()
        {
            return string.Format(_defaultDataFormat, 
                App.GetRes("SystemFolder"),
                App.GetRes("Download"),
                App.GetRes("Desktop"),
                App.GetRes("Document"),
                App.GetRes("Picture"),
                App.GetRes("Video"),
                App.GetRes("Music"),
                App.GetRes("Tools"),
                App.GetRes("Calc"),
                App.GetRes("Notepad"),
                App.GetRes("Paint"),
                App.GetRes("Settings"),
                App.GetRes("ControlPanel"));
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
