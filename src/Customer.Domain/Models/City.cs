using Customer.Domain.Models.Common;

namespace Customer.Domain.Models;

public class City : BaseDomain
{
    Guid Id { get; set; }
    public string Name { get; set; }
    public State StateId { get; set; }
}
