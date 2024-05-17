﻿using Customer.Domain.Models.Common;

namespace Customer.Domain.DTO;

public class CreateCustomerRequest : BaseDomain
{
    public string Name { get; set; }
    public string DNI { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}
