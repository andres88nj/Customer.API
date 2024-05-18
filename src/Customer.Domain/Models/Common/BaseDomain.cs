namespace Customer.Domain.Models.Common;

public class BaseDomain
{
    private string? _updatedBy;

    private string? _createdBy;

    private DateTime _createdAt;

    private DateTime _updatedAt;


    public DateTime CreatedAt
    {
        get
        {
            return _createdAt;
        }
        set
        {
            _createdAt = value;
        }
    }

    public DateTime UpdatedAt
    {
        get
        {
            return _updatedAt;
        }
        set
        {
            _updatedAt = value;
        }
    }

    public string UpdatedBy
    {
        get
        {
            return _updatedBy;
        }
        set
        {
            _updatedBy = value;
        }
    }

    public string CreatedBy
    {
        get
        {
            return _createdBy;
        }
        set
        {
            _createdBy = value;
        }
    }
}