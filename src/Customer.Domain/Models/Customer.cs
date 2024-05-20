﻿using Customer.Domain.Models.Common;

namespace Customer.Domain.Models;

public class Customer : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get;  set; }
    public string DNI { get;  set; }
    public string Address { get;  set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}
