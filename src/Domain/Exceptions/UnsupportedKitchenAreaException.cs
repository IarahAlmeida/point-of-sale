namespace Domain.Exceptions;

public class UnsupportedKitchenAreaException(string code) : Exception($"Kitchen Area {code} is unsupported")
{
}