namespace DatabaseSo
{
    [Serializable]
    public class Message
    {
        public Operation Op { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public enum Operation
    {
        Insert,
        Get,
        Update,
        Remove
    }
}