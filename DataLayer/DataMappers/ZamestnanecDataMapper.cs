using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using DTO;
using DataLayer.DB;

namespace DataLayer.DataMappers
{
    public class ZamestnanecDataMapper
    {
         public static string SQL_SELECT = "SELECT * FROM dbo.zamestnanec";
        public static string SQL_SELECT_ID = "SELECT * FROM dbo.zamestnanec WHERE id =@id_zam";
        public static string SQL_INSERT = "insert into dbo.zamestnanec (login,jmeno,prijmeni,email,adresa,telefon,bankovni_ucet,pracovni_pomer_od) OUTPUT INSERTED.ID values (@login,@jmeno,@prijmeni,@email,@adresa,@telefon,@bank_ucet,@prac_pom)";
        public static string SQL_UPDATE = "update dbo.zamestnanec set login=@login,jmeno=@jmeno,prijmeni=@prijmeni,email=@email,adresa=@adresa,telefon=@telefon,bankovni_ucet=@bank_ucet,pracovni_pomer_od=@prac_pom where id = @id_zam";
        public static string SQL_DELETE = "DELETE FROM dbo.zamestnanec WHERE id =@id_zam";
        
        
        private static void PrepareCommand(SqlCommand command, Zamestnanec zamestnanec)
        {
            command.Parameters.AddWithValue("@id_zam", zamestnanec.Id);
            command.Parameters.AddWithValue("@login",zamestnanec.Login);
            command.Parameters.AddWithValue("@jmeno", zamestnanec.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", zamestnanec.Prijmeni);
            command.Parameters.AddWithValue("@email", zamestnanec.Email);
            command.Parameters.AddWithValue("@adresa", zamestnanec.Adresa);
            command.Parameters.AddWithValue("@telefon", zamestnanec.Telefon);
            command.Parameters.AddWithValue("@bank_ucet", zamestnanec.BankUcet);
            command.Parameters.AddWithValue("@prac_pom", zamestnanec.PracovniPomerOd);
        }
        
        
         public static bool Insert(Zamestnanec zamestnanec, Database pDb= null)
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
            PrepareCommand(command, zamestnanec);
            bool ret = db.ExecuteNonQuery(command) > 0;
  
            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Update(Zamestnanec zamestnanec, Database pDb = null)
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
            PrepareCommand(command, zamestnanec);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static bool Delete(Zamestnanec zamestnanec, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_zam", zamestnanec.Id);
            bool ret = db.ExecuteNonQuery(command) > 0;

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static Zamestnanec GetZamestnanecById(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_zam", id);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader);
            Zamestnanec zamestnanec = null;
            if (zamestnanci.Count == 1)
            {
                zamestnanec = zamestnanci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanec;
        }
        public static Collection<Zamestnanec> Select(Database pDb = null)
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

            Collection<Zamestnanec> zamestnanci = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanci;
        }
        
        
        private static Collection<Zamestnanec> Read(SqlDataReader reader)
        {
            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                Zamestnanec zamestnanec = new Zamestnanec();
                int i = -1;
                zamestnanec.Id = reader.GetInt32(++i);
                zamestnanec.Login = reader.GetString(++i);
                zamestnanec.Jmeno = reader.GetString(++i);
                zamestnanec.Prijmeni = reader.GetString(++i);
                zamestnanec.Email = reader.GetString(++i);
                zamestnanec.Adresa = reader.GetString(++i);
                zamestnanec.Telefon = reader.GetString(++i);
                zamestnanec.BankUcet = reader.GetString(++i);
                zamestnanec.PracovniPomerOd = reader.GetDateTime(++i);;
                zamestnanci.Add(zamestnanec);
            }
            return zamestnanci;
        }
        public static void ExportToXml()
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                Collection<Zamestnanec> zamestnanecs = Select();
                foreach (var zam in zamestnanecs)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Zamestnanec));
                    xmlSerializer.Serialize(stringWriter, zam);
                }
                File.WriteAllText("export.xml", stringWriter.ToString());
            }
        }
    }
}