namespace Todo_App.Domain.ValueObjects;

public class Colour : ValueObject
{
    static Colour()
    {
    }

    private Colour()
    {
    }

    private Colour(string code)
    {
        Code = code;
    }

    public static Colour From(string code)
    {
        var colour = new Colour { Code = code };

        if (!SupportedColours.Contains(colour))
        {
            throw new UnsupportedColourException(code);
        }

        return colour;
    }

    public static Dictionary<string, string> GetKVPofColours()
    {
        Dictionary<string, string> keyValuePairs = new();

        for (int i = 0; i < ColourNames.Count(); i++)
        {
            keyValuePairs.Add(ColourNames.ElementAt(i), SupportedColours.ElementAt(i).Code);
        }

        return keyValuePairs;
    }


    public static IEnumerable<string> ColourNames
    {
        get
        {
            yield return nameof(White);
            yield return nameof(Red);
            yield return nameof(Orange);
            yield return nameof(Yellow);
            yield return nameof(Green);
            yield return nameof(Blue);
            yield return nameof(Purple);
            yield return nameof(Grey);
        }
    }

    public static Colour White => new("#FFFFFF");

    public static Colour Red => new("#FF5733");

    public static Colour Orange => new("#FFC300");

    public static Colour Yellow => new("#FFFF66");

    public static Colour Green => new("#CCFF99 ");

    public static Colour Blue => new("#6666FF");

    public static Colour Purple => new("#9966CC");

    public static Colour Grey => new("#999999");

    public string Code { get; private set; } = "#000000";

    public static implicit operator string(Colour colour)
    {
        return colour.ToString();
    }

    public static explicit operator Colour(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code;
    }

    protected static IEnumerable<Colour> SupportedColours
    {
        get
        {
            yield return White;
            yield return Red;
            yield return Orange;
            yield return Yellow;
            yield return Green;
            yield return Blue;
            yield return Purple;
            yield return Grey;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
