using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace JOUJE_DLL
{
    public class Bois
    {
        public int idBois { get; set; }
        public string nomBois { get; set; }
        public double poidsBois { get; set; }
        public string région { get; set; }
        public int stockBois { get; set; }
    }

    

        public class PickUp
    {
        public int idMicro { get; set; }
        public string nomMicro { get; set; }
        public string caracteristiquesMicro { get; set; }
        public int stockMicro { get; set;}
    }

    public class Vibrato
    {
        public int idVibrato { get; set; }
        public string nomVibrato { get; set; }
        public string typeVibrato { get; set; }
        public int stockVibrato { get; set; }
    }
    public class Guitare
    {
        public int idGuitare { get; set; }
        public string nomGuitare { get; set; }
        public int idClient { get; set; }
        public int idMicro { get; set; }
        public int idMicro_1 { get; set; }
        public int idMicro_2 { get; set; }
        public int idBois { get; set; }
        public int idBois_1 { get; set; }
        public int idBois_2 { get; set; }
        public int idVibrato { get; set; }
    }



    public class Base
    {
        const string connexionString = @"Server=tcp:joujejm.database.windows.net,1433;Initial Catalog=Jouje;Persist Security Info=False;User ID=jouje;Password=Doggydog30.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        const string connexionStringLocal = @"Data Source=LAPTOP-NPSKRKCP\SQLEXPRESS;Initial Catalog=Jouje;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        const string connexionJoujeV2 = @"Data Source=LAPTOP-NPSKRKCP\SQLEXPRESS;Initial Catalog=JoujeV2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Base()
        {
            using(SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
            }
        }

        public List<Bois> GetAllBois()
        {
            using(SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                List<Bois> _bois = connection.Query<Bois>("SELECT * FROM Bois").ToList();

                return _bois;
            }
        }

        public Bois GetBoisById(int _id)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                Bois _bois = connection.QuerySingle<Bois>("GetBoisByID", new {@Id = _id}, commandType:CommandType.StoredProcedure);

                return _bois;
            }
        }

        

        public void AddBois(string P_nomBois, double P_poidsBois, string P_Région, int P_Stock)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Bois>("AddBois", new { @nomBois = P_nomBois, @poidsBois = P_poidsBois, @région = P_Région, @stockBois = P_Stock}, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddBois(ref Bois P_Bois)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Bois>("AddBois", new { @nomBois = P_Bois.nomBois, @poidsBois = P_Bois.poidsBois, @région = P_Bois.région, @stockBois = P_Bois.stockBois}, commandType: CommandType.StoredProcedure);
            }
        }


        public void DeleteBois(Bois P_Bois)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Bois>("DeleteBois", new { @boisID = P_Bois.idBois }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteBois(int P_Id)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Bois>("DeleteBois", new { @boisID = P_Id}, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateBois(int idBois, string nomBois = null, double? poidsBois = null, string region = null, int stockBois = 0)
        {
            using (var connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@boisID", idBois);
                parameters.Add("@nomBois", nomBois, DbType.String, ParameterDirection.Input);
                parameters.Add("@poidsBois", poidsBois, DbType.Double, ParameterDirection.Input);
                parameters.Add("@région", region, DbType.String, ParameterDirection.Input);
                parameters.Add("@stockBois", stockBois, DbType.Int32, ParameterDirection.Input);


                connection.Query<Bois>("UpdateBois", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateBois(ref Bois P_Bois)
        {
            using (var connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@boisID", P_Bois.idBois);
                parameters.Add("@nomBois", P_Bois.nomBois, DbType.String, ParameterDirection.Input);
                parameters.Add("@poidsBois", P_Bois.poidsBois, DbType.Double, ParameterDirection.Input);
                parameters.Add("@région", P_Bois.région, DbType.String, ParameterDirection.Input);
                parameters.Add("@stockBois", P_Bois.stockBois, DbType.String, ParameterDirection.Input);

                connection.Query<Bois>("UpdateBois", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // --------------------------------------------------------------------------
        public List<PickUp> GetAllMicros()
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                List<PickUp> _micros = connection.Query<PickUp>("SELECT * FROM Pick_Up").ToList();

                return _micros;
            }
        }

        public void AddMicro(string P_nomMicro, string P_caracteristiques, int stock)
        {
            using(SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<PickUp>("AddMicro", new { @nomMicro = P_nomMicro, @caracteristiquesMicro = P_caracteristiques, @stockMicro = stock}, commandType: CommandType.StoredProcedure);  ;
            }
        }

        public void AddMicro(ref PickUp _micro)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<PickUp>("AddMicro", new { @nomMicro = _micro.nomMicro, @caracteristiquesMicro = _micro.caracteristiquesMicro, @stockMicro = _micro.stockMicro }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateMicro(int P_Id, string nomMicro = null, string caracteristiquesMicro = null, int stock = 0)
        {
            using (var connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@microID", P_Id);
                parameters.Add("@nomMicro", nomMicro, DbType.String, ParameterDirection.Input);
                parameters.Add("@caracteristiquesMicro", caracteristiquesMicro, DbType.String, ParameterDirection.Input);
                parameters.Add("@stockMicro", stock, DbType.Int32, ParameterDirection.Input);

                connection.Query<PickUp>("UpdateMicro", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateMicro(ref PickUp _micro)
        {
            using (var connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@microID", _micro.idMicro);
                parameters.Add("@nomMicro", _micro.nomMicro, DbType.String, ParameterDirection.Input);
                parameters.Add("@caracteristiquesMicro", _micro.caracteristiquesMicro, DbType.String, ParameterDirection.Input);
                parameters.Add("@stockMicro", _micro.stockMicro, DbType.Int32, ParameterDirection.Input);

                connection.Query<PickUp>("UpdateMicro", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteMicro(int id)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<PickUp>("DeleteMicro", new { @P_Id = id}, commandType: CommandType.StoredProcedure);
            }
        }

        // --------------------------------------------------------------
        public List<Vibrato> GetAllVibratos()
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                List<Vibrato> _vibratos = connection.Query<Vibrato>("SELECT * FROM Vibrato").ToList();

                return _vibratos;
            }
        }

        public void AddVibrato(string nomVibrato, string typeVibrato, int stock)
        {
            using(SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Vibrato>("AddVibrato", new {@nomVIbrato = nomVibrato, @typeVibrato = typeVibrato, @stockVibrato = stock}, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddVibrato(ref Vibrato vibrato)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Vibrato>("AddVibrato", new { @nomVIbrato = vibrato.nomVibrato, @typeVibrato = vibrato.typeVibrato, @stockVibrato = vibrato.stockVibrato }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteVibrato(int P_Id)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Vibrato>("DeleteVibrato", new { @P_ID = P_Id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateVibrato(int P_Id, string nomVibrato, string typeVibrato, int stock)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@P_Id", P_Id);
                parameters.Add("@nomVibrato", nomVibrato, DbType.String, ParameterDirection.Input);
                parameters.Add("@typeVibrato", typeVibrato, DbType.String, ParameterDirection.Input);
                parameters.Add("@stockVibrato", typeVibrato, DbType.Int32, ParameterDirection.Input);

                connection.Query<PickUp>("UpdateVibrato", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateVibrato(ref Vibrato vibrato)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@P_Id", vibrato.idVibrato);
                parameters.Add("@nomVibrato", vibrato.nomVibrato, DbType.String, ParameterDirection.Input);
                parameters.Add("@typeVibrato", vibrato.typeVibrato, DbType.String, ParameterDirection.Input);
                parameters.Add("@stockVibrato", vibrato.stockVibrato, DbType.Int32, ParameterDirection.Input);

                connection.Query<PickUp>("UpdateVibrato", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        // --------------------------------------------------------------------------
        public List<Guitare> GetAllGuitares()
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                List<Guitare> _guitares = connection.Query<Guitare>("SELECT * FROM Guitare").ToList();

                return _guitares;
            }
        }

        public Guitare GetGuitareById(int _id)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                Guitare _guitare = connection.QuerySingle<Guitare>("GetGuitareByID", new { @Id = _id }, commandType: CommandType.StoredProcedure);

                return _guitare;
            }
        }

        public void DeleteGuitare(int _id)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Guitare>("DeletGuitare", new { @guitareID = _id }, commandType: CommandType.StoredProcedure);

            }
        }

        public void AddGuitare(ref Guitare _guitare)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();
                connection.Query<Guitare>("AddGuitare", new { 
                   @nomGuitare = _guitare.nomGuitare,
                   @clientID = _guitare.idClient,
                   @micro_1_ID = _guitare.idMicro,
                   @micro_2_ID = _guitare.idMicro_1,
                   @micro_3_ID = _guitare.idMicro_2,
                   @bois_1_ID = _guitare.idBois,
                   @bois_2_ID = _guitare.idBois_1,
                   @bois_3_ID = _guitare.idBois_2,
                   @vibratoID = _guitare.idVibrato
                }, 
                commandType: CommandType.StoredProcedure);

            }
        }

        public void UpdateGuitare(ref Guitare _guitare)
        {
            using (SqlConnection connection = new SqlConnection(connexionJoujeV2))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@guitareID", _guitare.idGuitare);
                parameters.Add("@nomGuitare", _guitare.nomGuitare, DbType.String, ParameterDirection.Input);
                parameters.Add("@clientID", _guitare.idClient, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@micro_1_ID", _guitare.idMicro, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@micro_2_ID", _guitare.idMicro_1, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@micro_3_ID", _guitare.idMicro_2, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@bois_1_ID", _guitare.idBois, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@bois_2_ID", _guitare.idBois_1, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@bois_3_ID", _guitare.idBois_2, DbType.Int16, ParameterDirection.Input);
                parameters.Add("@vibratoID", _guitare.idVibrato, DbType.Int16, ParameterDirection.Input);

                connection.Query<Guitare>("UpdateVibrato", parameters, commandType: CommandType.StoredProcedure);
            }
        }












    }
}
