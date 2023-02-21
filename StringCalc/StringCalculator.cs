namespace StringCalc
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            
            var delimiters = new List<char> { ',', '\n' };

            string numberString = numbers;

            if (numberString.StartsWith("//"))
            {
                var splitImput = numberString.Split('\n');

                var newDelimiter = splitImput.First().Trim('/');
                numberString = String.Join('\n', splitImput.Skip(1));

                delimiters.Add(Convert.ToChar(newDelimiter));
            }

            var numberList = numbers.Split(delimiters.ToArray())
                .Select(s => int.Parse(s));

            var negatives = numberList
                .Where(n => n < 0);

            if (negatives.Any())
            {
                string negativeString = String.Join(',',negatives
                    .Select(n => Convert.ToString(n)));

                throw new Exception($"Negatives not allowed: {negatives}");
            }



            var result = numberList
                .Sum();

            return result;
        }
    }
}