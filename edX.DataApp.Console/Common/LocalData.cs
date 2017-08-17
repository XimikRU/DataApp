using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.Console
{
    public class LocalData
    {
        public void RunLogic(ContosoCodeModel context)
        {
            System.Console.WriteLine(context.Partners.Local.Count);
        }
    }
}
