using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects;

public class KitchenArea : ValueObject
{
    static KitchenArea()
    {
    }

    private KitchenArea()
    {
    }

    private KitchenArea(string code)
    {
        Code = code;
    }

    public static KitchenArea Desert => new("Desert");
    public static KitchenArea Drink => new("Drink");
    public static KitchenArea Fries => new("Fries");
    public static KitchenArea Grill => new("Grill");
    public static KitchenArea Salad => new("Salad");
    public string Code { get; private set; } = "Undefined";

    protected static IEnumerable<KitchenArea> SupportedKitchenAreas
    {
        get
        {
            yield return Desert;
            yield return Drink;
            yield return Fries;
            yield return Grill;
            yield return Salad;
        }
    }

    public static explicit operator KitchenArea(string code)
    {
        return From(code);
    }

    public static KitchenArea From(string code)
    {
        var kitchenArea = new KitchenArea { Code = code };

        if (!SupportedKitchenAreas.Contains(kitchenArea))
        {
            throw new UnsupportedKitchenAreaException(code);
        }

        return kitchenArea;
    }

    public static implicit operator string(KitchenArea kitchenArea)
    {
        return kitchenArea.ToString();
    }

    public override string ToString()
    {
        return Code;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}