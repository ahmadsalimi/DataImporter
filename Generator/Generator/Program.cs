using Nest;
using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = new Uri("http://localhost:9200/");
            var settings = new ConnectionSettings(url).DefaultIndex("visual_query_framework_test_1");
            var client = new ElasticClient(settings);

            var cards = GetCards();
            var transactions = GetTransactions();

            InsertCards(cards, client);
            InsertTransactions(transactions, client);
        }

        private static void InsertCards(IEnumerable<Card> cards, ElasticClient client)
        {
            var descriptor = new BulkDescriptor();

            foreach (var card in cards)
            {
                descriptor.Create<Card>(op => op.Document(card));
            }

            var result = client.Bulk(descriptor);
        }

        private static void InsertTransactions(IEnumerable<Transaction> transactions, ElasticClient client)
        {
            var descriptor = new BulkDescriptor();

            foreach (var transaction in transactions)
            {
                descriptor.Create<Transaction>(op => op.Document(transaction));
            }

            var result = client.Bulk(descriptor);
        }

        private static IEnumerable<Card> GetCards()
        {
            var cards = new List<Card>();

            using (var cardFile = new StreamReader("../../../data/card.csv"))
            {
                var cardString = cardFile.ReadLine();

                while (cardString != null)
                {
                    var attributes = cardString.Split(',');

                    var card = new Card
                    {
                        Id = attributes[0],
                        ElementId = "1",
                        BranchCode = attributes[1],
                        Branch = attributes[2],
                        AccountNumber = attributes[3],
                        Iban = attributes[4],
                        AccountType = attributes[5],
                        CardNumber = attributes[6],
                        BankName = attributes[7]
                    };

                    cards.Add(card);

                    cardString = cardFile.ReadLine();
                }
            }

            return cards;
        }

        private static IEnumerable<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>();

            using (var transactionFile = new StreamReader("../../../data/transaction.csv"))
            {
                var transactionString = transactionFile.ReadLine();

                while (transactionString != null)
                {
                    var attributes = transactionString.Split(',');

                    var transaction = new Transaction
                    {
                        Id = attributes[0],
                        ElementId = "2",
                        SourceId = attributes[1],
                        TargetId = attributes[2],
                        Date = attributes[3],
                        Time = attributes[4],
                        State = attributes[5],
                        Amount = int.Parse(attributes[6]),
                        IssueTracking = attributes[7],
                    };

                    transactions.Add(transaction);

                    transactionString = transactionFile.ReadLine();
                }
            }

            return transactions;
        }
    }
}
