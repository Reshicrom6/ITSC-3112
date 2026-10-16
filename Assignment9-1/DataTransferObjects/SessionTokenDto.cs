namespace Assignment9_1.DataTransferObjects;

/// <summary>
/// Token, Username, and DisplayName.
/// </summary>
public sealed record SessionTokenDto(string Token, string Username, string DisplayName);

