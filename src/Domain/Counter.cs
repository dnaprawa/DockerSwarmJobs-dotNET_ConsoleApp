using System;

namespace Domain
{
    public class Counter : EntityBase
    {
        public Counter(int value)
        {
            Value = value;
            UpdateDate = DateTime.UtcNow;
        }
        protected Counter() { }

        public DateTime UpdateDate { get; protected set; }
        public int Value { get; protected set; }
    }
}
