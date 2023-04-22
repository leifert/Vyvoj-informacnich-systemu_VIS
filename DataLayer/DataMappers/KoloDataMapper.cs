using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;
using DataLayer.DB;

namespace DataLayer.DataMappers
{
    public class KoloDataMapper
    {
        public static string SQL_INSERT = "insert into dbo.kolo (nazev,typ,popis,zaloha,cena_den,cena_vikend,cena_tyden,dostupnost) OUTPUT INSERTED.ID values (@nazev,@typ,@popis,@zaloha,@cena_den,@cena_vikend,@cena_tyden,@dostupnost)";
        public static string SQL_DELETE = "DELETE FROM dbo.kolo WHERE id =@id_kolo";
        public static string SQL_SELECT = "SELECT * FROM dbo.kolo";
        public static string SQL_SELECT_ID = "SELECT * FROM dbo.kolo WHERE id=@id_kolo";
        public static string SQL_UPDATE = "UPDATE dbo.kolo SET nazev=@nazev,typ=@typ,popis=@popis,zaloha=@zaloha,cena_den=@cena_den,cena_vikend=@cena_vikend,cena_tyden=@cena_tyden,dostupnost=@dostupnost where id=@id_kolo";
        private static void PrepareCommand(SqlCommand command, Kolo kolo)
        {
            command.Parameters.AddWithValue("@id_kolo", kolo.Id);
            command.Parameters.AddWithValue("@nazev", kolo.Nazev);
            command.Parameters.AddWithValue("@typ", kolo.Typ);
            command.Parameters.AddWithValue("@popis", kolo.Popis);
            command.Parameters.AddWithValue("@zaloha", kolo.Zaloha);
            command.Parameters.AddWithValue("@cena_den", kolo.CenaDen);
            command.Parameters.AddWithValue("@cena_vikend", kolo.CenaVikend);
            command.Parameters.AddWithValue("@cena_tyden", kolo.CenaTyden);
            command.Parameters.AddWithValue("@dostupnost", kolo.Dostupnost);
            
        }
        
        public static bool Insert(Kolo kolo, Database pDb= null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, kolo);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Update(Kolo kolo, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, kolo);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Delete(Kolo kolo, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@id_kolo", kolo.Id);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static Kolo GetKoloById(int id, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_kolo", id);
            SqlDataReader reader = db.Select(command);

            Collection<Kolo> kola = Read(reader);
            Kolo kolo = null;
            if (kola.Count == 1)
            {
                kolo = kola[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kolo;
        }
        
        public static Collection<Kolo> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Kolo> kola = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kola;
        }

        
        
        private static Collection<Kolo> Read(SqlDataReader reader)
        {
            Collection<Kolo> kola = new Collection<Kolo>();

            while (reader.Read())
            {
                Kolo kolo = new Kolo();
                int i = -1;
                kolo.Id = reader.GetInt32(++i);
                kolo.Nazev = reader.GetString(++i);
                kolo.Typ = reader.GetString(++i);
                kolo.Popis = reader.GetString(++i);
                kolo.Zaloha = reader.GetInt32(++i);
                kolo.CenaDen = reader.GetInt32(++i);
                kolo.CenaVikend = reader.GetInt32(++i);
                kolo.CenaTyden = reader.GetInt32(++i);
                kolo.Dostupnost = reader.GetInt32(++i);
                kola.Add(kolo);
            }
            return kola;
        }
    }
}