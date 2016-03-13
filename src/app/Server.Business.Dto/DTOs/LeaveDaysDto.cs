namespace Server.Business.Dto
{
    public class LeaveDaysDto
    {
        public int Id { get; set; }

        public int EmployeeID { get; set; }

        public int ForYear { get; set; }

        public int AllowedPaidDays { get; set; }

        public int TakenPaidDays { get; set; }

        public int AllowedNonPaidDays { get; set; }

        public int TakenNonPaidDays { get; set; }

        public int SickDays { get; set; }

        public int OtherDays { get; set; }

        public int TransferredDays { get; set; }

        public int CompensationDays { get; set; }
    }
}
