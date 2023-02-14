
using Domain.Entities;

namespace DomainTests.Booking
{
    public class UnitTest1
    {
        [Fact]
        public void TestarInstanciarEntidadeIniciarComoCreated()
        {
            Booking book = new Booking();

            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }


        //Created

        [Fact]
        public void TesteMudarStatusParaPaidQuandoBookingTiverStatusDeCreated()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }

        [Fact]
        public void TesteMudarStatusDeCreatedParaCanceled()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void TesteNãoMudarStatusDeCreatedParaRefounded()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }

        [Fact]
        public void TesteNãoMudarStatusDeCreatedParaFinished()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }





        //Paid
        [Fact]
        public void TesteMudarStatusDePaidParaRefounded()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }
        [Fact]
        public void TesteMudarStatusDePaidParaFinished()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }
        [Fact]
        public void TesteNãoMudarStatusDePaidParaCanceled()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }
        [Fact]
        public void TesteNãoMudarStatusDePaidParaReopen()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }



        //Refounded
        [Fact]
        public void TesteNãoMudarStatusDeRefoundParaPaid()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void TesteNãoMudarStatusDeRefoundParaReopen()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void TesteNãoMudarStatusDeRefoundParaCanceled()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }



        //Canceled

        [Fact]
        public void TesteMudarStatusDeCanceledParaReopen()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }

        [Fact]
        public void TesteNãoMudarStatusDeCanceledParaPaid()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void TesteNãoMudarStatusDeCanceledParaFinished()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void TesteNãoMudarStatusDeCanceledParaRefound()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }



        //Finished

        [Fact]
        public void TesteNãoMudarStatusDeFinishedParaRefound()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void TesteNãoMudarStatusDeFinishedParaPaid()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void TesteNãoMudarStatusDeFinishedParaCanceled()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void TesteNãoMudarStatusDeFinishedParaCreate()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }
    }
}