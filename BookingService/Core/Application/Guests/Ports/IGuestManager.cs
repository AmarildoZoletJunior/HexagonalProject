﻿using Application.Guests.Requests;
using Application.Guests.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> CreateGuest(CreateGuestRequest guest);
        Task<List<Guest>> GetGuests();
    }
}
