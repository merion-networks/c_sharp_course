namespace OperationLibrary.Logic
{
    public class LogicOperation
    {
        public LogicOperation()
        {
            //И (&&), ИЛИ (||), НЕ (!)

            int age = 25;
            DayOfWeek dayOfWeek = DayOfWeek.Sunday;

            bool isWorkAge = (age >= 18) && (age <= 65);

            bool isWeekend = (dayOfWeek == DayOfWeek.Sunday) || (dayOfWeek == DayOfWeek.Saturday);

            bool isValid = true;
            bool isNotValid = !isValid;
        }
    }
}
