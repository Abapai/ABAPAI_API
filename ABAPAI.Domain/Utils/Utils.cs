using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Domain.Utils
{
    public static class Utils
    {
        public static bool IsValid(this object obj)
        {
            if (obj is null || obj is "" || obj is 0 || obj is "imagepadrao.jpg")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
