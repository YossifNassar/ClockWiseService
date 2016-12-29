using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace ContactList
{
    public class MetricEntity : TableEntity
    {
        public MetricEntity(string Date,int Movement, int HeartRate)
        {
            this.PartitionKey = Date.ToString();
            this.RowKey = HeartRate.ToString();
            this.Date = Date;
            this.Movement = Movement;
            this.HeartRate = HeartRate;
        }
          
        public MetricEntity() { }

        public string Date { get; set; }

        public int Movement { get; set; }

        public int HeartRate { get; set; }
    }
}