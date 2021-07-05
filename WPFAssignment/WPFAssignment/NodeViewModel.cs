using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAssignment
{
    public class NodeViewModel
    {
        public NodeViewModel()
        {
            Children = new ObservableCollection<NodeViewModel>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<NodeViewModel> Children { get; set; }
    }
}
