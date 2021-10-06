using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Entities
{
    public class Users : BaseEntity
    {
        public string password { get; set; }
        public string address { get; set; }

        public string usersImageUrl { get; set; }



    }
}
