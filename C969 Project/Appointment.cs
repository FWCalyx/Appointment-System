// Appointment.cs
// Appointment class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public int userId { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
        public Appointment(int id, int cId, int uId, string title, string desc, string loc, string contact, string type, string url, DateTime start, DateTime end, DateTime createDate, string creator, DateTime updated, string updater)
        {
            appointmentId = id;
            customerId = cId;
            userId = uId;
            Title = title;
            description = desc;
            location = loc;
            Contact = contact;
            Type = type;
            Url = url;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = creator;
            LastUpdate = updated;
            LastUpdateBy = updater;
        }

    }
    // Custom exception handlers
    class InvalidAppointmentTimeException : Exception
    {
        public InvalidAppointmentTimeException() 
            :base(String.Format("Appointments must fall within business hours."))
        {
        }
    }
    class StartAfterEndTimeException : Exception
    {
        public StartAfterEndTimeException()
            : base(String.Format("Appointment start time cannot be later than its end time."))
        {
        }
    }

    class MissingFieldException : Exception
    {
        public MissingFieldException()
            :base(String.Format("Required field cannot be blank."))
        {
        }
    }
    class InvalidAppointmentDateException : Exception
    {
        public InvalidAppointmentDateException()
            : base(String.Format("Appointments cannot take place on the weekends.")) 
        { 
        }
    }
    class InvalidAppointmentOverlap : Exception
    {
        public InvalidAppointmentOverlap(Appointment appt1)
            : base(String.Format($"You already have an appointment with {appt1.Contact} scheduled during this time."))
        { 
        }
        
    }


}
