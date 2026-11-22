namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Specifies a standard suit for a playing card.
/// </summary>
public enum PlayingCardSuit
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Spades,
    Hearts,
    Diamonds,
    Clubs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
/// Provides extension methods for displaying playing card suits.
/// </summary>
public static class PlayingCardSuitExtensions
{
    private static readonly char[] characters = ['♠', '♥', '♦', '♣'];

    /// <summary>
    /// Returns the character that represents a playing card suit.
    /// </summary>
    /// <param name="suit">The playing card suit to convert to a character.</param>
    /// <returns>The character that represents the specified playing card suit.</returns>
    public static string CardChar(this PlayingCardSuit suit) => characters[(int)suit].ToString();

    /// <summary>
    /// Gets the abbreviated text for the playing card suit.
    /// </summary>
    /// <param name="suit">The playing card suit.</param>
    /// <returns>The first character of the suit name.</returns>
    public static string CardText(this PlayingCardSuit suit) => suit.ToString()[0].ToString();
}
