using SpaciousStartMenu.DataTypes;
using System.Windows.Media;

namespace SpaciousStartMenu.Settings
{
    public class LaunchDefItem : NotifyPropertyChanged
    {
        //private static int _count = 0;

        //private int _id;
        //public int Id
        //{
        //    get => _id;
        //    set => SetProperty(ref _id, value);
        //}

        private bool _isDelete;
        public bool IsDelete
        {
            get => _isDelete;
            set => SetProperty(ref _isDelete, value);
        }

        private string? _colorName;
        public string? ColorName
        {
            get => _colorName;
            set => SetProperty(ref _colorName, value);
        }

        private Brush? _markBrush;
        public Brush? MarkBrush
        {
            get => _markBrush;
            set => SetProperty(ref _markBrush, value);
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string? _path;
        public string? Path
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }

        public LaunchDefItem(string? title)
        {
            IsDelete = false;
            //_count++;
            //Id = _count;
            ColorName = null;
            MarkBrush = null;
            Title = title;
            Path = null;
        }

        public LaunchDefItem(string? colorName, string? title, string? path)
        {
            IsDelete = false;
            //_count++;
            //Id = _count;

            ColorName = colorName;

            if (colorName is not null)
            {
                MarkBrush = MarkColor.GetBrushFromColorName(colorName);
            }

            Title = title;
            Path = path;
        }

        //public static void ResetId() => _count = 0;

        public string ToDefString()
        {
            if (ColorName is null)
            {
                return $"//{Title}";
            }
            else
            {
                return $"{ColorName}\t{Title}\t{Path}";
            }
        }

        public LaunchDefItem Copy()
        {
            return new LaunchDefItem(ColorName, Title, Path);
        }

    }
}
