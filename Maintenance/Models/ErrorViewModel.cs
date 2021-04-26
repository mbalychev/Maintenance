using System;

namespace Maintenance.Models
{
    public class ErrorViewModel
    {
        private string messsage;

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Messsage { get => messsage; set => messsage = value; }
    }
}
