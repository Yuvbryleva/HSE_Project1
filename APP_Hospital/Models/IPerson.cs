using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Hospital.Models
{
    public interface IPerson
    {
        string Name { get; set; }
    }
    public interface ISecurity
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}
