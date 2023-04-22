using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;
using DataLayer.DB;

namespace DataLayer.DataMappers
{
    public class ServisDataMapper
    {
        public static string SQL_INSERT = "insert into dbo.servis (zacatek,konec,popis,kolo_id,zamestnanec_id) OUTPUT INSERTED.ID values (@zacatek,@konec,@popis,@kolo_id,@zamestnanec_id)";
        public static string SQL_DELETE = "DELETE FROM dbo.servis WHERE id =@id_servis";
        public static string SQL_SELECT = "select dbo.servis.id,dbo.servis.zacatek,dbo.servis.konec,dbo.servis.popis,dbo.servis.kolo_id,dbo.servis.zamestnanec_id,CONCAT(dbo.zamestnanec.login, ' ',dbo.zamestnanec.jmeno,' ',dbo.zamestnanec.prijmeni) from dbo.servis JOIN dbo.zamestnanec ON dbo.servis.zamestnanec_id = dbo.zamestnanec.id";
        public static string SQL_SELECT_ID = "SELECT * FROM dbo.servis WHERE id=@id_servis";
        public static string SQL_UPDATE = "UPDATE dbo.servis SET zacatek=@zacatek,konec=@konec,popis=@popis,kolo_id=@kolo_id,zamestnanec_id=@zamestnanec_id where id=@id_servis";
        private static void PrepareCommand(SqlCommand command, Servis servis)
        {
            command.Parameters.AddWithValue("@id_servis", servis.Id);
            command.Parameters.AddWithValue("@zacatek", servis.Zacatek);
            command.Parameters.AddWithValue("@konec", servis.Konec);
            command.Parameters.AddWithValue("@popis", servis.Popis);
            command.Parameters.AddWithValue("@kolo_id", servis.KoloId);
            command.Parameters.AddWithValue("@zamestnanec_id", servis.ZamestnanecId);
        }
        
        public static bool Insert(Servis servis, Database pDb= null)
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
            PrepareCommand(command, servis);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Update(Servis servis, Database pDb = null)
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
            PrepareCommand(command, servis);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Delete(Servis servis, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_servis", servis.Id);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static Servis GetServisById(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_servis", id);
            SqlDataReader reader = db.Select(command);

            Collection<Servis> servisy = Read(reader);
            Servis servis = null;
            if (servisy.Count == 1)
            {
                servis = servisy[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return servis;
        }
        
        public static Collection<Servis> Select(Database pDb = null)
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

            Collection<Servis> servisy = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return servisy;
        }
        
        
        
        private static Collection<Servis> Read(SqlDataReader reader)
        {
            Collection<Servis> servisy = new Collection<Servis>();

            while (reader.Read())
            {
                Servis servis = new Servis();
                int i = -1;
                servis.Id = reader.GetInt32(++i);
                servis.Zacatek = reader.GetDateTime(++i);
                servis.Konec = reader.GetDateTime(++i);
                servis.Popis = reader.GetString(++i);
                servis.KoloId = reader.GetInt32(++i);
                servis.ZamestnanecId = reader.GetInt32(++i);
                servis.Zamestnanec = reader.GetString(++i);
                servisy.Add(servis);
            }
            return servisy;
        }
    }
}