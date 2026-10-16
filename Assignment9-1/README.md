# Assignment 9-1 Reflection

Replace each placeholder with two or three complete sentences. Use examples
from your finished code.

## 1. Data Transfer Object

In your own words, what is a DTO? Explain why `AuthService` returns a
`SessionTokenDto` instead of returning the entire `StaffAccount`. Include the
three values carried by the DTO.

A DTO is an object created with the purpose to transfer values from one object to another. The reason `AuthService`
returns a `SessionTokenDTO` instead of an entire `StaffAccount` is so that only the necessary data from `StaffAccount`
is carried through the authentication without also passing through the functionality of `StaffAccount`. Also, in a 
realworld service, the token created has useful functionality, although it is outside of the bounds of this assignment.

## 2. C# Record

What code did you write to declare `SessionTokenDto` as a record? What
constructor and properties did C# create from that declaration?

I believe that `SessionTokenDto` was already declared as a record in the starter code. All I did was add the arguments 
`Token`, `Username`, and `DisplayName`. The full implementation looked like this:
```csharp
public sealed record SessionTokenDto(string Token, string Username, string DisplayName);
```
C# automatically creates the constructor and properties from those parameters.

## 3. Sequence Diagram Message

Choose one numbered message from the sequence diagram. Identify the class that
sends it, the class that receives it, and the method call that implements it.

Message 3 in the sequence diagram is sent by `ConsoleUI` and received by `AuthService`.
In my code, `RunLogin()` implements this message by calling `_authService.Authenticate(username, password)`
and storing the returned `SessionTokenDto` in `sessionToken` if authentication succeeds.


## 4. Alternative Login Paths

Describe what the program does for an unknown username, an incorrect password,
and valid credentials.

For an unknown username, `FindByUsername()` returns `null`, so `Authenticate()` throws an `InvalidCredentialException` that `RunLogin()` catches to display "Login Failed. Check the username and password."
For an incorrect password, `VerifyCredentialsAndPermissions()` throws the same exception, resulting in the same failure message.
For valid credentials and an account with `CanManageParticipation` set to `true`, `CreateSessionToken()` returns a `SessionTokenDto`, and `DisplayLoginSuccess()` displays its username, display name, and newly generated token.

