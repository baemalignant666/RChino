using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RChino.Entities
{
    public class User : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public User()
        {

        }

        public User(string Id)
        {
            this.Id = Id;
        }

        public User(string pId, string pName, string pLastName)
        {
            this.Id = pId;
            this.Name = pName;
            this.LastName = pLastName;
        }

    }

}
