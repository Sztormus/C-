using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern.Helpers
{
    public static class Signature
    {
        private const string tabSymbol = "\t";
        private const int edgeOffset = 4;

        public static void Sign(params string[] lines)
        {
            var maxLength = lines.Max(s => s.Length);

            var edge = new StringBuilder(tabSymbol);
            edge.Append('*', maxLength + edgeOffset);

            var textBuilderList = new List<StringBuilder> { edge };

            foreach (var line in lines)
            {
                var textBuilder = new StringBuilder(tabSymbol);

                textBuilder.Append("* ");

                textBuilder.Append(' ', (maxLength - line.Length) / 2);
                textBuilder.Append(line);
                textBuilder.Append(' ', maxLength + edgeOffset - textBuilder.Length);
                textBuilder.Append("* ");

                textBuilderList.Add(textBuilder);
            }

            textBuilderList.Add(edge);

            foreach (var textBuilder in textBuilderList)
                Console.WriteLine(textBuilder);
        }
    }
}
