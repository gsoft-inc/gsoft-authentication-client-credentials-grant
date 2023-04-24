﻿namespace GSoft.Extensions.Http.Authentication.ClientCredentialsGrant;

/// <summary>
/// Represents the configuration options for OAuth 2.0 Client Credentials Grant flow.
/// </summary>
public sealed class ClientCredentialsOptions
{
    private static readonly char[] SpaceCharacterArray = { ' ' };

    /// <summary>
    /// Base URL of the OAuth 2.0 server responsible for issuing access tokens.
    /// </summary>
    public string Authority { get; set; } = string.Empty;

    /// <summary>
    /// Unique identifier assigned to the client application by the Authority.
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Confidential secret generated by the Authority and shared with the client application.
    /// </summary>
    public string ClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// Represents the permissions or access levels requested by the client application from the Authority.
    /// </summary>
    public string[] Scopes { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Represents the permissions or access levels requested by the client application from the Authority.
    /// </summary>
    public string Scope
    {
        get => this.Scopes == null ? string.Empty : string.Join(" ", this.Scopes);
        set => this.Scopes = value.Split(SpaceCharacterArray, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// A time buffer during which an access token is deemed expired prior to its actual expiration time.
    /// </summary>
    public TimeSpan CacheLifetimeBuffer { get; set; } = TimeSpan.FromSeconds(60);

    /// <summary>
    /// Internal cache key computed by options post-configuration
    /// </summary>
    internal string CacheKey { get; set; } = string.Empty;
}