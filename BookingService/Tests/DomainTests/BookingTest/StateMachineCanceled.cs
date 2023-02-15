
using Domain.Entities;

namespace DomainTests.BookingTest
{
    public class StateMachineCanceled
    {
        //Teste padrão
        [Fact]
        public void InstanciarEntidadeIniciarComoCreated()
        {
            Booking book = new Booking();

            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }


        //Canceled

        [Fact]
        public void MudarStatusDeCanceledParaReopen()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }

        [Fact]
        public void NãoMudarStatusDeCanceledParaPaid()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void NãoMudarStatusDeCanceledParaFinished()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void NãoMudarStatusDeCanceledParaRefound()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }
    }
}