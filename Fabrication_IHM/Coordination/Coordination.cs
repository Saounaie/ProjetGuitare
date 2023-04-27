using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NS_Jouje;

namespace Fabrication_IHM.Coordination
{
    public class Coordination : Notification
    {
        private static Coordination _instance = null;
            
        public static Coordination Instance
        {
            get {
                if (_instance == null) { _instance = new Coordination(); }
                return _instance;
            }
        }


        JoujeWs jouje;

        public Coordination()
        {
            HttpClient client = new HttpClient();
            jouje = new JoujeWs("https://localhost:7257", client);
            Liste_Bois = jouje.GetAllBoisAsync().Result;
            Liste_Micros = jouje.GetAllMicrosAsync().Result;
            Liste_Vibratos = jouje.GetAllVibratosAsync().Result;
            Liste_Commandes = jouje.GetAllCommandesAsync().Result;
        }

        // -------------------------- BOIS
        private Bois _Selected_Bois;

        public Bois Selected_Bois
        {
            get { return _Selected_Bois; }
            set { _Selected_Bois = value; Signale_Changement(); }
        }

        private IEnumerable<Bois> _Liste_Bois;

        public IEnumerable<Bois> Liste_Bois
        {
            get { return _Liste_Bois; }
            set { _Liste_Bois = value; Signale_Changement(); }
        }

        public async Task AddBois(Bois bois)
        {
            await jouje.AddBoisAsync(bois);
            Liste_Bois = await jouje.GetAllBoisAsync();
        }

        public async Task DeleteBois(int id)
        {
            await jouje.DeleteBoisAsync(id);
            Liste_Bois = jouje.GetAllBoisAsync().Result;
        }
        // ---------------------------------- MICROS
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
            set { _Micro_Selectionne = value; Signale_Changement(); }
        }

        public async Task AddMicro(PickUp micro)
        {
            await jouje.AddMicroAsync(micro);
            Liste_Micros = await jouje.GetAllMicrosAsync();
        }

        public async Task DeleteMicro(int id)
        {
            await jouje.DeleteMicroAsync(id);
            Liste_Micros = await jouje.GetAllMicrosAsync();
        }

        // -------------------------------- VIBRATOS

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
            set { _Vibrato_Selectionne = value; Signale_Changement(); }
        }

        public async Task AddVibrato(Vibrato vibrato)
        {
            await jouje.AddVibratoAsync(vibrato);
            Liste_Vibratos = await jouje.GetAllVibratosAsync();
        }

        public async Task DeleteVibrato(int id)
        {
            await jouje.DeleteVibratoAsync(id);
            Liste_Vibratos = await jouje.GetAllVibratosAsync();
        }

        // ------------------------------- COMMANDES
        private IEnumerable<Commande> _Liste_Commandes;

        public IEnumerable<Commande> Liste_Commandes
        {
            get { return _Liste_Commandes; }
            set { _Liste_Commandes = value; Signale_Changement(); }
        }




    }
}
