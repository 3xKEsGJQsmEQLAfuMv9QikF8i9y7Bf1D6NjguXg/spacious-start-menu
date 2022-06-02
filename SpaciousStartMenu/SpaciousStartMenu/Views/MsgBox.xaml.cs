using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpaciousStartMenu.Views
{
    public partial class MsgBox : Window
    {
        public int ButtonNo { get; set; } = 0;

        public MsgBox()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonNo = 1;
            Close();
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ButtonNo = 2;
            Close();
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ButtonNo = 3;
            Close();
        }

        private void Title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private static void SetInfoStyle(MsgBox dlg)
        {
            dlg.InfoTitle.Visibility = Visibility.Visible;
            dlg.ConfirmTitle.Visibility = Visibility.Collapsed;
            dlg.ErrorTitle.Visibility = Visibility.Collapsed;

            dlg.Button1.IsDefault = true;
            dlg.Button2.Visibility = Visibility.Collapsed;
            dlg.Button3.Visibility = Visibility.Collapsed;
        }

        private static void SetConfirmStyle(MsgBox dlg, bool threeButtons)
        {
            dlg.InfoTitle.Visibility = Visibility.Collapsed;
            dlg.ConfirmTitle.Visibility = Visibility.Visible;
            dlg.ErrorTitle.Visibility = Visibility.Collapsed;

            dlg.Button1.Content = App.R("R_YesButton");
            dlg.Button2.Visibility = Visibility.Visible;
            dlg.Button3.Visibility = threeButtons ? Visibility.Visible : Visibility.Collapsed;
        }

        private static void SetErrorStyle(MsgBox dlg)
        {
            dlg.InfoTitle.Visibility = Visibility.Collapsed;
            dlg.ConfirmTitle.Visibility = Visibility.Collapsed;
            dlg.ErrorTitle.Visibility = Visibility.Visible;
            
            dlg.Button1.IsDefault = true;
            dlg.Button2.Visibility = Visibility.Collapsed;
            dlg.Button3.Visibility = Visibility.Collapsed;
        }

        public static void Error(Window? owner, string msg)
        {
            var dlg = new MsgBox();

            SetErrorStyle(dlg);
            dlg.Message.Text = msg;

            dlg.Owner = owner;
            dlg.ShowDialog();
        }

        public static void Info(Window? owner, string msg)
        {
            var dlg = new MsgBox();

            SetInfoStyle(dlg);
            dlg.Message.Text = msg;

            dlg.Owner = owner;
            dlg.ShowDialog();
        }

        public static MessageBoxResult Confirm(Window? owner, string msg)
        {
            var dlg = new MsgBox();

            SetConfirmStyle(dlg, false);
            dlg.Message.Text = msg;

            dlg.Owner = owner;
            dlg.ShowDialog();

            return dlg.ButtonNo == 1 ? MessageBoxResult.Yes : MessageBoxResult.No;
        }

        public static MessageBoxResult Confirm3Buttons(Window? owner, string msg)
        {
            var dlg = new MsgBox();

            SetConfirmStyle(dlg, true);
            dlg.Message.Text = msg;

            dlg.Owner = owner;
            dlg.ShowDialog();

            return dlg.ButtonNo switch
            {
                1 => MessageBoxResult.Yes,
                2 => MessageBoxResult.No,
                _ => MessageBoxResult.Cancel
            };
        }

    }
}
