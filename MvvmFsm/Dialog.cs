using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmFsm
{
    public static class Dialog
    {
        public static readonly DependencyProperty CloseOnClickProperty =
            DependencyProperty.RegisterAttached(
                "CloseOnClick",
                typeof(bool),
                typeof(Dialog),
                new PropertyMetadata(false, OnCloseOnClickPropertyChanged)
            );

        public static bool GetCloseOnClick(DependencyObject obj)
        {
            var val = obj.GetValue(CloseOnClickProperty);
            return (bool)val;
        }

        public static void SetCloseOnClick(DependencyObject obj, bool value)
        {
            obj.SetValue(CloseOnClickProperty, value);
        }

        static void OnCloseOnClickPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs args)
        {
            var button = dpo as Button;
            if (button == null)
                return;

            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;

            if (!oldValue && newValue)
            {
                button.Click += OnClick;
            }
            else if (oldValue && !newValue)
            {
                button.PreviewMouseLeftButtonDown -= OnClick;
            }
        }

        static void OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            var win = Window.GetWindow(button);
            if (win == null)
                return;

            win.Close();
        }

    }
}
