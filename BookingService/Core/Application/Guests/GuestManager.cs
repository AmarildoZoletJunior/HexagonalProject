using Application.Errors;
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

namespace Application.Guests
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

            if (!resultado.IsValid)
            {

                var lista = new List<ErrorResponse>();
                foreach (var erro in resultado.Errors)
                {
                    lista.Add(new ErrorResponse
                    {
                        ErrorMessages = erro.ErrorMessage,
                        ErrorType = erro.PropertyName
                    });
                }

                return new GuestResponse
                {
                    Success = false,
                    ListMessages = lista
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

        public async Task<GuestResponse> GetGuest(int id)
        {
            var getGuest = await _guestRepository.GetGuest(id);
            if (getGuest != null)
            {
                return new GuestResponse
                {
                    Data = GuestDto.MapToDTO(getGuest),
                    Success = true
                };
            }
            return new GuestResponse
            {
                Success = false,
                Message = "Não foi possivel encontrar este guest"
            };
        }


    }
}
