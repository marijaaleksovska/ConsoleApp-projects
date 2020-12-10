using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ParkingManagement.Repositories
{
    public abstract class BaseRepository<T>
    {
        private List<T> Entities{ get; set; }

        public BaseRepository()
        {
            var entities = File.ReadAllText($"./../../../../ParkingManagement.Repositories/DB/{GetFileName()}");
            var deserialized = JsonConvert.DeserializeObject<List<T>>(entities);

            if(deserialized == null)
            {
                deserialized = new List<T>();
            }

            Entities = deserialized;
        }
        protected abstract string GetFileName();

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public List<T> GetAll()
        {
            return Entities;
        }

        public List<T> GetAllWhere(Func<T, bool> predicate)
        {
            return Entities.Where(predicate).ToList();
        }

        public T GetFirstWhere(Func<T, bool> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public void SaveChanges()
        {
            var serialized = JsonConvert.SerializeObject(Entities);
            File.WriteAllText($"./../../../../ParkingManagement.Repositories/DB/{GetFileName()}", serialized);
        }
    }
}
