using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
