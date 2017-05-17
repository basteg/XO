using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossZero.Lesson1
{
    class ExceptionButtonClickClass : Exception
    {

        public string ReturnMess()
        {
            return "Поле занято";
        }
    }
}
