using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameEngine.Tests
{
    public class ExternalHealthDamageTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                List<object[]> data = new List<object[]>();
                string[] csvLines = File.ReadAllLines("./TestData.csv");
                foreach (var cavLine in csvLines)
                {
                    IEnumerable<int> values = cavLine.Split(',').Select(int.Parse);
                    object[] testCase = values.Cast<object>().ToArray();
                    data.Add(testCase);
                }

                return data;
            }
        }
    }
}