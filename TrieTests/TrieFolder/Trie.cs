using System;
using System.Collections.Generic;
using System.Linq;

namespace TrieTests.TrieFolder
{
    public class Trie
    {
        private Node root = new Node(' ');
        public int Count = 0;

        public void Add(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word), "Слово не может быть null.");
            }

            string currWord = word.Trim();
            char[] charArr = new char[currWord.Length];
            for (int i = 0; i < currWord.Length; i++)
            {
                charArr[i] = Convert.ToChar(currWord.Substring(i, 1));
            }

            var current = root;

            for (int i = 0; i < currWord.Length; i++)
            {
                bool isNew = true;
                foreach (var item in current.Descendants)
                {
                    if (item.Symbol == charArr[i])
                    {
                        isNew = false;
                        current = item;
                        break;
                    }
                }

                if (isNew)
                {
                    var item = new Node(charArr[i]);
                    current.Descendants.Add(item);
                    current = item;
                }

                if (i == currWord.Length - 1)
                {
                    current.isWord = true;
                }
            }

            Count++;
        }

        public void Clear()
        {
            root = new Node(' ');
            Count = 0;
        }


        public List<string> Search(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word), "Слово не может быть null.");
            }

            string currWord = word.Trim();
            char[] charArr = new char[currWord.Length];
            for (int i = 0; i < currWord.Length; i++)
            {
                charArr[i] = Convert.ToChar(currWord.Substring(i, 1));
            }

            var current = root;
            List<string> result = new List<string>();

            for (int i = 0; i < charArr.Length; i++)
            {
                bool isCurrentNew = true;
                foreach (var item in current.Descendants)
                {
                    if (item.Symbol == charArr[i])
                    {
                        current = item;
                        isCurrentNew = false;
                    }
                }

                if (isCurrentNew == true)
                {
                    return new List<string>();
                }
            }

            Dictionary<Node, string> listNodes = new Dictionary<Node, string>();
            string resultCurrWord = currWord;
            List<int> countCurrNodeRes = new List<int>();
            bool isNewNode = true;

            while (current != null)
            {
                if (current.isWord && isNewNode == true)
                {
                    result.Add(resultCurrWord);
                }

                if (current.Descendants.Count > 1)
                {
                    if (isNewNode == true)
                    {
                        listNodes.Add(current, resultCurrWord);
                        countCurrNodeRes.Add(0);
                    }
                    current = current.Descendants[countCurrNodeRes.Last()];
                    countCurrNodeRes[countCurrNodeRes.Count - 1] += 1;
                    resultCurrWord += current.Symbol.ToString();
                    isNewNode = true;
                    continue;

                }
                else if (current.Descendants.Count == 1)
                {
                    current = current.Descendants[0];
                    resultCurrWord += current.Symbol.ToString();
                    continue;
                }
                else if (current.Descendants.Count == 0)
                {
                    if (listNodes.Count == 0)
                    {
                        return result;
                    }

                    if (listNodes.Last().Key.Descendants.Count > countCurrNodeRes.Last())
                    {
                        current = listNodes.Last().Key;
                        resultCurrWord = listNodes.Last().Value;
                        isNewNode = false;
                        continue;
                    }
                    else
                    {
                        while (!(listNodes.Last().Key.Descendants.Count > countCurrNodeRes.Last()))
                        {
                            listNodes.Remove(listNodes.Last().Key);
                            countCurrNodeRes.RemoveAt(countCurrNodeRes.Count - 1);
                            if (listNodes.Count == 0)
                            {
                                return result;
                            }
                            current = listNodes.Last().Key;
                            resultCurrWord = listNodes.Last().Value;
                        }
                        isNewNode = false;
                        continue;
                    }
                }
            }

            return result;
        }
    }
}
