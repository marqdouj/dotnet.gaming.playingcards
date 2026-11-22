namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Provides access to and comparison methods for playing cards.
/// </summary>
/// <remarks>Creates and caches the standard set of playing cards for lookup and collection operations.</remarks>
public static class PlayingCardFactory
{
    private static readonly IReadOnlyDictionary<string, PlayingCard> _cards = CreateCards();

    private static Dictionary<string, PlayingCard> CreateCards()
    {
        var cards = new Dictionary<string, PlayingCard>();
        
        foreach (var rank in Enum.GetValues<PlayingCardRank>())
        {
            foreach (var suit in Enum.GetValues<PlayingCardSuit>())
            {
                var card = new PlayingCard (rank, suit );
                cards.Add(card.Key, card);
            }
        }

        return cards;
    }

    /// <summary>
    /// Gets all playing cards in descending suit and rank order.
    /// </summary>
    /// <returns>A list containing all playing cards.</returns>
    public static List<PlayingCard> GetCards() =>
        [.. _cards.Values.OrderByDescending(e => e.Suit).ThenByDescending(e => e.Rank)];

    /// <summary>
    /// Gets the playing card with the specified rank and suit.
    /// </summary>
    /// <param name="rank">The rank of the playing card.</param>
    /// <param name="suit">The suit of the playing card.</param>
    /// <returns>The playing card matching the specified rank and suit.</returns>
    public static PlayingCard GetCard(PlayingCardRank rank, PlayingCardSuit suit) =>
        _cards.First(e => e.Key == GetKey(rank, suit)).Value;

    /// <summary>
    /// Gets the playing card with the specified rank and suit.
    /// </summary>
    /// <param name="cards">The cards to search.</param>
    /// <param name="rank">The rank of the card.</param>
    /// <param name="suit">The suit of the card.</param>
    /// <returns>The playing card that matches the specified rank and suit.</returns>
    public static PlayingCard GetCard(this IEnumerable<PlayingCard> cards, PlayingCardRank rank, PlayingCardSuit suit) =>
        cards.First(e => e.Key == GetKey(rank, suit));

    /// <summary>
    /// Filters the cards by suit and orders them by descending rank.
    /// </summary>
    /// <param name="cards">The cards to filter.</param>
    /// <param name="suit">The suit to match.</param>
    /// <returns>The matching cards ordered from highest to lowest rank.</returns>
    public static IEnumerable<PlayingCard> GetSuit(this IEnumerable<PlayingCard> cards, PlayingCardSuit suit) 
        => [.. cards.Where(e => e.Suit == suit).OrderByDescending(e => e.Rank)];

    /// <summary>
    /// Gets the key representing a playing card rank and suit.
    /// </summary>
    /// <param name="rank">The playing card rank.</param>
    /// <param name="suit">The playing card suit.</param>
    /// <returns>A string composed of the rank character and suit character.</returns>
    public static string GetKey(PlayingCardRank rank, PlayingCardSuit suit) =>
        $"{rank.CardChar()}{suit.CardChar()}";

    /// <summary>
    /// Determines whether two playing cards have the same key.
    /// </summary>
    /// <param name="cardA">The first playing card.</param>
    /// <param name="cardB">The second playing card.</param>
    /// <returns>true if both cards have the same key; otherwise, false.</returns>
    public static bool IsSameCard(this PlayingCard cardA, PlayingCard cardB) 
        => (cardA.Key == cardB.Key);

    /// <summary>
    /// Determines whether two playing cards have the same rank.
    /// </summary>
    /// <param name="cardA">The first playing card.</param>
    /// <param name="cardB">The second playing card.</param>
    /// <returns><see langword="true"/> if both cards have the same rank; otherwise, <see langword="false"/>.</returns>
    public static bool IsSameRank(this PlayingCard cardA, PlayingCard cardB)
    => (cardA.Rank == cardB.Rank);

    /// <summary>
    /// Determines whether two playing cards have the same suit.
    /// </summary>
    /// <param name="cardA">The first playing card.</param>
    /// <param name="cardB">The second playing card.</param>
    /// <returns><see langword="true"/> if both cards have the same suit; otherwise, <see langword="false"/>.</returns>
    public static bool IsSameSuit(this PlayingCard cardA, PlayingCard cardB)
    => (cardA.Suit == cardB.Suit);
}
