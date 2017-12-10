using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamElliott
{
    public class TriLink
    {
        public Node root;

        public TriLink()
        {
            if (root == null)
            {
                root = new Node();
            }
        }

        public void insert(int value)
        {
            recInsert(value, root);
        }

        public void recInsert(int value, Node curNode)
        {
            if (curNode.V1 == null)
            {
                curNode.V1 = value;
            }
            else if (curNode.V1 == value)
            {
                if (curNode.V1Delete == true)
                {
                    curNode.V1Delete = false;
                }
                return;
            }
            else if (curNode.V1 > value)
            {
                if (curNode.low == null)
                {
                    Node newNode = new Node(value);
                    newNode.parent = curNode;
                    curNode.low = newNode;
                }
                else recInsert(value, curNode.low);

            }
            else if (curNode.V1 < value)
            {
                if (curNode.V2 == null)
                {
                    curNode.V2 = value;
                }
                else if (curNode.V2 == value)
                {
                    if (curNode.V2Delete == true)
                    {
                        curNode.V2Delete = false;
                    }
                    return;
                }
                else if (curNode.V2 > value)
                {
                    if (curNode.medium == null)
                    {
                        Node newNode = new Node(value);
                        newNode.parent = curNode;
                        curNode.medium = newNode;
                    }
                    else recInsert(value, curNode.medium);

                }
                else if (curNode.V2 < value)
                {
                    if (curNode.high == null)
                    {
                        Node newNode = new Node(value);
                        newNode.parent = curNode;
                        curNode.high = newNode;
                    }
                    else recInsert(value, curNode.high);
                }
            }
        }
        public string print()
        {
            string output = "";
            recPrint(ref output, root);
            return output;
        }

        public void recPrint(ref string output, Node curNode)
        {
            if (curNode.low != null)
            {
                recPrint(ref output, curNode.low);
            }
            if (curNode.V1Delete == false && curNode.V1 != null)
            {
                output = output + curNode.V1.ToString() + "\r\n";
            }
            if (curNode.medium != null)
            {
                recPrint(ref output, curNode.medium);
            }
            if (curNode.V2Delete == false && curNode.V2 != null)
            {
                output = output + curNode.V2.ToString() + "\r\n";
            }
            if (curNode.high != null)
            {
                recPrint(ref output, curNode.high);
            }
        }

        public bool search(int value)
        {
            return recSearch(value, root);
        }
        public bool recSearch(int value, Node curNode)
        {
            if (curNode.V1 == value)
            {
                if (curNode.V1Delete)
                    return false;
                else return true;
            }
            else if (curNode.V1 > value && curNode.low != null)
            {
                return recSearch(value, curNode.low);
            }
            else if (curNode.V1 < value)
            {
                if (curNode.V2 == value)
                {
                    if (curNode.V2Delete)
                        return false;
                    else return true;
                }
                else if (curNode.V2 > value && curNode.medium != null)
                {
                    return recSearch(value, curNode.medium);
                }
                else if (curNode.V2 < value && curNode.high != null)
                {
                    return recSearch(value, curNode.high);
                }
            }
            return false;
        }

        public string countNode()
        {
            int OneVNode = 0;
            int TwoVNode = 0;

            recCountNode(ref OneVNode, ref TwoVNode, root);
            return "Number of Nodes with one value: " + OneVNode.ToString() + "\r\nNumber of Nodes with two values: " + TwoVNode.ToString();
        }

        public void recCountNode(ref int OneVNode, ref int TwoVNode, Node curNode)
        {
            if (curNode.V1 != null)
            {
                if (curNode.V2 != null)
                {
                    if (curNode.V1Delete == false && curNode.V2Delete == true)
                    {
                        OneVNode++;
                    }
                    else if (curNode.V1Delete == true && curNode.V2Delete == false)
                    {
                        OneVNode++;
                    }
                    else
                        TwoVNode++;
                }
                else
                    OneVNode++;
            }
            if (curNode.low != null)
                recCountNode(ref OneVNode, ref TwoVNode, curNode.low);
            if (curNode.medium != null)
                recCountNode(ref OneVNode, ref TwoVNode, curNode.medium);
            if (curNode.high != null)
                recCountNode(ref OneVNode, ref TwoVNode, curNode.high);
        }

        public void delete(int value)
        {
            recDelete(value, root);
        }
        public void recDelete(int value, Node curNode)
        {
            if (curNode.V1 == value)
            {
                curNode.V1Delete = true;
            }
            else if (curNode.V1 > value && curNode.low != null)
            {
                recDelete(value, curNode.low);
            }
            else if (curNode.V1 < value)
            {
                if (curNode.V2 == value)
                {
                    curNode.V2Delete = true;
                }
                else if (curNode.V2 > value && curNode.medium != null)
                {
                    recDelete(value, curNode.medium);
                }
                else if (curNode.V2 < value && curNode.high != null)
                {
                    recDelete(value, curNode.high);
                }
            }
           
        }

    }
}
