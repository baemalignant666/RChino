using System;
using System.Collections.Generic;
using RChino.DataAccess.Dao;
using RChino.Entities;

namespace RChino.DataAccess.Mapper
{
    public class UserMapper : EntityMapper, IObjectMapper, ISqlStaments
    {

        private const string DbColId = "ID";
        private const string DbColName = "NAME";
        private const string DbColLastName = "LAST_NAME";


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id = GetStringValue(row, DbColId),
                Name = GetStringValue(row, DbColName),
                LastName = GetStringValue(row, DbColLastName),
            };

            return user;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "CRE_USER"
            };

            var user = (User)entity;
            operation.AddVarcharParam(DbColId, user.Id);
            operation.AddVarcharParam(DbColName, user.Name);
            operation.AddVarcharParam(DbColLastName, user.LastName);

            return operation;
        }

        public SqlOperation GetRCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "RET_USER_BY_ID"
            };

            var user = (User)entity;
            operation.AddVarcharParam(DbColId, user.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}