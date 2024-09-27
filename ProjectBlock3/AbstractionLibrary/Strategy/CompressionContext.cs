
namespace AbstractionLibrary.Strategy
{
    public class CompressionContext
    {
        private ICompressionStrategy strategy;

        public CompressionContext(ICompressionStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(ICompressionStrategy strategy) => this.strategy = strategy;

        public void CreateArchive(string file)
        {
            this.strategy.Compress(file);
        }
    }
}
