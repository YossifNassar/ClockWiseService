﻿using System;

namespace Metrics.Models
{
    public class Metric
    {
        /// <summary>
        /// date of this metric.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Numeric value of heart rate.
        /// </summary>
        public int HeartRate { get; set; }

        /// <summary>
        /// The person's movement.
        /// </summary>
        public int Movement { get; set; }
    }
}