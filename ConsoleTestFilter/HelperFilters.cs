using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestFilter
{
    class FTreeViewItem
    {
        public int ? Id { get; set; } //Костиль
        public string Name { get; set; }
    }
    class FNodeTreeView : FTreeViewItem
    {
        public List<FTreeViewItem> Childrens { get; set; }
    }
}
