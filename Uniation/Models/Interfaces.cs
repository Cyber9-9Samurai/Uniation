using Refit;

namespace Uniation.Models
{
    public interface IJsonPlaceholderApi
    {
        [Get("/api/projects")]
        Task<List<ProjectsData>> GetAllProjects();
    }
}
