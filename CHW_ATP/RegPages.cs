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
        private static MainPage _mainPage = new MainPage();
        private static PlayerPage _playerPage = new PlayerPage();
        private static NewPlayerPage _newPlayerPage = new NewPlayerPage();
        private static TournamentPage _tournamentPage = new TournamentPage();
        private static NewTournamentPage _newTournamentPage = new NewTournamentPage();

        public static NewTournamentPage NewTournamentPage
        {
            get
            {
                return _newTournamentPage;
            }
        }
        public static TournamentPage TournamentPage
        {
            get
            {
                return _tournamentPage;
            }
        }

        public static NewPlayerPage NewPlayerPage
        {
            get
            {
                return _newPlayerPage;
            }
        }

        public static PlayerPage PlayerPage
        {
            get
            {
                return _playerPage;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }

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

