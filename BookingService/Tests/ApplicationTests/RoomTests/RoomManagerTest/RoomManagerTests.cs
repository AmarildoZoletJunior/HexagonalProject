using AdaptersSQL.Guest;
using API.Controllers;
using Application.Guests.DTOs;
using Application.Guests.Ports;
using Application.Guests.Requests;
using Application.Guests.Responses;
using Application.Room;
using Application.Room.DTOs;
using Application.Room.Ports;
using Application.Room.Requests;
using Application.Room.Responses;
using Domain.Entities;
using Domain.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace ApplicationTests.GuestTests.GuestManagerTest
{

    public class RoomManagerTests
    {
        public RoomManager manage;
        public Mock<IRoomRepository> RoomRepository;
        public RoomManagerTests()
        {
            RoomRepository = new Mock<IRoomRepository>();
            manage = new RoomManager(RoomRepository.Object);
        }


        [Fact]
        public async Task AdicionarRoomCorreto()
        {
            RoomRepository.Setup(x => x.Create(It.IsAny<Room>())).Returns(Task.FromResult(111));

            var RoomDTO = new RoomDto
            {
                     Currency = 1,
                      InMaintenance = true,
                       Level = 2,
                        Name = "Suite com banheiro",
                         Value = 25,
            };

            var room = new CreateRoomRequest
            {
                Data = RoomDTO
            };

            var response = await manage.CreateRoom(room);

            Assert.True(response.Success);
        }

        [Fact]
        public async Task ReturnGetRoomById()
        {
            var RoomDTO = new RoomDto
            {
                Id = 50,
                Currency = 1,
                InMaintenance = true,
                Level = 2,
                Name = "Suite com banheiro",
                Value = 25,
            };

            RoomRepository.Setup(x => x.GetRoom(50)).Returns(Task.FromResult(RoomDto.MapToEntity(RoomDTO)));

            var room = new CreateRoomRequest
            {
                Data = RoomDTO
            };

            var response = await manage.GetRoomById(50);

            Assert.Equal(response.Data.Id, RoomDTO.Id);
        }


        [Fact]
        public async Task CreateRoomReturnId50()
        {

           RoomRepository.Setup(x => x.Create(It.IsAny<Room>())).Returns(Task.FromResult(50));

            var RoomDTO = new RoomDto
            {
                Currency = 1,
                InMaintenance = true,
                Level = 2,
                Name = "Suite com banheiro",
                Value = 25,
            };

            var room = new CreateRoomRequest {Data = RoomDTO };

            var response = await manage.CreateRoom(room);

            Assert.Equal(50, response.Data.Id);
        }




        [Theory]
        [InlineData(null,false,20,"Quarto sem banheiro",12,"Currency")]
        [InlineData(1, false, null, "Quarto sem banheiro", 12, "Level")]
        [InlineData(1, false, 20, null, 12, "Name")]
        [InlineData(1, false, 20, "Quarto sem banheiro", null, "Value")]

        public async Task AdicionarRoomNull(int currency,bool maintenance,int level,string name,decimal value,string propriedadeError)
        {
            RoomRepository.Setup(x => x.Create(It.IsAny<Room>())).Returns(Task.FromResult(111));

            var RoomDTO = new RoomDto
            {
                Currency = currency,
                InMaintenance = maintenance,
                Level = level,
                Name = name,
                Value = value,
            };

            var room = new CreateRoomRequest
            {
                Data = RoomDTO
            };

            var response = await manage.CreateRoom(room);
            Assert.False(response.Success);
            Assert.Contains(propriedadeError, response.ListMessages.Select(x => x.ErrorType));
        }





        [Theory]
        [InlineData(1, false, 20, "", 12, "Name")]

        public async Task AdicionarRoomEmpty(int currency, bool maintenance, int level, string name, decimal value, string propriedadeError)
        {
            RoomRepository.Setup(x => x.Create(It.IsAny<Room>())).Returns(Task.FromResult(111));

            var RoomDTO = new RoomDto
            {
                Currency = currency,
                InMaintenance = maintenance,
                Level = level,
                Name = name,
                Value = value,
            };

            var room = new CreateRoomRequest
            {
                Data = RoomDTO
            };

            var response = await manage.CreateRoom(room);
            Assert.False(response.Success);
            Assert.Contains(propriedadeError, response.ListMessages.Select(x => x.ErrorType));
        }


       
        [Theory]
        [InlineData(1, false, 20, "Value")]
        [InlineData(1, false, 20, "Name")]
        public async Task AdicionarRoomSemCampos(int currency, bool maintenance, int level, string propriedadeError)
        {
            RoomRepository.Setup(x => x.Create(It.IsAny<Room>())).Returns(Task.FromResult(111));

            var RoomDTO = new RoomDto
            {
                Currency = currency,
                InMaintenance = maintenance,
                Level = level,

            };

            var room = new CreateRoomRequest
            {
                Data = RoomDTO
            };

            var response = await manage.CreateRoom(room);
            Assert.False(response.Success);
            Assert.Contains(propriedadeError, response.ListMessages.Select(x => x.ErrorType));
        }

    }
}