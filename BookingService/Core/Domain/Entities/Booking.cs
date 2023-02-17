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
        public Booking()
        {
            this.Status = Status.Created;
            this.PlacedAt = DateTime.UtcNow;
        }
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

        public async Task SaveAsync(IBookingRepository repository)
        {
            this.Id = await repository.Create(this);
            
        }

        public async Task<bool> ValidateGuest(IGuestRepository repository)
        {
            this.Guest = await repository.GetGuest(this.Guest.Id);    
            if (this.Guest != null) return true;
            return false;
        }
        public async Task<string> ValidateRoom(IRoomRepository repository)
        {
            this.Room = await repository.GetRoom(this.Room.Id);

            if (this.Room == null) return "Este Room não existe";

            if (!this.Room.IsAvailable) return "Este Room ja esta sendo negociado";
 
            return "";
        }
    }
}
