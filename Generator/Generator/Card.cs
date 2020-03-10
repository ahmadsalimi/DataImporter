using Nest;

namespace Generator
{
    class Card
    {
        [Text(Name = "id")]
        public string Id { get; set; }

        [Text(Name = "element_id")]
        public string ElementId { get; set; }

        [Text(Name = "branch_code")]
        public string BranchCode { get; set; }

        [Text(Name = "branch")]
        public string Branch { get; set; }

        [Text(Name = "account_number")]
        public string AccountNumber { get; set; }

        [Text(Name = "iban")]
        public string Iban { get; set; }

        [Text(Name = "account_type")]
        public string AccountType { get; set; }

        [Text(Name = "card_number")]
        public string CardNumber { get; set; }

        [Text(Name = "bank_name")]
        public string BankName { get; set; }
    }
}
