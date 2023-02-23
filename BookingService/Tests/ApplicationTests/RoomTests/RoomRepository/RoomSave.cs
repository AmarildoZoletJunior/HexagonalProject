using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests.RoomTests.RoomRepository
{
    public class RoomSave
    {
        public Mock<IRoomRepository> RoomRepository;
        public RoomSave()
        {
            RoomRepository = new Mock<IRoomRepository>();
        }

        [Fact]
        public async Task RetornarIdDepoisDeSalvar()
        {
            var room = new Room
            {
                PriceRoom = new Domain.ValueObjects.Price
                {
                    Currency = (AcceptedCurrencies)1,
                    Value = 20
                },
                InMaintenance = true,
                Level = 2,
                Name = "Suite com banheiro",
            };
            RoomRepository.Setup(x => x.Create(room)).ReturnsAsync(11);

            var resultado = await RoomRepository.Object.Create(room);

            Assert.Equal(11, resultado);
        }
    }
}
