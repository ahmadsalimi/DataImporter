using Nest;

namespace Generator
{
    class Transaction
    {
        [Text(Name = "id")]
        public string Id { get; set; }

        [Text(Name = "element_id")]
        public string ElementId { get; set; }

        [Text(Name = "source_id")]
        public string SourceId { get; set; }

        [Text(Name = "target_id")]
        public string TargetId { get; set; }

        [Text(Name = "source_target_id")]
        public string SourceTargetId => $"{SourceId}_{TargetId}";

        [Text(Name = "date")]
        public string Date { get; set; }

        [Text(Name = "time")]
        public string Time { get; set; }

        [Text(Name = "state")]
        public string State { get; set; }

        [Text(Name = "issue_tracking")]
        public string IssueTracking { get; set; }

        [Text(Name = "amount")]
        public int Amount { get; set; }
    }
}
