﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.WindowsAzure.Storage.Queue;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueProcessorFactoryContextTests
    {
        [Fact]
        public void Constructor_DefaultsValues()
        {
            CloudQueue queue = new CloudQueue(new Uri("https://test.queue.core.windows.net/testqueue"));
            CloudQueue poisonQueue = new CloudQueue(new Uri("https://test.queue.core.windows.net/poisonqueue"));
            TestTraceWriter log = new TestTraceWriter(TraceLevel.Verbose);
            JobHostQueuesConfiguration queuesConfig = new JobHostQueuesConfiguration();

            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(queue, log, queuesConfig, poisonQueue);

            Assert.Same(queue, context.Queue);
            Assert.Same(log, context.Trace);
            Assert.Same(poisonQueue, context.PoisonQueue);

            Assert.Equal(queuesConfig.BatchSize, context.BatchSize);
            Assert.Equal(queuesConfig.NewBatchThreshold, context.NewBatchThreshold);
            Assert.Equal(queuesConfig.MaxDequeueCount, context.MaxDequeueCount);
            Assert.Equal(queuesConfig.MaxPollingInterval, context.MaxPollingInterval);
        }
    }
}
