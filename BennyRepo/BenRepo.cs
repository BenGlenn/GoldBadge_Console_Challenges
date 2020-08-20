using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BennyRepo
{
    public class BenRepo
    {


        public List<Ben> _bennyList = new List<Ben>();

        public void AddToBennyList(Ben content)
        {
            _bennyList.Add(content);
        }

        public static Dictionary<int, Badge> GetInforBen()
        {
            var badgeDic = new Dictionary<int, Badge>();

            var badgeOne = new Badge("A7", "Betty White");
            badgeDic.Add(1, badgeOne);

            return badgeDic;
        }

        Ben addingOne = new Ben("Fuit");
        AddTo
    }
}
