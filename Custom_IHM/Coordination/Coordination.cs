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
            Liste_Bois = jouje.GetAllBoisAsync().Result;
            Liste_Micros = jouje.GetAllMicrosAsync().Result;
            Liste_Vibratos = jouje.GetAllVibratosAsync().Result;
            
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
           bool loginSuccess = await jouje.VerifyLoginAsync(client);

            if (loginSuccess)
            {
                connectedClient = client;
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

        private ICollection<Bois> _Liste_Bois;

        public ICollection<Bois> Liste_Bois
        {
            get { return _Liste_Bois; }
            set { _Liste_Bois = value; Signale_Changement(); }
        }

        private Bois _Bois_Selectionne;

        public Bois Bois_Selectionne
        {
            get { return _Bois_Selectionne; }
            set { _Bois_Selectionne = value; }
        }


        private IEnumerable<PickUp> _Liste_Micros;

        public IEnumerable<PickUp> Liste_Micros
        {
            get { return _Liste_Micros; }
            set { _Liste_Micros = value; Signale_Changement(); }
        }

        private PickUp _Micro_Selectionne;

        public PickUp Micro_Selectionne
        {
            get { return _Micro_Selectionne; }
            set { _Micro_Selectionne = value; }
        }


        private IEnumerable<Vibrato> _Liste_Vibratos;

        public IEnumerable<Vibrato> Liste_Vibratos
        {
            get { return _Liste_Vibratos; }
            set { _Liste_Vibratos = value; Signale_Changement(); }
        }

        private Vibrato _Vibrato_Selectionne;

        public Vibrato Vibrato_Selectionne
        {
            get { return _Vibrato_Selectionne; }
            set { _Vibrato_Selectionne = value; }
        }


        public async Task AddGuitare(Guitare guitare)
        {
        
            await jouje.AddGuitareAsync(guitare);

        }

        public Guitare GetGuitareByIDClient(int id)
        {
            return jouje.GetGuitareByIDClientAsync(id).Result;
        }

    }
}
