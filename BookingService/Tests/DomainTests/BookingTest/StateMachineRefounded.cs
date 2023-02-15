
using Domain.Entities;

namespace DomainTests.BookingTest
{
    public class StateMachineRefounded
    {


        //Refounded
        [Fact]
        public void N�oMudarStatusDeRefoundParaPaid()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void N�oMudarStatusDeRefoundParaReopen()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void N�oMudarStatusDeRefoundParaCanceled()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }
    }
}