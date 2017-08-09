using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RChino.DataAccess.Crud;
using RChino.Entities;

namespace RChino.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            var command = "";
            var crud = new CrudUser();



            do
            {
                Console.WriteLine("Ingrese el comando deseado:");
                command = Console.ReadLine();

                if (command != null && command.Equals("create", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Digite el ID del usuario");
                    var id = Console.ReadLine();
                    Console.WriteLine("Digite el Nombre del usuario");
                    var name = Console.ReadLine();
                    Console.WriteLine("Digite el Apellido del usuario");
                    var lastName = Console.ReadLine();

                    var user = new User
                    {
                        Id = id,
                        Name = name,
                        LastName = lastName
                    };
                    crud.Create(user);

                    Console.WriteLine("Usuario creado con exito");
                }
                else if (command != null && command.Equals("retrieve_id", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Digite el ID del usuario a consultar");
                    var id = Console.ReadLine();
                    var user = new User
                    {
                        Id = id
                    };

                    user = crud.Retrieve<User>(user);
                    Console.WriteLine("Nombre del usuario: " + user.Name + " " + user.LastName);

                }

            } while (command != null && !command.Equals("exit"));
        }
    }
}
