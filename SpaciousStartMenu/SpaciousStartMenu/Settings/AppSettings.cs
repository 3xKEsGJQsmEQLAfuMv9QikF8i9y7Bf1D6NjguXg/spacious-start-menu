namespace SpaciousStartMenu.Settings
{
    public class AppSettings
    {
        public double Scale { get; set; } = 1.0;
        public bool EscKeyMinimize { get; set; } = true;
        public bool MarginDoubleClickMinimize { get; set; } = false;
        public bool ConfirmCloseMenu { get; set; } = false;
        public bool MinimizeStartup { get; set; } = false;
        public bool DisabledMinimizeCtrlClick { get; set; } = true;
        public bool ShowOpenAndExitMenuItem { get; set; } = false;
    }
}
