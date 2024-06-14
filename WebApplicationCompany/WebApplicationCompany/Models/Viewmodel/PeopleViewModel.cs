using WebApplicationCompany.Models.Entities;

namespace WebApplicationCompany.Models.Viewmodel
{
    public class PeopleViewModel
    {
        internal string Message;

        public string Search { get; set; }
        public List<Person> People { get; set; }
        public string SearchResultMessage { get; set; }

        public PeopleViewModel()
        {
            People = new List<Person>();
        }

    }
}
