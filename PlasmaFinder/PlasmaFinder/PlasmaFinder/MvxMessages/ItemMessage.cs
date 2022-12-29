using MvvmCross.Plugin.Messenger;
using PlasmaFinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.MvxMessages
{
    public class ItemMessage : MvxMessage
    {
        public ItemMessage(object sender, ListItem _selectedItem) : base(sender)
        {
            SelectedItem = _selectedItem;
        }

        public ListItem SelectedItem
        {
            get;
            private set;
        }
    }
}
