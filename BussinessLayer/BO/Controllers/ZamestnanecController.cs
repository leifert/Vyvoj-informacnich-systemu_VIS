using System.Collections.ObjectModel;
using BussinessLayer.BO.Models;
using DataLayer.DataMappers;
using DTO;

namespace BussinessLayer.BO.Controllers
{
    public class ZamestnanecController
    {
        public static bool Insert(ZamestnanecModel zamestnanecModel)
        {

            return ZamestnanecDataMapper.Insert(zamestnanecModel.ToDTO());
        }
        
        public static Collection<ZamestnanecModel> SelectAll()
        {
            Collection<Zamestnanec> zamestnanci = ZamestnanecDataMapper.Select();
            Collection<ZamestnanecModel> ret = new Collection<ZamestnanecModel>();
            foreach (var zam in zamestnanci)
            {
                ret.Add(new ZamestnanecModel(zam));
            }
            return ret;
        }
        
        public static bool Update(ZamestnanecModel zamestnanecModel)
        {
            return ZamestnanecDataMapper.Update(zamestnanecModel.ToDTO());
        }
        
        public static bool Delete(ZamestnanecModel zamestnanecModel)
        {
            return ZamestnanecDataMapper.Delete(zamestnanecModel.ToDTO());
        }
        
        public static ZamestnanecModel GetZamestnanecById(int id)
        {
            return new ZamestnanecModel(ZamestnanecDataMapper.GetZamestnanecById(id));
        }
        public static void ExportToXml()
        {
            ZamestnanecDataMapper.ExportToXml();
        }
    }
}