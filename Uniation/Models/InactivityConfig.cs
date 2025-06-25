using Newtonsoft.Json;

namespace Uniation.Models;

public record InactivityConfig(
    [property:JsonProperty("inactivityTime")] int InactivityTime,
    [property:JsonProperty("passwordInactivityTime")] int PasswordInactivityTime);