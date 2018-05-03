using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Temple.Core.Helper
{
    public class MessageHelper
    {
        private string QueuePath = ".\\private$\\WebCacheRefresh";
        private IMessageFormatter formatter = new System.Messaging.BinaryMessageFormatter();
        private MessageQueue queue;

        public MessageHelper()
        {
            CreateMessageQueue(this.QueuePath);
        }

        public MessageHelper(string path)
        {
            this.QueuePath = path;
            CreateMessageQueue(this.QueuePath);
        }

        private void CreateMessageQueue(string queuePath)
        {
            if (MessageQueue.Exists(queuePath))
            {
                queue = new MessageQueue(queuePath);
            }
            else
            {
                queue = MessageQueue.Create(queuePath, false);
                queue.Label = "缓冲刷新队列";
            }
        }

        private System.Messaging.Message CreateMessage(string text)
        {
            System.Messaging.Message message = new System.Messaging.Message();
            message.Body = text;
            message.Formatter = this.formatter;
            return message;
        }

        public bool SendMessage(string text)
        {
            if (!MessageQueue.Exists(this.QueuePath))
            {
                CreateMessageQueue(this.QueuePath);
                return false;
            }

            MessageQueue queue = new System.Messaging.MessageQueue(this.QueuePath);
            System.Messaging.Message message = CreateMessage(text);
            queue.Send(message);
            return true;
        }

        public string GetMessageText()
        {
            System.Messaging.Message message = ReceiveMessage(this.QueuePath);
            if (message != null)
                return message.Body.ToString();
            return null;
        }

        private System.Messaging.Message ReceiveMessage(string queuePath)
        {
            if (!MessageQueue.Exists(queuePath))
            {
                CreateMessageQueue(this.QueuePath);
                return null;
            }

            System.Messaging.Message message = this.queue.Receive();
            return message;
        }
    }
}