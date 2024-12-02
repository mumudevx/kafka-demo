# Kafka Demo with Dotnet8

This repository contains simple producer and consumer projects that using Kafka, written in .NET8

# Prerequisites / Steps

### Install Docker via winget

```sh
  winget install -e -i Docker.DockerDesktop
``` 

or download via [website](https://www.docker.com/products/docker-desktop/)

### Run Docker Compose File (compose file at root of Solution folder)

```sh
  docker-compose up -d
```

### Create Kafka Topic

```sh
  docker exec -it kafka kafka-topics.sh --create --topic demo-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

### Run Producer/Consumer Projects

**Linux/macOS**

**make .sh file executable**: ```chmod +x run-all.sh```

```sh
  ./run-all.sh
```

**Windows**

```sh
  ./run-all.bat
```

### Screenshot
![screenshot](ss.jpg)

# Kafka Overview

Kafka is a distributed event-streaming platform designed to handle real-time data feeds with high throughput, scalability, and reliability. It is commonly used for building event-driven architectures, streaming analytics, and data pipelines.

## Key Components of Kafka

### 1. **Broker**
A Kafka broker is responsible for managing message storage and distribution. It handles:
- Receiving and persisting messages to disk.
- Serving consumers with requested messages.
Kafka clusters often consist of multiple brokers for fault tolerance and scalability.

### 2. **Topic**
A topic is a category or feed name where messages are written and read. Topics are:
- Partitioned to enable parallelism.
- Log-structured to retain data based on configuration.

### 3. **Partition**
Each topic is divided into partitions, enabling distributed storage and parallel processing. Partitions:
- Ensure message ordering within each partition.
- Allow horizontal scalability.

### 4. **Producer**
Producers are clients that publish messages to Kafka topics. They:
- Push data to specified topics.
- Can partition data based on keys for better message distribution.

### 5. **Consumer**
Consumers subscribe to Kafka topics and process messages. They:
- Read messages in the order they appear in a partition.
- Can form consumer groups for load balancing.

### 6. **Consumer Group**
A consumer group is a collection of consumers that jointly consume messages from a topic. Kafka ensures:
- Each partition is consumed by only one consumer in a group.
- Fault tolerance and scalability by redistributing partitions on consumer failure.

### 7. **Zookeeper (Deprecated)**
Previously used for managing Kafka metadata and configurations, Zookeeper is being replaced by Kafka's **KRaft** (Kafka Raft) for improved scalability and fault tolerance.

### 8. **Connect**
Kafka Connect is a tool for integrating Kafka with external systems (e.g., databases, file systems). It supports:
- Pre-built connectors for common integrations.
- Custom connectors for specialized use cases.

### 9. **Streams**
Kafka Streams is a library for building real-time applications and microservices that process data stored in Kafka topics. It supports:
- Stateful and stateless processing.
- Fault-tolerant and distributed stream processing.

## Use Cases
- **Event-Driven Systems:** Enables asynchronous communication between services.
- **Log Aggregation:** Centralized logging for analytics and monitoring.
- **Real-Time Analytics:** Processing and analyzing data streams in real time.
- **Data Pipelines:** Integrating multiple data sources into a unified stream.
