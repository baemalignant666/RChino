using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RChino.DataAccess.Crud;
using RChino.Entities;

namespace RChino.Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var user = new User()
                {
                    Id = "01033",
                    Name = "Igor",
                    LastName = "Contratovich"
                };
                var crud = new CrudUser();
                crud.Create(user);

                Console.WriteLine("Registro Insertado");
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
