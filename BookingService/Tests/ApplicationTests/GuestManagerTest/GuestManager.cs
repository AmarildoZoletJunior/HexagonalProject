using AdaptersSQL.Guest;
using API.Controllers;
using Application;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Domain.Entities;
using Domain.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace ApplicationTests.GuestManagerTest
{


    class Fake : IGuestRepository
    {
        public Task<int> Create(Guest guest)
        {
            return Task.FromResult(111);
        }

        public List<Guest> Get()
        {
            throw new NotImplementedException();
        }
    }
    public class GuestManager
    {

        Application.GuestManager managerteste;

        [Fact]
        public async Task TesteAdd()
        {
            var fake = new Fake();
            managerteste = new Application.GuestManager(fake);

            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124.123.451-21",
                IdTypeCode = 1,
                Name = "Am",
                Surname = "Teste"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
             };

            var response = await managerteste.CreateGuest(guest);

                
            Assert.True(response.Success);
        }
    }
}