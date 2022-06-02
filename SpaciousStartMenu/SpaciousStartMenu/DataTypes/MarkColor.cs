using System.Windows.Media;

namespace SpaciousStartMenu.DataTypes
{
    public record MarkColor
    {
        public string? ColorName { get; init; }

        public Brush? MarkBrush { get; init; }

        private static readonly BrushConverter _bc = new();

        public MarkColor(string? colorName)
        {
            ColorName = colorName;
            if (colorName is not null)
            {
                MarkBrush = GetBrushFromColorName(colorName);
            }
        }

        public static Brush? GetBrushFromColorName(string colorName)
        {
            return _bc.ConvertFromString(colorName) as Brush;
        }

        public string Order
        {
            get
            {
                if (MarkBrush is not SolidColorBrush scb)
                {
                    return "";
                }
                return $"{GetHexStr(scb.Color.R)}{GetHexStr(scb.Color.G)}{GetHexStr(scb.Color.B)}";
            }
        }

        private string GetHexStr(int i) => i.ToString("x2");

    }
}
