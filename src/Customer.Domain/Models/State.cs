using Customer.Domain.Models.Common;

namespace Customer.Domain.Models;

public class State : BaseDomain
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ZipCode { get; set; }

    public ICollection<City>? Cities { get; set; }
}
