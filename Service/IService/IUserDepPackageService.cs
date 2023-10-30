using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IUserDepPackageService
    {
        public bool AddPackage(ApplicationUser applicationUser, string optForPF);
    }
}
