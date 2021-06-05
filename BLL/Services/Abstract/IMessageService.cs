using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IMessageService
    {
        public Task<IEnumerable<Message>> Get();
        public Task<Message> GetById(Guid id);
        public Task<Message> Add(Message item);
        public Task<Message> Update(Message item);
        public Task<Message> DeleteById(Guid id);
    }
}
