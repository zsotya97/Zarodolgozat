using System;

namespace Projekt.Models
{
    //Hiba modell, nem lett felhasználva
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
