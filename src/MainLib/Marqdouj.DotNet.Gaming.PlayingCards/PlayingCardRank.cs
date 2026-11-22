namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Specifies the rank of a playing card.
/// </summary>
/// <remarks>The numeric values represent the relative rank of each card.</remarks>
public enum PlayingCardRank
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Ace = 14,
    King = 13,
    Queen = 12,
    Jack = 11,
    Ten = 10,
    Nine = 9,
    Eight = 8,
    Seven = 7,
    Six = 6,
    Five = 5,
    Four = 4,
    Three = 3,
    Two = 2,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
/// Provides extension methods for <see cref="PlayingCardRank" /> values.
/// </summary>
public static class PlayingCardRankExtensions
{
    /// <summary>
    /// Gets the character used to represent a playing card rank.
    /// </summary>
    /// <param name="rank">The playing card rank to represent.</param>
    /// <returns>The numeric rank for ranks 2 through 10, or the first letter of the rank name for Ace, Jack, Queen, and King.</returns>
    public static string CardChar(this PlayingCardRank rank)
    {
        int rk = (int)rank;
        string rtn = rk.ToString();

        switch (rk)
        {
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                // do nothing - return default rank int (2 - 10)
                break;
            default:
                // return the first letter of the rank (A, K, Q, J)
                rtn = rank.ToString().First().ToString();
                break;
        }

        return rtn;
    }
}
