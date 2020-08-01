using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readability_App
{
    public class Binding_example
{
        private string paragraphStyle = "color:red";
        private string para = "1";
        private int paraLength;

        private void ParaLength()
        {
            paraLength = paragraphStyle.Length;
        }
    }
}
