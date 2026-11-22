namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Compares playing cards according to the configured sort order and ace value.
/// </summary>
/// <remarks>The <see cref="PlayingCardSort"/> and ace settings determine the comparison order and how aces
/// rank.</remarks>
public sealed class PlayingCardComparer : IComparer<PlayingCard>
{
    /// <summary>
    /// Compares two playing cards according to the configured sort order.
    /// </summary>
    /// <param name="cardA">The first playing card.</param>
    /// <param name="cardB">The second playing card.</param>
    /// <returns>A negative value when cardA precedes cardB, zero when they are equal, or a positive value when cardA follows
    /// cardB.</returns>
    public int Compare(PlayingCard? cardA, PlayingCard? cardB)
    {
        ArgumentNullException.ThrowIfNull(cardA);
        ArgumentNullException.ThrowIfNull(cardB);

        int value = 0;
        
        switch (SortBy)
        {
            case PlayingCardSort.SuitThenValue:
                value = CompareSuit(cardA, cardB);

                if (value == 0)
                    value = CompareValue(cardA, cardB);

                break;
            case PlayingCardSort.ValueThenSuit:
                value = CompareValue(cardA, cardB);

                if (value == 0)
                    value = CompareSuit(cardA, cardB);

                break;
            case PlayingCardSort.ValueOnly:
                value = CompareValue(cardA, cardB);

                break;
            case PlayingCardSort.SuitOnly:
                value = CompareSuit(cardA, cardB);

                break;
        }

        return value;
    }

    private static int CompareSuit(PlayingCard cardA, PlayingCard cardB)
    {
        if (cardA.Suit > cardB.Suit)
            return 1;

        if (cardA.Suit < cardB.Suit)
            return -1;

        return 0;
    }

    private int CompareValue(PlayingCard cardA, PlayingCard cardB)
    {

        int cardAVal = (int)cardA.Rank;
        int cardBVal = (int)cardB.Rank;

        // adjust values for an Ace if high
        if (AceIsHigh)
        {
            if (cardAVal == 1)
                cardAVal = 14;

            if (cardBVal == 1)
                cardBVal = 14;
        }

        // compare values
        if (cardAVal > cardBVal)
            return 1;

        if (cardAVal < cardBVal)
            return -1;

        return 0;
    }

    /// <summary>
    /// Gets or sets the property used to sort playing cards.
    /// </summary>
    public PlayingCardSort SortBy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether an ace has the highest rank.
    /// </summary>
    public bool AceIsHigh { get; set; } = true;
}
