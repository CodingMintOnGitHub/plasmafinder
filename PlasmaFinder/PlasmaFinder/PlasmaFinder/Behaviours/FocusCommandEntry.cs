using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlasmaFinder.Behaviours
{
    public sealed class EntryFocusCommand
    {
        public static readonly BindableProperty EntryFocusCommandProperty =
            BindableProperty.CreateAttached(
                "EntryFocusCommand",
                typeof(ICommand),
                typeof(EntryFocusCommand),
                default(ICommand),
                BindingMode.OneWay,
                null,
                PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Entry entry)
            {
                entry.Focused -= EntryOnFocus;
                entry.Focused += EntryOnFocus;
            }
        }

        private static void EntryOnFocus(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;

            if (entry != null && entry.IsFocused)
            {
                var command = GetEntryFocusCommand(entry);
                if (command != null && command.CanExecute(e))
                {
                    command.Execute(e);
                }
            }
        }

        public static ICommand GetEntryFocusCommand(BindableObject bindableObject)
        {
            return (ICommand)bindableObject.GetValue(EntryFocusCommandProperty);
        }

        public static void SetEntryFocusCommand(BindableObject bindableObject, object value)
        {
            bindableObject.SetValue(EntryFocusCommandProperty, value);
        }

    }
}
