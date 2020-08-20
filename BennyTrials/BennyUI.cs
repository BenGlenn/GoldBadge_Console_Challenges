using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BennyTrials
{
    class BennyUI
    {
        public class Ben
        {
            public Ben() { }
            public Ben(string fruit)
            {
                Fruit = fruit;
            }
            public string Fruit { get; set; }
        }

        public List<Ben> fruitList = new List<Ben>();
        Ben fruit1 = new Ben("grape");
        

    }
}
