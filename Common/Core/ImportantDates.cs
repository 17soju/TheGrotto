using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGrotto.Common.Core
{
    public class ImportantDates : IOrderedLoadable
    {


        public static bool IsHalloween = false;
        public static bool IsOctober = false;

        public static bool IsChristmas = false;



        public void Load()
        {
            IsHalloween = DateTime.Now.Month == 10 && DateTime.Now.Day == 31;
            IsOctober = DateTime.Now.Month == 10;
        }
        public void Unload() { }
    }
}
