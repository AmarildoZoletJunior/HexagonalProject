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

        //Tag para testes com um único parâmetro
        [Fact]
        public async Task CreateRoomReturnId50()
        {
           /* Configuração do metodo Create no Mock feito do IRoomRepository.
            * No parâmetro do método Create passamos um comando para ele aceitar qualquer classe que seja Room.
            * No método Returns podemos simular ele retornando um valor para o método Create, colocamos o valor 50
            */
           RoomRepository.Setup(x => x.Create(It.IsAny<Room>())).Returns(Task.FromResult(50));

            var RoomDTO = new RoomDto
            {
                Currency = 1,
                InMaintenance = false,
                Level = 2,
                Name = "Quarto com banheiro",
                Value = 109,
            };

            var room = new CreateRoomRequest {Data = RoomDTO };

            //Aqui estamos chamando o método do RoomManager que faz todas as validações e caso esteja ok retorna um DTO
            var response = await manage.CreateRoom(room);

            //Pegamos a resposta do método e vamos iniciar as verificações.

            //Aqui estamos verificando se o response não veio nulo.
            Assert.NotNull(response);

            //Aqui estamos verificando se uma propriedade do nosso DTO veio como true para requisição 200.
            Assert.True(response.Success);

            //Aqui estamos usando novamente o Equal para verificar se o parâmetro 2 condiz com o parâmetro 1
            Assert.Equal(50, response.Data.Id);
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
        public async Task ReturnErrorGetRoomById()
        {
            var RoomDTO = new RoomDto
            {
                Id = 20,
                Currency = 2,
                InMaintenance = false,
                Level = 2,
                Name = "Quarto com banheiro",
                Value = 120,
            };

            //Neste teste vamos retornar no método GetRoom uma classe com Id 20.
            RoomRepository.Setup(x => x.GetRoom(20)).Returns(Task.FromResult(RoomDto.MapToEntity(RoomDTO)));

            //Porém nossa pesquisa no Manager será algum registro no banco com o Id 49, ele deve retornar um erro
            var response = await manage.GetRoomById(49);

            //Verificando na classe de response se a propriedade Success veio como false
            Assert.False(response.Success);
            //Verificando na classe de response se na propriedade Message me retornou esta mensagem
            Assert.Equal("Não foi possivel encontrar esta room", response.Message);
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