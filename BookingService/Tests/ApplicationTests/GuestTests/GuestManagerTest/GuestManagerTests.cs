using AdaptersSQL.Guest;
using API.Controllers;
using Application.Guests;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Domain.Entities;
using Domain.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace ApplicationTests.RoomTests.RoomManagerTest
{

    public class RoomManagerTests
    {
        public Mock<IGuestRepository> GuestRepository;
        public GuestManager manager;

        public RoomManagerTests()
        {
            GuestRepository = new Mock<IGuestRepository>();
            manager = new GuestManager(GuestRepository.Object);
        }

        [Fact]
        public async Task AdicionarGuestCorreto()
        {
            GuestRepository.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124.123.451-21",
                IdTypeCode = 1,
                Name = "Amarildo",
                Surname = "Teste"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.True(response.Success);
        }


        [Fact]
        public async Task ReturnGuestCreatedById50()
        {
            GuestRepository.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(50));


            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124.123.451-21",
                IdTypeCode = 1,
                Name = "Amarildo",
                Surname = "Teste"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.Equal(response.Data.Id,guestDTO.Id);
        }


        [Theory]
        [InlineData("Amarildozj","123.123.424-39",1,"Amarildo","Junior","Email")]
        [InlineData("Amarildozj@gmail.com", "123.123.424", 1, "Amarildo", "Junior", "IdNumber")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 0, "Amarildo", "Junior", "IdTypeCode")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 3, "Amarildo", "Junior", "IdTypeCode")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 1, "Am", "Junior", "Name")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 1, "Amarildo", "Ju", "Surname")]
        public async Task AdicionarGuestIncorreto(string email,string idnum,int typecode,string name,string surname,string typeNameError)
        {
            GuestRepository.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));


            var guestDTO = new GuestDto
            {
                Email = email,
                IdNumber = idnum,
                IdTypeCode = typecode,
                Name = name,
                Surname = surname
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains(typeNameError, response.ListMessages.Select(x => x.ErrorType));
        }



        [Theory]
        [InlineData(null, "123.123.424-39", 1, "Amarildo", "Junior", "Email")]
        [InlineData("Amarildozj@gmail.com", null, 1, "Amarildo", "Junior", "IdNumber")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", null, "Amarildo", "Junior", "IdTypeCode")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", null, "Amarildo", "Junior", "IdTypeCode")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 1, null, "Junior", "Name")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 1, "Amarildo", null, "Surname")]
        public async Task AdicionarGuestNull(string email, string idnum, int typecode, string name, string surname, string typeNameError)
        {
            GuestRepository.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));
            var guestDTO = new GuestDto
            {
                Email = email,
                IdNumber = idnum,
                IdTypeCode = typecode,
                Name = name,
                Surname = surname
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains(typeNameError, response.ListMessages.Select(x => x.ErrorType));
        }



        [Theory]
        [InlineData("", "123.123.424-39", 1, "Amarildo", "Junior", "Email")]
        [InlineData("Amarildozj@gmail.com", "", 1, "Amarildo", "Junior", "IdNumber")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 1, "", "Junior", "Name")]
        [InlineData("Amarildozj@gmail.com", "123.123.424-39", 1, "Amarildo", "", "Surname")]
        public async Task AdicionarGuestVazio(string email, string idnum, int typecode, string name, string surname, string typeNameError)
        {
            GuestRepository.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            var guestDTO = new GuestDto
            {
                Email = email,
                IdNumber = idnum,
                IdTypeCode = typecode,
                Name = name,
                Surname = surname
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains(typeNameError, response.ListMessages.Select(x => x.ErrorType));
        }
    }
}