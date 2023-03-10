//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Travel_Pakistan_With_Us.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TrainInformation
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please Select Train.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select Train Route.")]
        public string Route { get; set; }

        [Required(ErrorMessage = "Please Enter Time Duration.")]
        public string TimeDuration { get; set; }

        [Required(ErrorMessage = "Please Select DepartingTime name.")]
        public string DepartingTime { get; set; }

        [Required(ErrorMessage = "Please Enter Ticket Price.")]
        public Nullable<int> TicketPrice { get; set; }
    }
}
