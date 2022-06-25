namespace SpaciousStartMenu.Settings
{
    public class AppSettings
    {
        public double Scale { get; set; } = 1.0;
        public bool EscKeyMinimize { get; set; } = true;
        public bool MarginDoubleClickMinimize { get; set; } = false;
        public bool ConfirmCloseMenu { get; set; } = false;
        public bool MinimizeStartup { get; set; } = false;
        public bool MinimizeStartup2 { get; set; } = false;
        public bool DisabledMinimizeCtrlClick { get; set; } = true;
        public bool ShowOpenAndExitMenuItem { get; set; } = false;
        public bool ShowDirectEditDefineButton { get; set; } = false;

        // Screen size, position
        public bool SaveScreenSize { get; set; } = true;
        public bool SaveScreenPosition { get; set; } = false;
        public double PinListScreenHeight { get; set; } = 0.0;
        public double PinListScreenWidth { get; set; } = 0.0;
        public double PinListScreenLeft { get; set; } = -1.0;
        public double PinListScreenTop { get; set; } = -1.0;
        public bool PinListScreenMaximum { get; set; } = false;
        public double PinEditScreenHeight { get; set; } = 0.0;
        public double PinEditScreenWidth { get; set; } = 0.0;
        public double PinEditScreenLeft { get; set; } = -1.0;
        public double PinEditScreenTop { get; set; } = -1.0;
        public double SettingsScreenHeight { get; set; } = 0.0;
        public double SettingsScreenWidth { get; set; } = 0.0;
    }
}
