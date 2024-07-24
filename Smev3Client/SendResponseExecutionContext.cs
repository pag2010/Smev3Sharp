using System;
using System.Collections.Generic;

namespace Smev3Client
{
    public class SendResponseExecutionContext<T> where T : new()
    {
        /// <summary>
        /// Данные запроса
        /// </summary>
        public T ResponseData { get; set; }

        /// <summary>
        /// Вызывается перед отправкой пакета в СМЭВ
        /// </summary>
        public Action<ReadOnlyMemory<byte>> OnBeforeSend { get; set; }

        public string To { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
