using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamElliott
{
    public class Node
    {
        //int? makes it a nullable int - can store a null value. regular int require a 0.
        public int? V1;
        public int? V2;

        //Four Links
        public Node parent;
        public Node low;
        public Node medium;
        public Node high;

        //Bool Flags to indicate deleted value
        public bool V1Delete = false;
        public bool V2Delete = false;

        //Constructors
        public Node()
        {

        }
        public Node(int value1)
        {
            V1 = value1;
        }
    }
}
