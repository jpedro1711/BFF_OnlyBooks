namespace OnlyBooksBFF.Models.Mongo
{
    public class EmprestimoResponse
    {
        public MongoId Id { get; set; }
        public int ReservaId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int StatusEmprestimo { get; set; }
    }
}
