using NS_Jouje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Custom_IHM.Coordination
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


        JoujeCS jouje;

        public Coordination()
        {
            HttpClient client = new HttpClient();
            jouje = new JoujeCS("https://localhost:7257", client);
            
        }

        public async Task CreateClient(Client client)
        {
            await jouje.CreateClientAsync(client);
        }

        public async Task UpdateClient(Client client)
        {
            await jouje.UpdateClientAsync(client);
        }

        public async Task<bool> VerifyLogin(Client client)
        {
           bool loginSuccess = await jouje.VerifyLoginWithIDAsync(client);

            if (loginSuccess)
            {

                connectedClient = client;
                connectedClient.IdClient = client.IdClient;
                
            }


            return loginSuccess;


        }

        public async Task<int> GetIDByClient(Client client)
        {
            return await jouje.GetIDByClientAsync(client);
        }

        private Client _connectedClient;

        public Client connectedClient
        {
            get { return _connectedClient; }
            set { _connectedClient = value; Signale_Changement(); }
        }

    }
}
