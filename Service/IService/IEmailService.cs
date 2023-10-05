namespace BlazorProject.Service.IService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(Models.Task Task, string oldTask);
    }
}
