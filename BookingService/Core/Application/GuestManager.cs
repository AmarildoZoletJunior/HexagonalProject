using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Application.Guests.Validators;
using Domain.Entities;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private IGuestRepository _guestRepository;
        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        public async Task<GuestResponse> CreateGuest(CreateGuestRequest guestRequest)
        {
            var guestDto = guestRequest.Data;
            var validator = new GuestValidator();
            var resultado = validator.Validate(guestDto);
            if (!resultado.IsValid){

                var lista = new List<string>();
                foreach(var erro in resultado.Errors){
                    lista.Add(erro.ErrorMessage);
                }

                return new GuestResponse
                {
                    Success = false,
                    ErrorCode = 400,
                    Message = lista
                };
            }

            var guest = GuestDto.MapToEntity(guestRequest.Data);
            await guest.SaveAsync(_guestRepository);
            guestRequest.Data.Id = guest.Id;
            
                return new GuestResponse
                {
                    Data = guestRequest.Data,
                    Success = true
                };
        }
       public async Task<List<Guest>> GetGuests()
        {
            var teste =  _guestRepository.Get();
            return teste;
        }
    }
}
