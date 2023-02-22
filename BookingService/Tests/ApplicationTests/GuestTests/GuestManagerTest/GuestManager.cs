using AdaptersSQL.Guest;
using API.Controllers;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Domain.Entities;
using Domain.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace ApplicationTests.GuestTests.GuestManagerTest
{

    public class GuestManager
    {
        Application.Guests.GuestManager manager;

        [Fact]
        public async Task AdicionarGuestCorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

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
        public async Task AdicionarGuestEmailIncorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

            var guestDTO = new GuestDto
            {
                Email = "amarildozj",
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

            Assert.False(response.Success);
            Assert.Contains("Email", response.ListMessages.Select(x => x.ErrorType));
        }

        [Fact]
        public async Task AdicionarGuestIdNumberIncorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124123.451",
                IdTypeCode = 1,
                Name = "Amarildo",
                Surname = "Teste"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains("IdNumber", response.ListMessages.Select(x => x.ErrorType));
        }

        [Fact]
        public async Task AdicionarGuestIdTypeCodeIncorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124.123.451-12",
                IdTypeCode = 5,
                Name = "Amarildo",
                Surname = "Teste"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains("IdTypeCode", response.ListMessages.Select(x => x.ErrorType));
        }

        [Fact]
        public async Task AdicionarGuestNameIncorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124.123.451-12",
                IdTypeCode = 1,
                Name = "Am",
                Surname = "Teste"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains("Name", response.ListMessages.Select(x => x.ErrorType));
        }

        [Fact]
        public async Task AdicionarGuestSurnameIncorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

            var guestDTO = new GuestDto
            {
                Email = "amarildozj@gmail.com",
                IdNumber = "124.123.451-12",
                IdTypeCode = 1,
                Name = "Amarildo",
                Surname = "te"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Contains("Surname", response.ListMessages.Select(x => x.ErrorType));
        }

        [Fact]
        public async Task AdicionarGuestTudoIncorreto()
        {
            var fakerepo = new Mock<IGuestRepository>();
            fakerepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult(111));

            manager = new Application.Guests.GuestManager(fakerepo.Object);

            var guestDTO = new GuestDto
            {
                Email = "amarildoz",
                IdNumber = "124.",
                IdTypeCode = -5,
                Name = "Am",
                Surname = "te"
            };

            var guest = new CreateGuestRequest
            {
                Data = guestDTO
            };

            var response = await manager.CreateGuest(guest);

            Assert.False(response.Success);
            Assert.Collection(response.ListMessages.Select(x => x.ErrorType),
                item => item.Contains("Name"),
                item => item.Contains("IdNumber"),
                item => item.Contains("IdTypeCode"),
                item => item.Contains("Surname"),
                item => item.Contains("Email"));
        }
    }
}