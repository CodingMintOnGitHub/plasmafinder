using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class ListItem
    {

        public ListItem()
        {
            ParentTypeId = "0";
        }

        public string ItemKey { get; set; }
        public string ItemText { get; set; }
        public string ItemType { get; set; }
        public string ParentTypeId { get; set; }
    }
}
