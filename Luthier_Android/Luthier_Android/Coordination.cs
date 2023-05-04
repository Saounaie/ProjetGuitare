using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using NS_Jouje;

namespace Luthier_Android
{
    public class Coordination : Notification
    {
        private static Coordination _instance = null;

        public static Coordination Instance
        {
            get
            {
                if (_instance == null) { _instance = new Coordination(); }
                return _instance;
            }
        }

        JoujeWS jouje;

        public Coordination()
        {
            HttpClient client = new HttpClient();
            jouje = new JoujeWS("https://localhost:7257", client);
            // Liste_Bois = jouje.GetAllBoisAsync().Result;

        }

        private IEnumerable<Bois> _Liste_Bois;

        public IEnumerable<Bois> Liste_Bois
        {
            get { return _Liste_Bois; }
            set { _Liste_Bois = value; Signale_Changement(); }
        }

        


    }
}
