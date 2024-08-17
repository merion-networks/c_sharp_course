namespace VariablesLibrary
{
    public class Variable
    {
        private int classField;

        private const string nameField = "Field";

        private readonly string name;

        void Metod(int parametr)
        {
            // var и dynamic

            var res = 10.55;
            dynamic temp = 100;
        }

        public Variable()
        {
            int result = 0;
            bool isActiv = true;
            name = nameField;

        }
    }
}
