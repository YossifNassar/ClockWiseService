using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure;
using Metrics.Models;
using System.Configuration;

namespace ContactList
{
    public class MetricsLogic
    {
        private static CloudTable GetTableClient()
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("metrics");

            return table;
        }
        public static void CreateMetricsTable()
        {
            // Retrieve a reference to the table.
            CloudTable table = GetTableClient();

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();
        }

        public static List<Metric> GetMetrics()
        {
            List<Metric> results = new List<Metric>();
            // Retrieve a reference to the table.
            CloudTable table = GetTableClient();

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<MetricEntity> query = new TableQuery<MetricEntity>();

            // Print the fields for each customer.
            foreach (MetricEntity entity in table.ExecuteQuery(query))
            {
                results.Add(new Metric { HeartRate = entity.HeartRate, SleepCycle = entity.SleepCycle });
            }

            return results;
        }

        public static void AddMetric(Metric m)
        {
            // Create the CloudTable object that represents the "people" table.
            CloudTable table = GetTableClient();

            // Create a new customer entity.
            MetricEntity metric = new MetricEntity(m.SleepCycle, m.HeartRate);
            metric.SleepCycle = m.SleepCycle;
            metric.HeartRate = m.HeartRate;

            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(metric);

            // Execute the insert operation.
            table.Execute(insertOperation);

        }
    }
}