using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JOUJE_DLL;
using Microsoft.VisualBasic;
using NS_Jouje;
using NS_JOUJE_AZURE;

namespace TestJouje
{
    internal class Program
    {
        public class BoisList
        {
            //public List<Bois> bois { get; set; }
        }

        public class PickupList
        {
            public List<NS_Jouje.PickUp> micros { get; set; }
        }

        public class VibratoList
        {
            public List<NS_Jouje.Vibrato> vibratos { get; set; }
        }
        static void Main(string[] args)
        {
            Base jouje = new Base();

            // jouje.AddBois("Bois de Bambou", 7, "Bambouserai");


            // jouje.UpdateBoisGPT(5, null, null, "Chez Valentin"); 

            // jouje.DeleteBois(6);

            var bois = jouje.GetAllBois();

            foreach (var e in bois)
            {
                Console.WriteLine($"{e.idBois} {e.nomBois} {e.poidsBois} {e.région}");
            }

            Console.WriteLine("------------------MICROS--------------");
            //jouje.AddMicro("Blue Spark", "Il est encore plus cool");
            //jouje.UpdateMicro(2, null, "Il est même vachement bien");
            var micros = jouje.GetAllMicros();
            foreach (var e in micros)
            {
                Console.WriteLine($"{e.idMicro} {e.nomMicro} {e.caracteristiquesMicro}");
            }

            Console.WriteLine("---------------------VIBRATO--------------------");
            //jouje.AddVibrato("Vibrato 2", "Il est un peu mieux que le 1");
            //jouje.UpdateVibrato(2, "Vibrato Premium", null);

            var vibratos = jouje.GetAllVibratos();
            foreach (var e in vibratos)
            {
                Console.WriteLine($"{e.idVibrato} {e.nomVibrato} {e.typeVibrato}");
            }
            Console.WriteLine("-------------------GUITARES--------------------");


            /*var nvGuitare = new Guitare
            {
                nomGuitare = "Jouje",
                idBoisCorps = 1,
                idBoisManche = 1,
                idBoisTouche = 1,
                idClient = 1,
                idMicroCentral = 2,
                idMicroDroit = 2,
                idMicroGauche = 2,
                idVibrato = 1
            };
            jouje.AddGuitare(ref nvGuitare);*/
            var guitares = jouje.GetAllGuitares();
            foreach (var e in guitares)
            {
                Console.WriteLine($"{e.idGuitare}  {e.nomGuitare} {e.idMicro_1}");
            }

            // JSON FOR WOOD
            Console.WriteLine("------------------JSON------------------");
            /*string fileName = @"C:\Users\trinc\source\repos\DeploiementJouje\TestJouje\pickUp.json";
            string jsonString = File.ReadAllText(fileName);
            BoisList boisJson = JsonSerializer.Deserialize<BoisList>(jsonString);
            foreach(Bois _bois in boisJson.bois)
            {
                jouje.AddBois(_bois.nomBois, _bois.poidsBois, _bois.région);
            }*/

            /*string fileName = @"C:\Users\trinc\source\repos\DeploiementJouje\TestJouje\pickUp.json";
            string jsonString = File.ReadAllText(fileName);
            PickupList microsJson = JsonSerializer.Deserialize<PickupList>(jsonString);
            foreach (var _micro in microsJson.micros)
            {
                // jouje.AddMicro(_micro.nomMicro, _micro.caracteristiquesMicro, _micro.stockMicro);
                Console.WriteLine(_micro.idMicro);
            }*/

            string fileName = @"C:\Users\trinc\OneDrive\Documents\vibratosList.json";
            string jsonString = File.ReadAllText(fileName);
            VibratoList vibratoJson = JsonSerializer.Deserialize<VibratoList>(jsonString);
            foreach (var _vibrato in vibratoJson.vibratos)
            {
                // jouje.AddVibrato(_vibrato.nomVibrato, _vibrato.typeVibrato, _vibrato.stockVibrato);
            }


            Console.WriteLine();
            Console.WriteLine("--------------------TEST DU WEB SERVICE-------------------------");
            HttpClient client = new HttpClient();
            joujeAzure ws = new joujeAzure("https://apijouje20230509165034.azurewebsites.net/", client);
            Console.WriteLine("Liste de bois : ");
            var boisWs = ws.GetAllBoisAsync().Result;
            foreach (var e in boisWs)
            {
                Console.WriteLine($"{e.IdBois} - {e.NomBois}");
            }
            Console.WriteLine("Bois numéro 3 :");
            var boisTrois = ws.GetBoisByIdAsync(3).Result;
            Console.WriteLine(boisTrois.NomBois);
            Console.WriteLine("Commandes :");
            var commandes = jouje.GetAllCommandes();
            foreach (var e in commandes)
            {
                Console.WriteLine(e.numCoommande);
            }

            var clientAVerifierBon = new NS_Jouje.Client
            {
                PseudoClient = "jirome",
                MdpClient = "mathis"
            };

            var clientATester = ws.GetClientByIDAsync(4).Result;
            Console.WriteLine($"PSEUDO DU CLIENT NUMERO 4 {clientATester.PseudoClient}");

            var result = ws.VerifyLoginAsync(clientATester).Result;
            if (result)
            {
                Console.WriteLine($"JE PETE MON CRANE SI CA MARCHE {clientATester.PseudoClient} {clientATester.IdClient}");
            }
            /*if (result)
            {
                
                Console.WriteLine($"{clientAVerifierBon.IdClient} ----- {clientAVerifierBon.PseudoClient}");
            }*/
            Console.WriteLine(result);

            Console.WriteLine("Test du client connecté");
            var clientTrouve = ws.GetClientByIDAsync(4).Result;
            Console.WriteLine(clientTrouve.IdClient);
            Console.WriteLine("------------------------------------");
            var guitareCommande = jouje.GetGuitareByIDClient(4);
            Console.WriteLine(guitareCommande.idClient);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Test de l'update de la guitare");
            var guitare = jouje.GetGuitareByIDClient(4);
            Console.WriteLine(guitare.idBois_2);
            ws.UpdateGuitareNotObjAsync(guitare.idGuitare, "Test de l'update", 1, 1, 1, 1, 1, 1, 1, 1);
            Console.WriteLine(guitare.nomGuitare);

        


           
            



        }
    }
}
