using System.Diagnostics;
using Uniation.Models;

namespace Uniation.Helpers
{
    public class ApiService
    {

        private readonly IJsonPlaceholderApi _apiClient;
        public List<ProjectsData> projects;

        public ApiService(IJsonPlaceholderApi apiClient)
        {
            _apiClient = apiClient;
        }

        public async void GetAllProjects()
        {
            projects = await _apiClient.GetAllProjects();
            foreach(var p in projects)
            {
                Debug.WriteLine(p.id);
            }
        }


    }
}
