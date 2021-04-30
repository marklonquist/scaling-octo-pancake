using Bestseller.Database;
using Bestseller.Database.Interfaces;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bestseller.SearchIndex
{
    public class Indexer
    {
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private Analyzer analyzer { get; set; }
        private IndexWriter writer { get; set; }

        public Indexer(IRepository<Product, int> productRepository)
        {
            analyzer = new NGramAnalyzer(AppLuceneVersion);

            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var indexPath = Path.Combine(basePath, "index");

            var dir = FSDirectory.Open(indexPath);

            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            writer = new IndexWriter(dir, indexConfig);

            var allProducts = productRepository.Get();

            foreach (var product in allProducts)
            {
                if (product.Name.En.Length == 0 && product.Name.Dk.Length == 0)
                {
                    continue;
                }

                var source = new
                {
                    Id = product.Id,
                    Name = product.Name.En.Length != 0 ? product.Name.En : product.Name.Dk
                };

                var doc = new Document
                {
                    new Int32Field("id", source.Id, Field.Store.YES),
                    new TextField("name", source.Name, Field.Store.YES)
                };

                writer.AddDocument(doc);
            }

            writer.Flush(triggerMerge: false, applyAllDeletes: false);
        }

        public List<ResultValue> Search(string searchPhrase)
        {
            using var reader = writer.GetReader(applyAllDeletes: true);
            var searcher = new IndexSearcher(reader);

            var phrase = new TermQuery(new Term("name", searchPhrase));
            var hits = searcher.Search(phrase, 5).ScoreDocs;

            var results = new List<ResultValue>();
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);

                results.Add(new ResultValue
                {
                    Id = foundDoc.Get("id"),
                    Name = foundDoc.Get("name")
                });
            }

            return results;
        }

        public class ResultValue
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }

    internal class NGramAnalyzer : Analyzer
    {
        private LuceneVersion appLuceneVersion;
        public NGramAnalyzer(LuceneVersion appLuceneVersion)
        {
            this.appLuceneVersion = appLuceneVersion;
        }

        protected override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {
            var source = new NGramTokenizer(appLuceneVersion, reader, 1, 10);
            var filter = new LowerCaseFilter(appLuceneVersion, source);
            return new TokenStreamComponents(source, filter);
        }
    }
}
