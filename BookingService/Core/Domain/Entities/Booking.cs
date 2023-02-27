using Domain.Enums;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private Status Status { get; set; }

        public Status CurrentStatus
        {
            get { return this.Status; }
        }
        public void ChangeState(Action action)
        {
            this.Status = (this.Status, action) switch
            {
                (Status.Created, Action.Pay) => Status.Paid,
                (Status.Created, Action.Cancel) => Status.Canceled,
                (Status.Paid, Action.Finish) => Status.Finished,
                (Status.Paid, Action.Refund) => Status.Refounded,
                (Status.Canceled, Action.Reopen) => Status.Created,
                _ => this.Status
            };
        }
        public Booking()
        {
            this.Status = Status.Created;
            this.PlacedAt = DateTime.UtcNow;
        }

        public async Task SaveAsync(IBookingRepository repository)
        {
            this.Id = await repository.Create(this);
        }
        public async Task<Room> ValidateRoom(IRoomRepository repository,int idRoom)
        {
            var getRoom = await repository.GetRoom(idRoom);
            return getRoom;
        }

        public async Task<Guest> ValidateGuest(IGuestRepository repository, int idGuest)
        {
            var getGuest = await repository.GetGuest(idGuest);
            return getGuest;
        }
        public async Task<List<string>> Validate(IRoomRepository roomRepository,int idRoom, IGuestRepository guestRepository, int idGuest)
        {
            List<string> lista = new List<string>();
            var guestValidate = await ValidateGuest(guestRepository,idGuest);
            if(guestValidate == null)  lista.Add("Este guest é nulo");

            var roomValidate = await ValidateRoom(roomRepository, idRoom);
            if (roomValidate == null)
            {
                lista.Add("Este Room é nulo");
            }
            else
            {
               if (!roomValidate.IsAvailable) lista.Add("Este room ja está sendo negociado.");
            }

            return lista;
        }
    }
}
