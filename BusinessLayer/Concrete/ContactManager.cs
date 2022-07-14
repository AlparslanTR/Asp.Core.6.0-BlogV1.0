using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public List<Contact> GetAll()
        {
            return contactDal.GetAll();
        }

        public Contact GetID(int id)
        {
            return contactDal.GetID(id);
        }

        public void TAdd(Contact t)
        {
            contactDal.Add(t);
        }

        public void TDelete(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TUptade(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
