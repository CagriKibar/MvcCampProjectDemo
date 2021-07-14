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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messagegDal)
        {
            _messageDal = messagegDal;
        }
        public Message GetByID(int id)
        {
            return _messageDal.Get(p => p.MessageID==id);
        }

        public List<Message> GetMessagesInbox()
        {
            return _messageDal.List(p => p.ReceiverMail == "cagri.kibar@outlook.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Add(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> SendMessagesInbox()
        {
            return _messageDal.List(p => p.SenderMail == "cagri.kibar@outlook.com");
        }
    }
}
