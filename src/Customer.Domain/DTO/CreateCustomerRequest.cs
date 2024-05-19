using Customer.Domain.Models;

namespace Customer.Domain.DTO;

public class CreateCustomerRequest
{
    public string Name { get; set; }
    public string DNI { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public City City { get; set; }
}
