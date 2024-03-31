using ObsProje.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ObsProje.Models
{
    public class Base_Manager<T> : IManager<T> where T : class, IEntity
    {
        //Repository Encapsulation

        protected IRepository<T> _iRep;

        public Base_Manager(IRepository<T> iRep)
        {
            _iRep = iRep;
        }

        //Item adding commands

        public void Add(T item)
        {
            _iRep.Add(item);
        }

        public void AddRange(List<T> list)
        {
            _iRep.AddRange(list);
        }

        //Deleting Commands

        public void Delete(T item)
        {
            _iRep.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            _iRep.DeleteRange(list);
        }

        //Destroying Commands

        public string Destroy(T item)
        {
            if (item.Status != ObsProje.Enums.DataStatus.Passive)
            {
                return "Bir veriyi yok etmek için öncelikle o verinin pasif hale getirildiğinden emin olunuz.";
            }
            _iRep.Destroy(item);
            return "Veri yok edildi.";
        }

        public string DestroyRange(List<T> list)
        {
            _iRep.DestroyRange(list);
            return "Verdiğiniz aralıktaki veriler yok edildi.";
        }
        public string DestroyRange_Passive(List<T> list)
        {
            foreach (var i in list)
            {
                if (i.Status != ObsProje.Enums.DataStatus.Passive)
                {
                    return "Bir veriyi yok etmek için öncelikle o verinin pasif hale getirildiğinden emin olunuz.";
                }
                else
                {
                    _iRep.Destroy(i);
                    return $"{i.ID} numaralı veri yok edildi.";
                }
            }
            return "İşlem tamamlandı";

        }

        //Getting Commands
        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _iRep.Any(exp);
        }
        public T Find(int id)
        {
            return _iRep.Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _iRep.FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return _iRep.GetActives();
        }

        public List<T> GetAll()
        {
            return _iRep.GetAll();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _iRep.GetFirstDatas(count);
        }

        public List<T> GetLastDatas(int count)
        {
            return _iRep.GetLastDatas(count);
        }

        public List<T> GetModifieds()
        {
            return _iRep.GetModifieds();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetPassives();
        }
        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }

        //Selecting Commands

        public object Select(Expression<Func<T, bool>> exp)
        {
            return _iRep.Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select<X>(exp);
        }

        //Updating Commands

        public void Update(T item)
        {
            _iRep.Update(item);
        }

        public void UpdateRange(List<T> list)
        {
            _iRep.UpdateRange(list);
        }
    }
}
