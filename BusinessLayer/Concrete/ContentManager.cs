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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Add(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(p => p.ContentId == id);
        }

        public List<Content> GetContent()
        {
            return _contentDal.List();
        }

        public List<Content> GetContentById(int id)
        {
            return _contentDal.List(p => p.HeadingId == id);
        }
    }
}
