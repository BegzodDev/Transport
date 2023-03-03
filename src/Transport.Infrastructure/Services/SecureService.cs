using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Application.Abstractions;

namespace Transport.Infrastructure.Services
{
    public class SecureService : ISecurityService
    {
        List<string> Robbers = new List<string>()
        {
            "AB1234561"
        };

        public bool CheckSecure(string pasport)
        {
            if (Robbers.Contains(pasport))
            {
                Console.WriteLine("Datasini berib securega habar ketadi");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
