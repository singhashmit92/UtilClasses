using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshmeetGithub
{
    public class UtilClasses
    {
        public static DisJointSetNode find(DisJointSetNode node)
        {

            var parent = node.parent;

            if (parent == node)
            {
                return node;
            }

            node.parent = find(node.parent);
            return node.parent;
        }

        public static void union(DisJointSetNode node1, DisJointSetNode node2)
        {

            var par1 = find(node1);
            var par2 = find(node2);

            if (par1 == par2)
                return;

            if (par1.rank > par2.rank)
            {
                par2.parent = par1;
            }
            else if (par1.rank == par2.rank)
            {
                par2.parent = par1;
                par1.rank++;
            }
            else
            {
                par1.parent = par2;
            }

        }

        static bool search(string word, TrieNode root)
        {
            TrieNode curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (curr.children.ContainsKey(word[i]))
                {
                    curr = curr.children[word[i]];
                }
                else
                {
                    return false;
                }
            }

            return curr.isCompleteWord;

        }

        static void insert(string word, TrieNode current)
        {

            for (int i = 0; i < word.Length; i++)
            {
                if (!current.children.ContainsKey(word[i]))
                {
                    var node = new TrieNode();
                    current.children.Add(word[i], node);
                    current = node;
                }
                else
                {
                    current = current.children[word[i]];
                }
            }
            current.isCompleteWord = true;
        }
    }
    public class DisJointSetNode
    {
        public int val;
        public int rank;
        public DisJointSetNode parent;

        public DisJointSetNode(int val, int rank)
        {
            this.val = val;
            this.rank = rank;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool isCompleteWord;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
        public TreeNode()
        {
        }
    }

    public class LLNode
    {
        public int val;
        public LLNode n;

        public LLNode(int val)
        {
            this.val = val;
        }
    }

}
