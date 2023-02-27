using Application.Booking.DTOs;
using Application.Booking.Ports;
using Application.Booking.Request;
using Application.Booking.Response;
using Application.Booking.Validators;
using Application.Errors;
using Application.Payment.DTOs;
using Application.Payment.PaymentResponse;
using Application.Payment.Ports;
using Domain.Ports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository bookRepository;
        private IGuestRepository guestRepository;
        private IRoomRepository roomRepository;
        private IPaymentProcessorFactory processor;

        public BookingManager(IPaymentProcessorFactory paymentProcessor, IBookingRepository bookRepository, IGuestRepository guestRepository, IRoomRepository roomRepository)
        {
            this.bookRepository = bookRepository;
            this.guestRepository = guestRepository;
            this.roomRepository = roomRepository;
            processor = paymentProcessor;
        }

        public async Task<BookingResponse> CreateBooking(CreateBookingRequest booking)
        {

            var lista = new List<ErrorResponse>();
            var bookingMap = BookingDto.MapToEntity(booking.Data);

            var resultValidateGuest = await bookingMap.ValidateGuest(guestRepository);
            if (!resultValidateGuest)
            {
                lista.Add(new ErrorResponse { ErrorMessages = "O Guest passado não se encontra no banco de dados", ErrorType = "NotFoundGuest" });
            }


            var resultValidateRoom = await bookingMap.ValidateRoom(roomRepository);
            if (resultValidateRoom != "")
            {
                lista.Add(new ErrorResponse { ErrorMessages = resultValidateRoom, ErrorType = "RoomError" });
            }

            BookingValidator validator = new BookingValidator();
            var validResponse = validator.Validate(booking.Data);

            if (!validResponse.IsValid)
            {
                foreach (var erro in validResponse.Errors)
                {
                    lista.Add(new ErrorResponse
                    {
                        ErrorMessages = erro.ErrorMessage,
                        ErrorType = erro.PropertyName
                    });
                };
            }


            if (lista.Any())
            {
                return new Application.Booking.Response.BookingResponse
                {
                    Success = false,
                    ListMessages = lista
                };
            }


            await bookingMap.SaveAsync(bookRepository);

            return new Application.Booking.Response.BookingResponse
            {
                Success = true,
                Data = BookingDto.MapToDto(bookingMap)
            };


        }

        public Task<BookingDto> GetBooking(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ResponsePayment> PayForBooking(PaymentRequestDto dto)
        {
            var paymentProcessor = processor.GetPaymentProcessor(dto.SelectedProvider);
            if(paymentProcessor == null)
            {
                return new ResponsePayment
                {
                    Success = false,
                    Message = "O provider escolhido não existe."
                };
            }
             var response = await paymentProcessor.CapturePayment(dto.PaymentIntention);

            if (response.Success)
            {
                return new ResponsePayment
                {
                    Success = true,
                    Data = response.Data
                };
            }
            return response;
        }
    }
}
