using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;
using DataLayer.DB;

namespace DataLayer.DataMappers
{
    public class UzivatelDataMapper
    {
        public static string SQL_SELECT = "SELECT * FROM dbo.uzivatel";
        public static string SQL_SELECT_ID = "SELECT * FROM dbo.uzivatel WHERE id =@id_uzivatel";
        public static string SQL_INSERT = "insert into dbo.uzivatel (login,jmeno,prijmeni,email,adresa,telefon) OUTPUT INSERTED.ID values (@login,@jmeno,@prijmeni,@email,@adresa,@telefon)";
        public static string SQL_UPDATE = "update dbo.uzivatel set login=@login,jmeno=@jmeno,prijmeni=@prijmeni,email=@email,adresa=@adresa,telefon=@telefon where id = @id_uzivatel";
        public static string SQL_DELETE = "DELETE FROM dbo.uzivatel WHERE id =@id_uzivatel";
        
        
        private static void PrepareCommand(SqlCommand command, Uzivatel uzivatel)
        {
            command.Parameters.AddWithValue("@id_uzivatel", uzivatel.Id);
            command.Parameters.AddWithValue("@login",uzivatel.Login);
            command.Parameters.AddWithValue("@jmeno", uzivatel.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", uzivatel.Prijmeni);
            command.Parameters.AddWithValue("@email", uzivatel.Email);
            command.Parameters.AddWithValue("@adresa", uzivatel.Adresa);
            command.Parameters.AddWithValue("@telefon", uzivatel.Telefon);
        }
        
        
         public static bool Insert(Uzivatel uzivatel, Database pDb= null)
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
            PrepareCommand(command, uzivatel);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Update(Uzivatel uzivatel, Database pDb = null)
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
            PrepareCommand(command, uzivatel);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Delete(Uzivatel uzivatel, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_uzivatel", uzivatel.Id);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static Uzivatel GetUzivatelById(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_uzivatel", id);
            SqlDataReader reader = db.Select(command);

            Collection<Uzivatel> uzivatele = Read(reader);
            Uzivatel uzivatel = null;
            if (uzivatele.Count == 1)
            {
                uzivatel = uzivatele[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return uzivatel;
        }
        public static Collection<Uzivatel> Select(Database pDb = null)
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

            Collection<Uzivatel> uzivatele = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return uzivatele;
        }
        
        
        private static Collection<Uzivatel> Read(SqlDataReader reader)
        {
            Collection<Uzivatel> uzivatele = new Collection<Uzivatel>();

            while (reader.Read())
            {
                Uzivatel uzivatel = new Uzivatel();
                int i = -1;
                uzivatel.Id = reader.GetInt32(++i);
                uzivatel.Login = reader.GetString(++i);
                uzivatel.Jmeno = reader.GetString(++i);
                uzivatel.Prijmeni = reader.GetString(++i);
                uzivatel.Email = reader.GetString(++i);
                uzivatel.Adresa = reader.GetString(++i);
                uzivatel.Telefon = reader.GetString(++i);
                uzivatele.Add(uzivatel);
            }
            return uzivatele;
        }
    }
}