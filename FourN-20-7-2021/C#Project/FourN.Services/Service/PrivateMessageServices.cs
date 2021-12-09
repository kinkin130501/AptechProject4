using FourN.Data.Models;
using FourN.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Services.Service
{
    public class PrivateMessageServices : IPrivateMessageServices
    {
        public bool DeleteMessage(Privatemessage m)
        {
            throw new NotImplementedException();
        }

        public List<Privatemessage> findAllMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Privatemessage> findMessageByIdInbox(int id)
        {
            throw new NotImplementedException();
        }

        public List<Privatemessage> findMessageByIdSent(int id)
        {
            throw new NotImplementedException();
        }

        public Privatemessage findOneMessage(int id)
        {
            throw new NotImplementedException();
        }

        public Privatemessage UpdateMessage(Privatemessage m)
        {
            throw new NotImplementedException();
        }
    }
}
