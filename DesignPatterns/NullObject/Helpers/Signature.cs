using System.Text;

namespace NullObjectPattern.Helpers
{
    public static class Signature
    {
        private const string TabSymbol = "\t";
        private const int EdgeOffset = 4;

        public static void Sign(params string[] lines)
        {
            var maxLength = lines.Max(s => s.Length);

            var edge = new StringBuilder(TabSymbol);
            edge.Append('*', maxLength + EdgeOffset);

            var textBuilderList = new List<StringBuilder> { edge };

            foreach (var line in lines)
            {
                var textBuilder = new StringBuilder(TabSymbol);

                textBuilder.Append("* ");

                textBuilder.Append(' ', (maxLength - line.Length) / 2);
                textBuilder.Append(line);
                textBuilder.Append(' ', maxLength + EdgeOffset - textBuilder.Length);
                textBuilder.Append("* ");

                textBuilderList.Add(textBuilder);
            }

            textBuilderList.Add(edge);

            foreach (var textBuilder in textBuilderList)
                Console.WriteLine(textBuilder);
        }
    }
}
