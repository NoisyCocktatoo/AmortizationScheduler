﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace Amortization.Domain.Models
{
    public partial class spAmortizationScheduleResult
    {
        public long? LoanId { get; set; }
        public long ScheduleId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? Principal { get; set; }
        public double? Interest { get; set; }
        public double? Total { get; set; }
        public double? Balance { get; set; }
        public int? No_of_Days { get; set; }
    }
}
