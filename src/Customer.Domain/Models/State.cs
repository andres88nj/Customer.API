using Customer.Domain.Models.Common;

namespace Customer.Domain.Models;

public class State : BaseDomain
{
    Guid Id { get; set; }
    public string Name { get; set; }
    public string ZipCode { get; set; }
}
