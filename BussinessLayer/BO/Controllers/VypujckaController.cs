using System.Collections.ObjectModel;
using BussinessLayer.BO.Models;
using DataLayer.DataMappers;
using DTO;

namespace BussinessLayer.BO.Controllers
{
    public class VypujckaController
    {
        public static bool Insert(VypujckaModel vypujckaModel)
        {

            return VypujckaDataMapper.Insert(vypujckaModel.ToDTO());
        }
        
        public static Collection<VypujckaModel> SelectAll()
        {
            Collection<Vypujcka> vypujcky = VypujckaDataMapper.Select();
            Collection<VypujckaModel> ret = new Collection<VypujckaModel>();
            foreach (var vypujcka in vypujcky)
            {
                ret.Add(new VypujckaModel(vypujcka));
            }
            return ret;
        }
        
        public static bool Update(VypujckaModel vypujckaModel)
        {
            return VypujckaDataMapper.Update(vypujckaModel.ToDTO());
        }
        
        public static bool Delete(VypujckaModel vypujckaModel)
        {
            return VypujckaDataMapper.Delete(vypujckaModel.ToDTO());
        }
        
        public static VypujckaModel GetVypujckaById(int id)
        {
            return new VypujckaModel(VypujckaDataMapper.GetVypujckaById(id));
        }
    }
}