using ABU.CanvasSharp.Core.Models;

namespace ABU.CanvasSharp.Infrastructure.Abstractions;

public interface ICanvasApiClient
{
    Task<IReadOnlyList<Course>> GetCoursesAsync(CancellationToken ct = default);
}