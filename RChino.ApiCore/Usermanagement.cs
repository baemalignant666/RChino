using RChino.DataAccess.Crud;
using RChino.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RChino.ApiCore
{
    public class UserManagement : BaseManagement
    {
        public UserManagement()
        {
            _factory = new CrudUser();
        }

        public void CreateUser(User pUser)
        {
            _factory.Create(pUser);
        }
         
        public User Retrieve(User pUser)
        {
            var list = _factory.Retrieve<User>(pUser);// SE UTILIZA UN ARREGLO PARA DEVOLVER EL REGISTRO CREADO 
            //DE LA FABRICA
            return list;
        } 
        
        public List<T> RetrieveAlls<T>()
        {
            var list = new List<T>(); //VARIABLE DE RETORNO
            var lista = _factory.RetrieveAll<User>();
            //PROCEDIMIENTO DEL FACTORY RETRIEVEALL
            if(lista.Count > 0) //CICLO/RECORRRER LA VARIABLE DE LA FABRICA
            {
                foreach (var obj in lista)
                {
                    list.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return list;
        }
        
        public void Delete(User pUser)
        {
            _factory.Delete(pUser);
        } 
        
        public void Update(User pUser)
        {
            _factory.Update(pUser);
        }
    }
}
