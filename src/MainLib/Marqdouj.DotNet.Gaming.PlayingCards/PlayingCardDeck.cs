namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Represents a deck of playing cards that supports shuffling, sorting, dealing, peeking, and resetting.
/// </summary>
/// <remarks>The deck maintains its cards in insertion order unless shuffled or sorted.</remarks>
public class PlayingCardDeck
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayingCardDeck"/> class.
    /// </summary>
    /// <param name="cards">The cards to add to the deck. If <see langword="null"/>, a standard deck is used.</param>
    public PlayingCardDeck(IEnumerable<PlayingCard>? cards = null)
    {
        cards ??= PlayingCardFactory.GetCards();
        _cards.AddRange(cards);
    }

    private readonly Random _random = new();

    private readonly List<PlayingCard> _cards = [];

    /// <summary>
    /// Gets the playing cards in the deck.
    /// </summary>
    public IReadOnlyList<PlayingCard> Cards => _cards;

    /// <summary>
    /// Gets the playing card that matches the specified key.
    /// </summary>
    /// <param name="key">The key of the playing card to retrieve.</param>
    /// <returns>The matching playing card, or <see langword="null"/> if no card matches.</returns>
    public PlayingCard? GetCard(string key) => _cards.FirstOrDefault(e => e.Key == key);

    /// <summary>
    /// Finds a playing card with the specified rank and suit.
    /// </summary>
    /// <param name="rank">The rank of the card to find.</param>
    /// <param name="suit">The suit of the card to find.</param>
    /// <returns>The matching playing card, or <see langword="null"/> if no match exists.</returns>
    public PlayingCard? GetCard(PlayingCardRank rank, PlayingCardSuit suit) =>
        _cards.FirstOrDefault(e => e.Rank == rank && e.Suit == suit);

    /// <summary>
    /// Determines whether the deck contains a card with the specified key.
    /// </summary>
    /// <param name="key">The key of the card to find.</param>
    /// <returns><see langword="true"/> if a card with the specified key exists; otherwise, <see langword="false"/>.</returns>
    public bool HasCard(string key) => _cards.Any(e => e.Key == key);

    /// <summary>
    /// Determines whether the deck contains a card with the specified rank and suit.
    /// </summary>
    /// <param name="rank">The rank of the card to find.</param>
    /// <param name="suit">The suit of the card to find.</param>
    /// <returns><see langword="true"/> if a matching card exists; otherwise, <see langword="false"/>.</returns>
    public bool HasCard(PlayingCardRank rank, PlayingCardSuit suit) =>
        _cards.Any(e => e.Rank == rank && e.Suit == suit);

    /// <summary>
    /// Removes and returns the card at the specified index.
    /// </summary>
    /// <param name="index">The zero-based position of the card to deal.</param>
    /// <returns>The card removed from the deck.</returns>
    public PlayingCard Deal(int index)
    {
        var card = _cards.ElementAt(index);
        _cards.Remove(card);
        return card;
    }

    /// <summary>
    /// Returns the playing card at the specified index without removing it from the deck.
    /// </summary>
    /// <param name="index">The zero-based index of the card to retrieve.</param>
    /// <returns>The playing card at the specified index; otherwise, <see langword="null"/> if the index is outside the deck.</returns>
    public PlayingCard? Peek(int index) => _cards.ElementAtOrDefault(index);

    /// <summary>
    /// Sorts the cards in the deck using the specified comparer.
    /// </summary>
    /// <param name="comparer">The comparer used to determine the sort order. If null, the default playing card comparer is used.</param>
    public void Sort(PlayingCardComparer? comparer = null)
    {
        var oldCards = _cards.ToList();
        var cmp = comparer ?? new PlayingCardComparer();

        oldCards.Sort(cmp);
        UpdateCards(oldCards);
    }

    /// <summary>
    /// Resets the deck to a complete set of playing cards.
    /// </summary>
    public void Reset() => UpdateCards(PlayingCardFactory.GetCards());

    /// <summary>
    /// Randomizes the order of the cards in the deck.
    /// </summary>
    public void Shuffle()
    {
        var newCards = new List<PlayingCard>();
        var oldCards = _cards.ToList();

        while (oldCards.Count > 0)
        {
            var cardToMove = _random.Next(oldCards.Count);
            newCards.Add(oldCards[cardToMove]);
            oldCards.RemoveAt(cardToMove);
        }

        UpdateCards(newCards);
    }

    private void UpdateCards(IEnumerable<PlayingCard> cards)
    {
        _cards.Clear();
        _cards.AddRange(cards);
    }
}
