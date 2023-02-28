using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Application.Abstractions
{
    public interface ICurrentUserService
    {
        int UserId { get; set; }
    }
}
