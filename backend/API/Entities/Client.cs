using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enums;
namespace API.Entities
{
    public class Client
    {
        public Client(string? name, string? email, string? password)
        {
            Guid g = Guid.NewGuid();
            this.IdClient = g.ToString();
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        public string IdClient { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }

        public void changeInfo(string? value, EClient prop)
        {
            switch (prop)
            {
                case EClient.Name:
                    if (value != null)
                    {
                        if (this.Name != value)
                        {
                            this.Name = value;
                        }
                    }
                    break;
                case EClient.Email:
                    if (value != null)
                    {
                        if (this.Email != value)
                        {
                            this.Email = value;
                        }
                    }
                    break;
                case EClient.Password:
                    if (value != null)
                    {
                        if (this.Password != value)
                        {
                            this.Password = value;
                        }
                    }
                    break;
            }
        }
    }
}