using Customer.Domain.Models.Common;

namespace Customer.Domain.Models;

public class City : BaseDomain
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid StateId { get; set; }
    public State State { get; set; }

    //public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}
