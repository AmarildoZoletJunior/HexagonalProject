
using Domain.Entities;

namespace DomainTests.BookingTest
{
    public class StateMachinePaid
    {
   

        //Paid
        [Fact]
        public void MudarStatusDePaidParaRefounded()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }
        [Fact]
        public void MudarStatusDePaidParaFinished()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }
        [Fact]
        public void NãoMudarStatusDePaidParaCanceled()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }
        [Fact]
        public void NãoMudarStatusDePaidParaReopen()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }
    }
}