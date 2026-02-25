namespace BIK.CoreBanking.DTOs
{
    public class TransactionHistoryResponse
    {
        public int Id { get; set; } 
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty; 
        public string Type { get; set; } = string.Empty; 
        public DateTime Timestamp { get; set; }
    }
}