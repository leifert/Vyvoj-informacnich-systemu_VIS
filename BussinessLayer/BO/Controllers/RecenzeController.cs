using System.Collections.ObjectModel;
using BussinessLayer.BO.Models;
using DataLayer.DataMappers;
using DTO;

namespace BussinessLayer.BO.Controllers
{
    public class RecenzeController
    {
        public static bool Insert(RecenzeModel recenzeModel)
        {

            return RecenzeDataMapper.Insert(recenzeModel.ToDTO());
        }
        
        public static Collection<RecenzeModel> SelectAll()
        {
            Collection<Recenze> recenzes = RecenzeDataMapper.Select();
            Collection<RecenzeModel> ret = new Collection<RecenzeModel>();
            foreach (var rec in recenzes)
            {
                ret.Add(new RecenzeModel(rec));
            }
            return ret;
        }
        
        public static bool Update(RecenzeModel recenzeModel)
        {
            return RecenzeDataMapper.Update(recenzeModel.ToDTO());
        }
        
        public static bool Delete(RecenzeModel recenzeModel)
        {
            return RecenzeDataMapper.Delete(recenzeModel.ToDTO());
        }
        
        public static RecenzeModel GetRecenzeById(int id)
        {
            return new RecenzeModel(RecenzeDataMapper.GetRecenzeById(id));
        }
    }
}