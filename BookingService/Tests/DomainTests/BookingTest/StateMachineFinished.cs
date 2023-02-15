
using Domain.Entities;

namespace DomainTests.BookingTest
{
    public class StateMachineFinished
    {
        //Finished

        [Fact]
        public void N�oMudarStatusDeFinishedParaRefound()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void N�oMudarStatusDeFinishedParaPaid()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void N�oMudarStatusDeFinishedParaCanceled()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void N�oMudarStatusDeFinishedParaCreate()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }
    }
}