using WebApplicationCompany.Models.Entities;

namespace WebApplicationCompany.Models.Viewmodel
{
    public class PeopleViewModel
    {
        public string Search { get; set; }
        public List<Person> People { get; set; }

        public PeopleViewModel()
        {
            People = new List<Person>();
        }

    }
}
