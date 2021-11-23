using Newtonsoft.Json;

namespace ABU.CanvasSharp.Core.Models;

public record Enrollment
{
    [JsonProperty("type")] public string? Type { get; set; }

    [JsonProperty("role")] public string? Role { get; set; }

    [JsonProperty("role_id")] public object? RoleId { get; set; }

    [JsonProperty("user_id")] public object? UserId { get; set; }

    [JsonProperty("enrollment_state")] public string? EnrollmentState { get; set; }

    [JsonProperty("limit_privileges_to_course_section")]
    public bool LimitPrivilegesToCourseSection { get; set; }
}