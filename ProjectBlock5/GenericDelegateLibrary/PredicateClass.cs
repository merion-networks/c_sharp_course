using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GenericDelegateLibrary
{
    public class PredicateClass
    {
        public void Example()
        {
            Predicate<int> predicate = IsEven;

            bool result = predicate(4);
        }

        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public void ExampleValidate()
        {
            List<string> emails = new List<string>() { "user@example.com", "invalid-email", "test@mail.com", "test", "test.test@mail" };
            Predicate<string> isValidEmail = email =>
            {
                try
                {
                    var addr = new MailAddress(email);

                    if (addr.Address != email)
                        return false;

                    string host = addr.Host;
                    int index = host.LastIndexOf('.');
                    if (index > 0 && index < host.Length - 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            };

            foreach (var email in emails)
            {
                if (isValidEmail(email))
                {
                    Console.WriteLine(email);
                }
            }
        }


        public void ExampleValidateRegular()
        {
            try
            {
                List<string> emails = new List<string>() { "user@example.com", "invalid-email", "test@mail.com", "test", "test.test@mail" };
                Predicate<string> isValidEmail = email => Regex.IsMatch(email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");


                foreach (var email in emails)
                {
                    if (isValidEmail(email))
                    {
                        Console.WriteLine(email);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void ExampleSettings()
        {
            List<int> ProcessData(List<int> data, Predicate<int> filter, Func<int, int> transform)
            {
                return data.Where(item => filter(item)).Select(item => transform(item)).ToList();
            }

            List<int> numbers = Enumerable.Range(1, 10).ToList();

            Predicate<int> isEven = n => n % 2 == 0;
            Func<int, int> multiplyByTen = n => n * 10;

            List<int> result = ProcessData(numbers, isEven, multiplyByTen);

            result.ForEach(result => Console.WriteLine(result));
        }
        public void ExampleSettingsValidate()
        {
            List<Predicate<string>> passwordRules = new List<Predicate<string>>()
                                                        {
                                                            pwd => pwd.Length > 8,
                                                            pwd => pwd.Any(char.IsUpper),
                                                            pwd => pwd.Any(char.IsLower),
                                                            pwd => pwd.Any(char.IsDigit),
                                                            pwd => pwd.Any(ch=> "!@#$%^&*()".Contains(ch)),
                                                        };


            bool ValidatePassword(string password)
            {
                return passwordRules.All(rule => rule(password));
            }
            string userPassword = "P@ssw0rds";
            bool isValid = ValidatePassword(userPassword);

        }
    }
}
