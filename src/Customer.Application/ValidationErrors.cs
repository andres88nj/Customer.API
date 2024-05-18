namespace Customer.Domain.Validations;

public record ValidationError(string Code, string Message);


public static class ValidationErrors
{
    //E:Error
    //C:Action -> Create
    //C:Controller -> Customer
    //#:Number
    public static readonly ValidationError ECC001 = new ValidationError("ECC001", "Name is null or exceeds the maximum length.");
    public static readonly ValidationError ECC002 = new ValidationError("ECC002", "DNI is null or exceeds the maximum length.");
    public static readonly ValidationError ECC003 = new ValidationError("ECC003", "Address is null or exceeds the maximum length.");
    public static readonly ValidationError ECC004 = new ValidationError("ECC004", "Phone is null or exceeds the maximum length.");
    public static readonly ValidationError ECC005 = new ValidationError("ECC005", "Mobile is null or exceeds the maximum length.");
    public static readonly ValidationError ECC006 = new ValidationError("ECC006", "Email is null or exceeds the maximum length.");
    public static readonly ValidationError ECC007 = new ValidationError("ECC007", "City is null or exceeds the maximum length.");
    public static readonly ValidationError ECC008 = new ValidationError("ECC008", "Phone is invalid.");
    public static readonly ValidationError ECC009 = new ValidationError("ECC009", "Mobile is invalid.");

    public static readonly ValidationError EUC001 = new ValidationError("EUC001", "Name is null or exceeds the maximum length.");
    public static readonly ValidationError EUC002 = new ValidationError("EUC002", "DNI is null or exceeds the maximum length.");
    public static readonly ValidationError EUC003 = new ValidationError("EUC003", "Address is null or exceeds the maximum length.");
    public static readonly ValidationError EUC004 = new ValidationError("EUC004", "Phone is null or exceeds the maximum length.");
    public static readonly ValidationError EUC005 = new ValidationError("EUC005", "Mobile is null or exceeds the maximum length.");
    public static readonly ValidationError EUC006 = new ValidationError("EUC006", "Email is null or exceeds the maximum length.");
    public static readonly ValidationError EUC007 = new ValidationError("EUC007", "City is null or exceeds the maximum length.");
    public static readonly ValidationError EUC008 = new ValidationError("EUC008", "Phone is invalid.");
    public static readonly ValidationError EUC009 = new ValidationError("EUC009", "Mobile is invalid.");

    public static readonly ValidationError EDC001 = new ValidationError("EGC001", "User already exists in DB");
}
