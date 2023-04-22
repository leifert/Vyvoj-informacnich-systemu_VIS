using System.Collections.ObjectModel;
using BussinessLayer.BO.Models;
using DataLayer.DataMappers;
using DTO;

namespace BussinessLayer.BO.Controllers
{
    public class UzivatelController
    {
        public static bool Insert(UzivatelModel uzivatelModel)
        {

            return UzivatelDataMapper.Insert(uzivatelModel.ToDTO());
        }
        
        public static Collection<UzivatelModel> SelectAll()
        {
            Collection<Uzivatel> uzivatele = UzivatelDataMapper.Select();
            Collection<UzivatelModel> ret = new Collection<UzivatelModel>();
            foreach (var uzivatel in uzivatele)
            {
                ret.Add(new UzivatelModel(uzivatel));
            }
            return ret;
        }
        
        public static bool Update(UzivatelModel uzivatelModel)
        {
            return UzivatelDataMapper.Update(uzivatelModel.ToDTO());
        }
        
        public static bool Delete(UzivatelModel uzivatelModel)
        {
            return UzivatelDataMapper.Delete(uzivatelModel.ToDTO());
        }
        
        public static UzivatelModel GetUzivatelById(int id)
        {
            return new UzivatelModel(UzivatelDataMapper.GetUzivatelById(id));
        }
    }
}