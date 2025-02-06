Console.Write("Введите дату рождения (дд.ММ.гггг): ");

if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
{
    int age = CalculateAge(birthDate);
    Console.WriteLine($"Ваш возраст: {age}");

}
else
{
    Console.WriteLine("Некорректный формат даты.");
}

int CalculateAge(DateTime birthDate)
{
    DateTime today = DateTime.Today;
    int age = today.Year - birthDate.Year;

    if (birthDate.Date > today.AddYears(-age))
        age--;

    return age;
}