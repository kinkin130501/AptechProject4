using FourN.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Services.IService
{
    public interface IPrivateMessageServices
    {
        List<Privatemessage> findAllMessageById(int id);
        Privatemessage findOneMessage(int id);
        Privatemessage UpdateMessage(Privatemessage m);
        Boolean DeleteMessage(Privatemessage m);
        List<Privatemessage> findMessageByIdSent(int id);
        List<Privatemessage> findMessageByIdInbox(int id);
    }
}
