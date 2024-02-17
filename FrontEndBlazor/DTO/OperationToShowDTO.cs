namespace BlazorApp2.DTO;

public class OperationToShowDTO
    {
        public String TypeName { get; set; }
        public DateTime DateOfOperations { get; set; }
        public decimal Amount { get; set; }
        
        public Guid Id { get; set; }
    }
