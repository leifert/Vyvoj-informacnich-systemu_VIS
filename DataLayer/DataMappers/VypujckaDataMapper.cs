using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;
using DataLayer.DB;

namespace DataLayer.DataMappers
{
    public class VypujckaDataMapper
    {
        public static string SQL_INSERT = "insert into dbo.vypujcka (zacatek_vypujcky,konec_vypujcky,cena,zamestnanec_id,kolo_id,uzivatel_id) OUTPUT INSERTED.ID values (@zacatek,@konec,@cena,@zamestnanec_id,@kolo_id,@uzivatel_id)";
        public static string SQL_DELETE = "DELETE FROM dbo.vypujcka WHERE id =@id_vypujcka";
        public static string SQL_SELECT = "select dbo.vypujcka.id,dbo.vypujcka.zacatek_vypujcky,dbo.vypujcka.konec_vypujcky,dbo.vypujcka.cena,dbo.vypujcka.zamestnanec_id,dbo.vypujcka.kolo_id,dbo.vypujcka.uzivatel_id,CONCAT(dbo.zamestnanec.login, ' ',dbo.zamestnanec.jmeno,' ',dbo.zamestnanec.prijmeni),CONCAT(dbo.uzivatel.login, ' ',dbo.uzivatel.jmeno,' ',dbo.uzivatel.prijmeni) from dbo.vypujcka JOIN dbo.zamestnanec ON dbo.vypujcka.zamestnanec_id = dbo.zamestnanec.id JOIN dbo.uzivatel ON dbo.vypujcka.uzivatel_id = dbo.uzivatel.id";
        public static string SQL_SELECT_ID = "SELECT * FROM dbo.vypujcka WHERE id=@id_vypujcka";
        public static string SQL_UPDATE = "UPDATE dbo.vypujcka SET zacatek_vypujcky=@zacatek,konec_vypujcky=@konec,cena=@cena,zamestnanec_id=@zamestnanec_id,kolo_id=@kolo_id,uzivatel_id=@uzivatel_id where id=@id_vypujcka";
        private static void PrepareCommand(SqlCommand command, Vypujcka vypujcka)
        {
            command.Parameters.AddWithValue("@id_vypujcka", vypujcka.Id);
            command.Parameters.AddWithValue("@zacatek", vypujcka.Zacatek);
            command.Parameters.AddWithValue("@konec", vypujcka.Konec);
            command.Parameters.AddWithValue("@cena", vypujcka.Cena);
            command.Parameters.AddWithValue("@zamestnanec_id", vypujcka.ZamestnanecId);
            command.Parameters.AddWithValue("@kolo_id", vypujcka.KoloId);
            command.Parameters.AddWithValue("@uzivatel_id", vypujcka.UzivatelId);
        }
        
        public static bool Insert(Vypujcka vypujcka, Database pDb= null)
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
            PrepareCommand(command, vypujcka);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Update(Vypujcka vypujcka, Database pDb = null)
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
            PrepareCommand(command, vypujcka);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Delete(Vypujcka vypujcka, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_vypujcka", vypujcka.Id);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static Vypujcka GetVypujckaById(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_vypujcka", id);
            SqlDataReader reader = db.Select(command);

            Collection<Vypujcka> vypujcky = Read(reader);
            Vypujcka vypujcka = null;
            if (vypujcky.Count == 1)
            {
                vypujcka = vypujcky[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return vypujcka;
        }
        
        public static Collection<Vypujcka> Select(Database pDb = null)
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

            Collection<Vypujcka> vypujcky = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return vypujcky;
        }
        
        
        private static Collection<Vypujcka> Read(SqlDataReader reader)
        {
            Collection<Vypujcka> vypujcky = new Collection<Vypujcka>();

            while (reader.Read())
            {
                Vypujcka vypujcka = new Vypujcka();
                int i = -1;
                vypujcka.Id = reader.GetInt32(++i);
                vypujcka.Zacatek = reader.GetDateTime(++i);
                vypujcka.Konec = reader.GetDateTime(++i);
                vypujcka.Cena = reader.GetInt32(++i);
                vypujcka.ZamestnanecId = reader.GetInt32(++i);
                vypujcka.KoloId = reader.GetInt32(++i);
                vypujcka.UzivatelId = reader.GetInt32(++i);
                vypujcka.Zamestnanec = reader.GetString(++i);
                vypujcka.Uzivatel = reader.GetString(++i);
                vypujcky.Add(vypujcka);
            }
            return vypujcky;
        }
    } 
}
