using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.Console
{
    public class RawSQL
    {
        public List<string> AnnualPartners(ContosoCodeModel context)
        {
            List<string> annualPartners = context.Partners.SqlQuery("Select * From Partners WHERE AnnualRevenue <= 1284010").Select(p => p.Name).ToList();
            return annualPartners;
        }
    }
}
