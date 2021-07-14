using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(p => p.HeadingId == id);
        }

        public List<Heading> GetHeading()
        {
            return _headingDal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
