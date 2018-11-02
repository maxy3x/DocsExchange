using System;
using System.ComponentModel;

namespace DocsExchange.ViewModels
{
    public class CompanyView
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        [DisplayName("Назва компанії")]
        public String Name { get; set; }
        [DisplayName("Повідомлення")]
        public String Message { get; set; }
    }
}