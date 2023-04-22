using System.Collections.ObjectModel;
using BussinessLayer.BO.Models;
using DataLayer.DataMappers;
using DTO;

namespace BussinessLayer.BO.Controllers
{
    public class KoloController
    {
        public static bool Insert(KoloModel koloModel)
        {

            return KoloDataMapper.Insert(koloModel.ToDTO());
        }
        
        public static Collection<KoloModel> SelectAll()
        {
            Collection<Kolo> kola = KoloDataMapper.Select();
            Collection<KoloModel> ret = new Collection<KoloModel>();
            foreach (var kolo in kola)
            {
                ret.Add(new KoloModel(kolo));
            }
            return ret;
        }
        
        public static bool Update(KoloModel koloModel)
        {
            return KoloDataMapper.Update(koloModel.ToDTO());
        }
        
        public static bool Delete(KoloModel koloModel)
        {
            return KoloDataMapper.Delete(koloModel.ToDTO());
        }
        
        public static KoloModel GetKoloById(int id)
        {
            return new KoloModel(KoloDataMapper.GetKoloById(id));
        }
        
    }
}