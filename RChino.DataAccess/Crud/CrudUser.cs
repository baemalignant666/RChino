using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RChino.DataAccess.Crud;
using RChino.Entities;
using RChino.DataAccess.Mapper;
using RChino.DataAccess.Dao;

namespace RChino.DataAccess.Crud
{
    public class CrudUser : CrudFactory
    {
        private readonly UserMapper _mapper;

        public CrudUser()
        {
            _mapper = new UserMapper();
        }
        public override bool Create(BaseEntity entity)
        {
            var operation = _mapper.GetCreateStatement(entity);
            var instance = SqlDao.GetInstance();
            instance.ExecuteProcedure(operation);

            return true;
        }

        public override T RCreate<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override bool Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}