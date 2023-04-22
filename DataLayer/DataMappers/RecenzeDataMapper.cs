using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;
using DataLayer.DB;

namespace DataLayer.DataMappers
{
    public class RecenzeDataMapper
    {
        public static string SQL_INSERT = "insert into dbo.recenze (hvezdy,popis,kolo_id,uzivatel_id) OUTPUT INSERTED.ID values (@hvezdy,@popis,@kolo_id,@uzivatel_id)";
        public static string SQL_DELETE = "DELETE FROM dbo.recenze WHERE id =@id_recenze";
        public static string SQL_SELECT_ID = "SELECT * FROM dbo.recenze WHERE id=@id_recenze";
        public static string SQL_SELECT = "select dbo.recenze.id,dbo.recenze.hvezdy,dbo.recenze.popis,dbo.recenze.kolo_id,dbo.recenze.uzivatel_id,dbo.uzivatel.login+ ' '+dbo.uzivatel.jmeno+' '+dbo.uzivatel.prijmeni from dbo.recenze JOIN dbo.uzivatel ON dbo.recenze.uzivatel_id = dbo.uzivatel.id";
        public static string SQL_UPDATE = "UPDATE dbo.recenze SET hvezdy=@hvezdy,popis=@popis,kolo_id=@kolo_id,uzivatel_id=@uzivatel_id where id=@id_recenze";
        private static void PrepareCommand(SqlCommand command, Recenze recenze)
        {
            command.Parameters.AddWithValue("@id_recenze", recenze.Id);
            command.Parameters.AddWithValue("@hvezdy", recenze.Hvezdy);
            command.Parameters.AddWithValue("@popis", recenze.Popis);
            command.Parameters.AddWithValue("@kolo_id", recenze.KoloId);
            command.Parameters.AddWithValue("@uzivatel_id", recenze.UzivatelId);
        }
        
        public static bool Insert(Recenze recenze, Database pDb= null)
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
            PrepareCommand(command, recenze);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Update(Recenze recenze, Database pDb = null)
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
            PrepareCommand(command, recenze);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Delete(Recenze recenze, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_recenze", recenze.Id);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static Recenze GetRecenzeById(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_recenze", id);
            SqlDataReader reader = db.Select(command);

            Collection<Recenze> recenzes = Read(reader);
            Recenze recenze = null;
            if (recenzes.Count == 1)
            {
                recenze = recenzes[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return recenze;
        }
        
        public static Collection<Recenze> Select(Database pDb = null)
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

            Collection<Recenze> recenze = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return recenze;
        }
        
        
        private static Collection<Recenze> Read(SqlDataReader reader)
        {
            Collection<Recenze> recenzes = new Collection<Recenze>();

            while (reader.Read())
            {
                Recenze recenze = new Recenze();
                int i = -1;
                recenze.Id = reader.GetInt32(++i);
                recenze.Hvezdy = reader.GetInt32(++i);
                recenze.Popis = reader.GetString(++i);
                recenze.KoloId = reader.GetInt32(++i);
                recenze.UzivatelId = reader.GetInt32(++i);
                recenze.Uzivatel = reader.GetString(++i);
                recenzes.Add(recenze);
            }
            return recenzes;
        }
    }
}