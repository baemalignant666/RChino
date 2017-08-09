using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RChino.DataAccess.Dao;
using RChino.DataAccess.Mapper;
using RChino.Entities;

namespace RChino.DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao SqlSqlDao;
        protected EntityMapper EntityMapper { get; set; }

        public abstract bool Create(BaseEntity entity);
        public abstract T RCreate<T>(BaseEntity entity);
        public abstract T Retrieve<T>(BaseEntity entity);
        public abstract List<T> RetrieveAll<T>();
        public abstract bool Update(BaseEntity entity);
        public abstract bool Delete(BaseEntity entity);
        
    }
}
