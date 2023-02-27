
using Domain.Entities;
using Domain.Enums;
using System;
using Action = Domain.Enums.Action;

namespace DomainTests.BookingTest
{
    public class StateMachineCreated
    {


        //Created

        
        [Fact] //Tag usada quando queremos fazer apenas um teste

        public void statusCreatedWhenInstantiatingClass()
        {
            //Instanciação da classe
            Booking book = new Booking();

            //Utilizando Assert.Equal para comparar dois resultados
            Assert.Equal(book.CurrentStatus, Domain.Enums.Status.Created); //Neste teste esperamos que a classe booking ja inicie com status Created
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

        //Tag Theory que permite criar diversas entrada de parâmetro de teste.
        [Theory]

        //Parâmetros de entrada para mudança de Action e de Status
        [InlineData(Action.Reopen,Status.Created)]  
        [InlineData(Action.Refund, Status.Created)]
        [InlineData(Action.Finish, Status.Created)]

        public void DontChangeCanceledStatus(Action desiredAction, Status expectedStatus)
        {
            //Instanciação da classe
            Booking book = new Booking();

            //Mudança de Status conforme passado no parâmetro
            book.ChangeState(desiredAction);


            //Assert.Equal compara dois parâmetros sendo o primeiro o esperado e o segundo o resultado atual
            Assert.Equal(book.CurrentStatus, expectedStatus); //Em todos os testes se espera que o status de Criado não seja alterado
        }
    }
}