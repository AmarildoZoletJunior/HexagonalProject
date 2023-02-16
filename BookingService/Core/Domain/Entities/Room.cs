﻿using Domain.Ports;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Price PriceRoom { get; set; }
        public bool InMaintenance { get; set; }

        public bool IsAvailable {
            get
            {
                if (!this.InMaintenance || this.HasGuest)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasGuest
        {
            //Verificar se existem bookins abertos para esta Room
            get { return true; }
        }

        public async Task SaveAsync(IRoomRepository repository)
        {
            this.Id = await repository.Create(this);
        }
    }
}
