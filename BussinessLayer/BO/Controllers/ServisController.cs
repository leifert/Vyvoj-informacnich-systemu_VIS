using System.Collections.ObjectModel;
using BussinessLayer.BO.Models;
using DataLayer.DataMappers;
using DTO;

namespace BussinessLayer.BO.Controllers
{
    public class ServisController
    {
        public static bool Insert(ServisModel servisModel)
        {

            return ServisDataMapper.Insert(servisModel.ToDTO());
        }
        
        public static Collection<ServisModel> SelectAll()
        {
            Collection<Servis> servisy = ServisDataMapper.Select();
            Collection<ServisModel> ret = new Collection<ServisModel>();
            foreach (var servis in servisy)
            {
                ret.Add(new ServisModel(servis));
            }
            return ret;
        }
        
        public static bool Update(ServisModel servisModel)
        {
            return ServisDataMapper.Update(servisModel.ToDTO());
        }
        
        public static bool Delete(ServisModel servisModel)
        {
            return ServisDataMapper.Delete(servisModel.ToDTO());
        }
        
        public static ServisModel GetservisById(int id)
        {
            return new ServisModel(ServisDataMapper.GetServisById(id));
        }
    }
}