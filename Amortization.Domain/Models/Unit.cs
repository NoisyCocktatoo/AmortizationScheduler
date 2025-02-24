﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Amortization.Domain.Models;

public partial class Unit
{
    public long UnitId { get; set; }

    public long? BuyerId { get; set; }

    public long? ProjectId { get; set; }

    public string? CondoUnit { get; set; }

    public long? CreateId { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? LastUpdateId { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual Buyer? Buyer { get; set; }

    public virtual Project? Project { get; set; }
}