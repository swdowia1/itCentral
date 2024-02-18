using Encrypt;
using ItCentral.Model;

namespace ItCentral.Service
{
    public class MessageService : IMessageService
    {
        private readonly ItCentralDataContext _dbContext;

        public MessageService(ItCentralDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetMessage(string key)
        {
            var s = _dbContext.Messages.FirstOrDefault(k => k.Key == key);
            string result = Cipher.Decrypt(s.MessageValue, s.Key);
            return result;
        }
    }
}
