namespace OnlyBooksBFF.Models.Mongo
{
    public class MongoId
    {
        public long Timestamp { get; set; }
        public int Machine { get; set; }
        public int Pid { get; set; }
        public int Increment { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
