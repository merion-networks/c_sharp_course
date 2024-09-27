namespace AbstractionLibrary.Template
{
    public abstract class DataProcessor
    {
        public void Process(string data)
        {
            ReadData(data);
            ProcessData(data);
            WriteData(data);
        }
        protected abstract void ReadData(string data);
        protected abstract void ProcessData(string data);
        protected abstract void WriteData(string data);
    }
}
