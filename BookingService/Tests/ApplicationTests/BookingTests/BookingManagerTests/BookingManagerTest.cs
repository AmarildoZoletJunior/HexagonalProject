using AdaptersSQL.Guest;
using API.Controllers;
using Application.Booking;
using Domain.Entities;
using Domain.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace ApplicationTests.BookingTests.BookingManagerTests
{

    public class BookingManagerTest
    {
        public BookingManager BookManager;
        public Mock<IBookingRepository> BookRepository ;
        public Mock<IRoomRepository> RoomRepository;
        public Mock<IGuestRepository> GuestRepository;

        public BookingManagerTest()
        {
            BookRepository = new Mock<IBookingRepository>();
            RoomRepository = new Mock<IRoomRepository>();
            GuestRepository = new Mock<IGuestRepository>();
            BookManager = new BookingManager(BookRepository.Object,GuestRepository.Object, RoomRepository.Object);
        }

        //[Fact]
        //public async Task AdicionarBookingCorreto()
        //{
        //    BookRepository.Setup(x => x.Create(It.IsAny<Booking>())).Returns(Task.FromResult(20));

        //    var response = BookManager.CreateBooking()
        //};

        //[Fact]
        //public async Task ReturnGetRoomById()
        //{
        //    var fakerepo = new Mock<IRoomRepository>();
        //    var RoomDTO = new RoomDto
        //    {
        //        Id = 50,
        //        Currency = 1,
        //        InMaintenance = true,
        //        Level = 2,
        //        Name = "Suite com banheiro",
        //        Value = 25,
        //    };

        //    fakerepo.Setup(x => x.GetRoom(50)).Returns(Task.FromResult(RoomDto.MapToEntity(RoomDTO)));
        //    manage = new Application.Room.RoomManager(fakerepo.Object);

        //    var room = new CreateRoomRequest
        //    {
        //        Data = RoomDTO
        //    };

        //    var response = await manage.GetRoomById(50);

        //    Assert.Equal(response.Data.Id, RoomDTO.Id);
        //}
    }
}