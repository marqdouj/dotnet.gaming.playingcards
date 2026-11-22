namespace Marqdouj.DotNet.Gaming.PlayingCards;

/// <summary>
/// Specifies the ordering strategy used to sort playing cards.
/// </summary>
/// <remarks>Sorting can prioritize suit, value, or both.</remarks>
public enum PlayingCardSort
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    SuitThenValue,
    ValueThenSuit,
    ValueOnly,
    SuitOnly
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
