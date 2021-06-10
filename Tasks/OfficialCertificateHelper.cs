using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Tasks
{
    public class OfficialCertificateHelper
    {
        public List<List<int>> GetOrderCombinations(int numberOfOfficials, string rulesString = null) // {1,[2]},{2,[3,4]} 
        {
            var officials = Enumerable.Range(1, numberOfOfficials)
                .ToList();
            var officialsCombinations = ShowAllCombinations(officials);
            
            if (string.IsNullOrWhiteSpace(rulesString))
            {
                return officialsCombinations;
            }
            
            var rules = JsonConvert.DeserializeObject<List<Rule>>(rulesString);

            var validCombinations = new List<List<int>>();

            foreach (var combination in officialsCombinations)
            {
                var isValidCombination = true;
                foreach (var rule in rules)
                {
                    foreach (var condition in rule.CertificateConditions)
                    {
                        if (combination.IndexOf(rule.OfficialDigit) < combination.IndexOf(condition))
                        {
                            isValidCombination = false;
                        }
                    }
                }

                if (isValidCombination)
                {
                    validCombinations.Add(combination);
                }
            }
            

            return validCombinations;
        }
        
        private static List<List<T>> ShowAllCombinations<T>(IList<T> arr, List<List<T>> list = null, List<T> current = null)
        {
            if (list == null) list = new List<List<T>>();
            if (current == null) current = new List<T>();
            if (arr.Count == 0) //если все элементы использованы возвращаемся
            {
                list.Add(current);
                return list;
            }
            //в цикле для каждого элемента прибавляем его к итоговой строке, создаем новый список из оставшихся элементов, и вызываем эту же функцию рекурсивно с новыми параметрами.
            for (int i = 0; i < arr.Count; i++)
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);
                var newlst = new List<T>(current);
                newlst.Add(arr[i]);
                ShowAllCombinations(lst, list, newlst);
            }
            return list;
        }
    }
}