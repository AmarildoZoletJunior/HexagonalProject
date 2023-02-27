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
using FluentValidation.Results;
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
            var bookingMap = BookingDto.MapToEntity(booking.Data);
            BookingValidator validator = new BookingValidator();
            var validResponse = validator.Validate(booking.Data);

            var resultado = await bookingMap.Validate(roomRepository, booking.Data.RoomId, guestRepository, booking.Data.GuestId);
            if (resultado.Count > 0)
            {
                resultado.ForEach(x => validResponse.Errors.Add(new ValidationFailure { ErrorMessage = $"{x}", PropertyName = "Error Room or Guest"}));
            };

            if (!validResponse.IsValid || resultado.Count > 0)
            {
                return new BookingResponse
                {
                     Message = "Ocorreram erros de validações",
                    Success = false,
                    ListErrors = validResponse.Errors.Select(x => new { x.PropertyName, x.ErrorMessage })
                     };
                };

            await bookingMap.SaveAsync(bookRepository);

            return new BookingResponse
            {
                Success = true,
                Data = BookingDto.MapToDto(bookingMap)
            };
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
