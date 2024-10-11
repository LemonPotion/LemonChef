namespace Domain.Validations.Primitives;

public abstract class ExceptionMessages
{
    public static readonly Func<string, string> NullException = param => $"{param} is null";
    public static readonly Func<string, string> EmptyException = param => $"{param} is empty";
    public static readonly Func<string, string> OldDateException = param => $"{param} Date is too old";
    public static readonly Func<string, string> TooLowNumber = param => $"{param} is too low number";
    public static readonly Func<string, string> TooHighNumber = param => $"{param} is too high number";
    public static readonly Func<string, string> FutureDateException = param => $"{param} Date is future";

    public static readonly Func<string, string> InvalidTelegramNameFormat =
        param => $"{param} Telegram nickname is incorrect format";

    public static readonly Func<string, string> InvalidPhoneFormat = param => $"{param} Phone number invalid format";
    public static readonly Func<string, string> InvalidFormat = param => $"{param} is invalid format";
    public static readonly Func<string, string> DefaultEnum = param => $"Enum {param} can't be default";
    public static readonly Func<string, string> InvalidEnumValue = param => $"{param} Invalid enum value";
}