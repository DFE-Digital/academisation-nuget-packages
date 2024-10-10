namespace Dfe.Academisation.CorrelationIdMiddleware;
/// <summary>
/// The keys used by the correlation id middleware.
/// </summary>
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs instead.")]
#pragma warning restore S1133
public class Keys
{
    /// <summary>
    /// The header key use to detect incoming correlation ids, and to send them in responses.
    /// Use this key if you are making subsequent requests so that correlation flows between services
    /// </summary>
    public const string HeaderKey = "x-correlationId";
}
