using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestingAPICommunication.Models
{
    public class Definition
    {
        public string Word { get; set; }
        public ObservableCollection<Item> Definitions { get; set; }
        
    }
}
