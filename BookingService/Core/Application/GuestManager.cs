using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
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
            try
            {
                var guest = GuestDto.MapToEntity(guestRequest.Data);
                guestRequest.Data.Id = await _guestRepository.Create(guest);
                return new GuestResponse
                {
                    Data = guestRequest.Data,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    Message = "Erro em salvar dados no banco",
                    ErrorCode = ErrorCodes.COULDNOT_STORE_DATA
                };
            }
        }
    }
}
