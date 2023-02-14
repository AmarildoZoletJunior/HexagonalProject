
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
        public void TesteN�oMudarStatusDeCreatedParaRefounded()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created);
        }

        [Fact]
        public void TesteN�oMudarStatusDeCreatedParaFinished()
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
        public void TesteN�oMudarStatusDePaidParaCanceled()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }
        [Fact]
        public void TesteN�oMudarStatusDePaidParaReopen()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Paid);
        }



        //Refounded
        [Fact]
        public void TesteN�oMudarStatusDeRefoundParaPaid()
        {
            Booking book = new Booking();

            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void TesteN�oMudarStatusDeRefoundParaReopen()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Refund);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Refounded);
        }

        [Fact]
        public void TesteN�oMudarStatusDeRefoundParaCanceled()
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
        public void TesteN�oMudarStatusDeCanceledParaPaid()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void TesteN�oMudarStatusDeCanceledParaFinished()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Finish);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }

        [Fact]
        public void TesteN�oMudarStatusDeCanceledParaRefound()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Cancel);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Canceled);
        }



        //Finished

        [Fact]
        public void TesteN�oMudarStatusDeFinishedParaRefound()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Refund);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void TesteN�oMudarStatusDeFinishedParaPaid()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Pay);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void TesteN�oMudarStatusDeFinishedParaCanceled()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Cancel);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }

        [Fact]
        public void TesteN�oMudarStatusDeFinishedParaCreate()
        {
            Booking book = new Booking();
            book.ChangeState(Domain.Enums.Action.Pay);
            book.ChangeState(Domain.Enums.Action.Finish);
            book.ChangeState(Domain.Enums.Action.Reopen);
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Finished);
        }
    }
}