using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicInfoTest1
{
    class checkDates
    {
        public void check(string init, string end)
        {
            DateTime inicio, fin;
            string rsult;
            inicio = Convert.ToDateTime(init);
            rsult = inicio.ToString("yyyy-M-d");

            MessageBox.Show(rsult);
        }
    }
}
