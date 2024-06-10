using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoTech.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models
{
    public abstract class BaseUserModel : BaseModel
    {
        protected BaseUserModel()
        {

        }

        public string Cpf { get; protected set; }
        public string Password { get; protected set; }

        public virtual void GeneratePassword(string password)
        {
            //Password = PasswordHasher.HashPassword;
        }
    }
}
