
using Domain.Entities;

namespace DomainTests.BookingTest
{
    public class StateMachineCreated
    {


        //Created

        [Fact]
        public void InstanciarEntidadeIniciarComoCreated()
        {
            Booking book = new Booking();

            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }

        [Fact]
        public void MudarStatusParaPaidQuandoBookingTiverStatusDeCreated()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }

        [Fact]
        public void MudarStatusDeCreatedParaCanceled()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void NãoMudarStatusDeCreatedParaRefounded()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }

        [Fact]
        public void NãoMudarStatusDeCreatedParaFinished()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }
    }
}