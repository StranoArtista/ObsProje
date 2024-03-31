using ObsProje.Interfaces;
using ObsProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ObsProje.Models
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        // DataBase Encapsulation

        protected MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        //Save command
        protected void Save()
        {
            _db.SaveChanges();
        }

        //Item adding commands

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            item.CreatedDate = DateTime.Now;
            item.Status = Enums.DataStatus.Active;

            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            foreach (T i in list) Add(i);
            Save();
        }
        //Deleting Commands
        public void Delete(T item)
        {
            item.Status = Enums.DataStatus.Passive;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        //Destroying Commands
        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        //Getting Commands
        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public T Find(int id)
        {
            
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != Enums.DataStatus.Passive);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == Enums.DataStatus.Modified);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == Enums.DataStatus.Passive);
        }
        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        //Selecting Commands

        public object Select(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        //Updating Commands

        public void Update(T item)
        {
            item.UpdatedDate = DateTime.Now;
            item.Status = Enums.DataStatus.Modified;
            T originalEntity = Find(item.ID);
            _db.Entry(originalEntity).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list) Update(item);
        }

    }
}
