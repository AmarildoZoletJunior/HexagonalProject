
using Domain.Entities;

namespace DomainTests.BookingTest
{
    public class StateMachineRefounded
    {


        //Refounded
        [Fact]
        public void NãoMudarStatusDeRefoundParaPaid()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void NãoMudarStatusDeRefoundParaReopen()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void NãoMudarStatusDeRefoundParaCanceled()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }
    }
}