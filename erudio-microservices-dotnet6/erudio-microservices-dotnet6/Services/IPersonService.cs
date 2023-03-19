using erudio_microservices_dotnet6.Model;

namespace erudio_microservices_dotnet6.Services
{
    public interface IPersonService
    {
        PersonModel Create(PersonModel Person);
        PersonModel FindById(long id);
        List<PersonModel> FindAll();
        PersonModel Update(PersonModel Person);
        void Delete(long id);
    }
}
