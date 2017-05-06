using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHW_ATP
{
  static  class RegPages
    {
            private static CurrentPage _currentPage = new CurrentPage();
            private static LoginPage _loginPage = new LoginPage();
        private static AuthorizePage _authorizePage = new AuthorizePage();
        private static CompletePage _completePage = new CompletePage();

        public static LoginPage LoginPage
            {
                get
                {
                    return _loginPage;
                }
            }

            public static CurrentPage CurrentPage
            {
                get
                {
                    return _currentPage;
                }
            }

        public static AuthorizePage AuthorizePage
        {
            get
            {
                return _authorizePage;
            }
        }

        public static CompletePage CompletePage
        {
            get
            {
                return _completePage;
            }
        }
    }
    }

