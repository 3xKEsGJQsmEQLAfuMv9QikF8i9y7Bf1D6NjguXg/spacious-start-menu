using System.Windows;

namespace SpaciousStartMenu.Extensions
{
    public static class WindowExtensions
    {
        private const double _minSize = 150.0;
        private const double _maxSizeW = 9000.0;
        private const double _maxSizeH = 5000.0;

        public static void SetWindowSize(
            this Window window,
            double height,
            double width,
            bool maximized = false)
        {
            if (height < _minSize ||
                width < _minSize ||
                _maxSizeH < height ||
                _maxSizeW < width)
            {
                return;
            }

            window.Height = height;
            window.Width = width;

            if (maximized)
            {
                window.WindowState = WindowState.Maximized;
            }
        }

        public static void SetWindowPosition(
            this Window window,
            double left,
            double top)
        {
            if (0 <= left &&
                0 <= top)
            {
                window.Left = left;
                window.Top = top;
            }
        }
    }
}
