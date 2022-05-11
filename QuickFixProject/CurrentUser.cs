using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixProject
{
    static class CurrentUser
    {
        private static string _currentUserId = "";
        public static string CurrentUserId
        {
            get { return _currentUserId; }
            set { _currentUserId = value; }
        }
    }
}
