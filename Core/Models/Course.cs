using Newtonsoft.Json;

namespace ABU.CanvasSharp.Core.Models;

public record Course
{
    [JsonProperty("id")] public long Id { get; init; }

    [JsonProperty("root_account_id")] public long RootAccountId { get; init; }

    [JsonProperty("account_id")] public long AccountId { get; init; }

    [JsonProperty("name")] public string? Name { get; init; }

    [JsonProperty("enrollment_term_id")] public long EnrollmentTermId { get; init; }

    [JsonProperty("uuid")] public string? Uuid { get; init; }

    [JsonProperty("start_at")] public DateTime StartAt { get; init; }

    [JsonProperty("grading_standard_id")] public object? GradingStandardId { get; init; }

    [JsonProperty("is_public")] public bool IsPublic { get; init; }

    [JsonProperty("created_at")] public DateTime CreatedAt { get; init; }

    [JsonProperty("course_code")] public string? CourseCode { get; init; }

    [JsonProperty("default_view")] public string? DefaultView { get; init; }

    [JsonProperty("license")] public string? License { get; init; }

    [JsonProperty("grade_passback_setting")]
    public object? GradePassbackSetting { get; init; }

    [JsonProperty("end_at")] public object? EndAt { get; init; }

    [JsonProperty("public_syllabus")] public bool PublicSyllabus { get; init; }

    [JsonProperty("public_syllabus_to_auth")]
    public bool PublicSyllabusToAuth { get; init; }

    [JsonProperty("storage_quota_mb")] public int StorageQuotaMb { get; init; }

    [JsonProperty("is_public_to_auth_users")]
    public bool IsPublicToAuthUsers { get; init; }

    [JsonProperty("homeroom_course")] public bool HomeroomCourse { get; init; }

    [JsonProperty("course_color")] public object? CourseColor { get; init; }

    [JsonProperty("friendly_name")] public object? FriendlyName { get; init; }

    [JsonProperty("apply_assignment_group_weights")]
    public bool ApplyAssignmentGroupWeights { get; init; }

    [JsonProperty("calendar")] public Calendar Calendar { get; init; } = new();

    [JsonProperty("time_zone")] public string? TimeZone { get; init; }

    [JsonProperty("blueprint")] public bool Blueprint { get; init; }

    [JsonProperty("template")] public bool Template { get; init; }

    [JsonProperty("enrollments")] public List<Enrollment> Enrollments { get; init; } = new();

    [JsonProperty("hide_final_grades")] public bool HideFinalGrades { get; init; }

    [JsonProperty("workflow_state")] public string? WorkflowState { get; init; }

    [JsonProperty("restrict_enrollments_to_course_dates")]
    public bool RestrictEnrollmentsToCourseDates { get; init; }

    [JsonProperty("overridden_course_visibility")]
    public string? OverriddenCourseVisibility { get; init; }
}