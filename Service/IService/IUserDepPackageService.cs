using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IUserDepPackageService
    {
        public bool AddDepPackage(ApplicationUser applicationUser, string optForPF);
    }
}
