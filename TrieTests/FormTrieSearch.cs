using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrieTests.TrieFolder;
using System.Linq;

namespace TrieTests
{
    public partial class FormTrieSearch : Form
    {
        Trie trie = new Trie();
        List<string> list = new List<string>();

        public FormTrieSearch()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim().Length > 0) 
            {
                var results = trie.Search(tbSearch.Text.Trim());
                if (results.Count > 0)
                {
                    listBoxResults.Items.Clear();
                    foreach (var item in results)
                    {
                        listBoxResults.Items.Add(item);
                    }
                }
                else
                {
                    listBoxResults.Items.Clear();
                    listBoxResults.Items.Add("Результатов не найдено!");
                }
            } 
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string str = tbAdd.Text.Trim();

            if (str != "" && !list.Contains(str)) 
            {
                list.Add(str);
                listBoxWords.Items.Add(str);
                trie.Add(str);
            }
        }
    }
}
