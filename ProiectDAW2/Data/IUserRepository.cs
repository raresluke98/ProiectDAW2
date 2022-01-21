using ProiectDAW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW2.Data
{
    public interface IUserRepository
    {
        User Create(User user);
    }
}
