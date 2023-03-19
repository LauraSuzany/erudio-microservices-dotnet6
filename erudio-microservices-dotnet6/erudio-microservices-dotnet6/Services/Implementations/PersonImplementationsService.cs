using erudio_microservices_dotnet6.Model;
using System;

namespace erudio_microservices_dotnet6.Services.Implementations
{
    public class PersonImplementationsService : IPersonService
    {
        private volatile int count;

        public PersonModel Create(PersonModel Person)
        {
            return Person;
        }

        public void Delete(long id)
        {

        }

        public PersonModel FindById(long id)
        {
            return new PersonModel
            {
                Id = IncrementeAndGet(),
                FirstName = "Laura",
                LastName = "Suzany",
                Adress = "Belém - State of Pará, 66035-140",
                gender = "Female"
            };
        }

        public List<PersonModel> FindAll()
        {
            List<PersonModel> persons = new List<PersonModel>();
            
            for (int i = 0; i < 8; i++)
            {
                PersonModel person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public PersonModel Update(PersonModel Person)
        {
            throw new NotImplementedException();
        }

        private PersonModel MockPerson(int i)
        {
            string sGender = i % 2 == 0 ? "Female" : "Male";
            return new PersonModel
            {
                Id = IncrementeAndGet(),
                FirstName = "First Name " + i,
                LastName = "Last Name " + i,
                Adress = "Adress " + i,
                gender = sGender
            };
        }

        private long IncrementeAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
