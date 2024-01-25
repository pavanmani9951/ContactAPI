using ContactAPI.Models;

namespace ContactAPI.Data
{
    public static class ContactStore
    {
        public static List<Contact> contacts = new List<Contact>
        {
            new Contact { Id = 1,FirstName="Pavan",LastName="Perumalla",City="SAP",Phone=9951658045,CreatedDate=DateTime.Now},
            new Contact { Id = 2,FirstName="Harini",LastName="Devathi",City="GNT",Phone=9381272144,CreatedDate=DateTime.Now}

        };
    }
}
