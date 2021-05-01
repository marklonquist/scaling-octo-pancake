using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Util;
using System.IO;

namespace Bestseller.SearchIndex
{
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
