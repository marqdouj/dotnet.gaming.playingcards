namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Represents a playing card with a rank and suit.
/// </summary>
/// <param name="Rank">The rank of the playing card.</param>
/// <param name="Suit">The suit of the playing card.</param>
public record class PlayingCard(PlayingCardRank Rank, PlayingCardSuit Suit)
{
    /// <summary>
    /// Gets the unique key for the playing card.
    /// </summary>
    public string Key { get; } = PlayingCardFactory.GetKey(Rank, Suit);

    /// <summary>
    /// Gets the character representation of the card rank.
    /// </summary>
    public string RankChar => Rank.CardChar();

    /// <summary>
    /// Gets the character representation of the playing card suit.
    /// </summary>
    public string SuitChar => Suit.CardChar();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>The <see cref="Key"/></returns>
    public override string ToString() => Key;
}
