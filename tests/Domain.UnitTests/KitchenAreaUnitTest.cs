using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.UnitTests;

public class KitchenAreaUnitTest
{
    [Fact]
    public void ThrowsUnsupportedKitchenAreaException()
    {
        Assert.Throws<UnsupportedKitchenAreaException>(() => KitchenArea.From("Test"));
    }
}